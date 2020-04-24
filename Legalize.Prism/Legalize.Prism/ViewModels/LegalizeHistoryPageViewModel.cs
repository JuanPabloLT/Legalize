using Legalize.Common.Models;
using Legalize.Common.Services;
using Prism.Commands;
using Prism.Navigation;
using Legalize.Prism.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Legalize.Prism.Helpers;

namespace Legalize.Prism.ViewModels
{
    public class LegalizeHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<LegalizeHistoryItemViewModel> _legalize;
        //private List<LegalizeHistoryItemViewModel> _details;
        private bool _isRunning;
        //private DelegateCommand _checkEmployeeIdCommand;

        public LegalizeHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.LegalizeHistory;
            LoadLegalizesAsync();
        }

        public List<LegalizeHistoryItemViewModel> Legalize
        {
            get => _legalize;
            set => SetProperty(ref _legalize, value);
        }


        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        /*public List<LegalizeHistorytemViewModel> Details
        {
            get => _details;
            set => SetProperty(ref _details, value);
        }*/


        private async void LoadLegalizesAsync()
        {

            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();
           var connection = await _apiService.CheckConnectionAsync(url);
           if (!connection)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            Response response = await _apiService.GetListAsync<LegalizeResponse>(url, "api", "/Legalizes/GetLegalizeEntity");

            IsRunning = false;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
            }

            var legalize = (List<LegalizeResponse>)response.Result;

            Legalize = legalize.Select(l => new LegalizeHistoryItemViewModel(_navigationService)
            {
                Id = l.Id,
                StartDate = l.StartDate,
                EndDate = l.EndDate,
                City = l.City,
                User = l.User,
                Trips = l.Trips,
                
            }).ToList();
        }
    }
}
