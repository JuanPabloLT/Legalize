using Legalize.Common.Models;
using Legalize.Common.Services;
using Prism.Commands;
using Prism.Navigation;
using Legalize.Prism.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Legalize.Prism.ViewModels
{
    public class LegalizeHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private LegalizeResponse _legalize;
        private List<TripItemViewModel> _details;
        private bool _isRunning;
        private DelegateCommand _checkEmployeeIdCommand;

        public LegalizeHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Legalize History";
        }
        
        public LegalizeResponse Legalize
        {
            get => _legalize;
            set => SetProperty(ref _legalize, value);
        }


        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public List<TripItemViewModel> Details
        {
            get => _details;
            set => SetProperty(ref _details, value);
        }


        public int Id { get; set; }

        public DelegateCommand CheckEmployeeIdCommand => _checkEmployeeIdCommand ?? (_checkEmployeeIdCommand = new DelegateCommand(CheckEmployeeIdAsync));

        private async void CheckEmployeeIdAsync()
        {
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a trip Id.",
                    "Accept");
                return;
            }

            IsRunning = true;
            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            Response response = await _apiService.GetLegalizeAsync(Id, url, "api", "/Legalizes");
            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            Legalize = (LegalizeResponse)response.Result;
            Details = Legalize.Trips.Select(tr => new TripItemViewModel(_navigationService)
            {
                Id = tr.Id,
                Date = tr.Date,
                Amount = tr.Amount,
                Description = tr.Description,
                PicturePath = tr.PicturePath,
            }).ToList();
        }
    }
}
