using Legalize.Common.Models;
using Legalize.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Prism.ViewModels
{
    public class LegalizeHistoryItemViewModel : LegalizeResponse
    {

        private readonly INavigationService _navigationService;
        private DelegateCommand _selectLegalizeCommand;
        public LegalizeHistoryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectLegalizeCommand => _selectLegalizeCommand ??
            (_selectLegalizeCommand = new DelegateCommand(SelectLegalizeAsync));

        private async void SelectLegalizeAsync()
        {
            var parameters = new NavigationParameters
            {
                { "legalize", this }
            };

            await _navigationService.NavigateAsync(nameof(TripDetailPage), parameters);
        }

    }
}
