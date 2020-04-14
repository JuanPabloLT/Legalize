using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Legalize.Prism.ViewModels
{
    public class LegalizeHistoryPageViewModel : ViewModelBase
    {
        public LegalizeHistoryPageViewModel(INavigationService navigationServices)
            : base(navigationServices)
        {
            Title = "See Employee History";
        }
    }
}
