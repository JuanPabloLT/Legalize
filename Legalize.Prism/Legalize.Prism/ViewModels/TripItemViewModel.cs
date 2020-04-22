using Legalize.Common.Models;
using Legalize.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Prism.ViewModels
{
    public class TripItemViewModel : TripResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTripCommand;

        public TripItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectTripCommand => _selectTripCommand ?? (_selectTripCommand = new DelegateCommand(SelectTripAsync));

        private async void SelectTripAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "trip", this }
            };

            await _navigationService.NavigateAsync(nameof(TripDetailPage), parameters);
        }
    }
}
