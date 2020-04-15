using Legalize.Common.Models;
using Legalize.Common.Services;
using Prism.Commands;
using Prism.Navigation;
using Legalize.Prism.ViewModels;

namespace Legalize.Prism.ViewModels
{
    public class LegalizeHistoryPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private LegalizeResponse _legalize;
        private bool _isRunning;
        private DelegateCommand _checkEmployeeIdCommand;

        public LegalizeHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
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


        public string EmployeeId { get; set; }

        public DelegateCommand CheckEmployeeIdCommand => _checkEmployeeIdCommand ?? (_checkEmployeeIdCommand = new DelegateCommand(CheckEmployeeIdAsync));

        private async void CheckEmployeeIdAsync()
        {
            if (string.IsNullOrEmpty(EmployeeId))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Employee Id.",
                    "Accept");
                return;
            }

            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetLegalizeAsync(EmployeeId, url, "api", "/Legalizes");
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
        }
    }
}
