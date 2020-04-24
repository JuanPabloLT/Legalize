using Legalize.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Legalize.Prism.ViewModels
{
   
        public class RegisterPageViewModel : ViewModelBase
        {
            public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
            {
                Title = Languages.Register;
            }
        }

    
}
