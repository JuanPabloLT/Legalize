using Prism;
using Prism.Ioc;
using Legalize.Prism.ViewModels;
using Legalize.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Legalize.Common.Services;
using Syncfusion.Licensing;
using Legalize.Prism.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Legalize.Prism
{
    public partial class App
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            
            SyncfusionLicenseProvider.RegisterLicense("MjQxMTQzQDMxMzgyZTMxMmUzMElHdUYvVFZFeEZVK2V6YXdTY1J1Y1doalNMT1JJbTc2a085L2ZWTlk1TUU9");
            InitializeComponent();
            await NavigationService.NavigateAsync("/LegalizeMasterDetailPage/NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<LegalizeMasterDetailPage, LegalizeMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<LegalizeHistoryPage, LegalizeHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<TripDetailPage, TripDetailPageViewModel>();
        }
    }
}
