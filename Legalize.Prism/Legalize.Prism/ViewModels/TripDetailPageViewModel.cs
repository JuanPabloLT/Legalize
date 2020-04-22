using Legalize.Common.Models;
using Legalize.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Legalize.Prism.ViewModels
{
    public class TripDetailPageViewModel : ViewModelBase
    {
        private TripResponse _trip;
        private readonly IApiService _apiService;

        public TripDetailPageViewModel(INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Trip Detail";
        }

        public TripResponse Trip
        {
            get => _trip;
            set => SetProperty(ref _trip, value);
        }


        
        
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("trip"))
            {
                Trip = parameters.GetValue<TripResponse>("trip");
            }
        }

    }
}
