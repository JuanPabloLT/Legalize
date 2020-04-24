using Legalize.Common.Models;
using Legalize.Prism.Helpers;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;



namespace Legalize.Prism.ViewModels
{
    public class LegalizeMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        //private readonly IApiService _apiService;
        //private UserResponse _user;
        //private DelegateCommand _modifyUserCommand;
        //private static LegalizeMasterDetailPageViewModel _instance;

        public LegalizeMasterDetailPageViewModel(INavigationService navigationService/*, IApiService apiService*/)
            : base(navigationService)
        {
            //_instance = this;
            _navigationService = navigationService;
            //_apiService = apiService;
            //LoadUser();
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_add_circle",
                    PageName = "HomePage",
                    Title = Languages.AddTripRecord
                },
                new Menu
                {
                    Icon = "ic_view_list",
                    PageName = "LegalizeHistoryPage",
                    Title = Languages.SeeEmployeeHistory
                },
                new Menu
                {
                    Icon = "ic_build",
                    PageName = "ModifyUserPage",
                    Title = Languages.ModifyUser
                },
                /*new Menu
                {
                    Icon = "ic_report_problem",
                    PageName = "ReportPage",
                    Title = "Report An Incident"
                },*/
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = Languages.Login
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }

        //public DelegateCommand ModifyUserCommand => _modifyUserCommand ?? (_modifyUserCommand = new DelegateCommand(ModifyUserAsync));

        /*public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }*/

        /*public static LegalizeMasterDetailPageViewModel GetInstance()
        {
            return _instance;
        }*/

        

        /*private async void ModifyUserAsync()
        {
            await _navigationService.NavigateAsync($"/LegalizeMasterDetailPage/NavigationPage/{nameof(ModifyUserPage)}");
        }*/

        /*private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
        }*/

       
    }
}
