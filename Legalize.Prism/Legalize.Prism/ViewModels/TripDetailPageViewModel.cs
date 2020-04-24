using Legalize.Common.Models;
using Legalize.Common.Services;
using Legalize.Prism.Helpers;
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
        private LegalizeResponse _trip;
        private readonly IApiService _apiService;

        public TripDetailPageViewModel(INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = Languages.TripDetail;
        }

        public LegalizeResponse Trip
        {
            get => _trip;
            set => SetProperty(ref _trip, value);
        }
 
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);


            if (parameters.ContainsKey("legalize"))
            {
                _trip = parameters.GetValue<LegalizeResponse>("legalize");
                Title = Languages.Trip+ " "+_trip.Id.ToString()+ Languages.From+ " "+_trip.User.FirstName+"";
            }
        }

    }
}
