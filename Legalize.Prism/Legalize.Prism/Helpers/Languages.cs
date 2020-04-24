using Legalize.Prism.Interfaces;
using Legalize.Prism.Resources;
using Xamarin.Forms;

namespace Legalize.Prism.Helpers
{
    public static class Languages
    {

        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Culture { get; set; }
        public static string Accept => Resource.Accept;
        public static string ConnectionError => Resource.ConnectionError;
        public static string Error => Resource.Error;
        public static string AddTripRecord => Resource.AddTripRecord;
        public static string TripDetail => Resource.TripDetail;
        public static string From => Resource.from;
        public static string HomePage => Resource.HomePage;
        public static string Legalize => Resource.Legalize;
        public static string LegalizeHistory => Resource.LegalizeHistory;
        public static string Login => Resource.Login;
        public static string Logout => Resource.Logout;
        public static string ModifyUser => Resource.ModifyUser;
        public static string Trip => Resource.Trip;
        public static string Loading => Resource.Loading;
        public static string WELCOME => Resource.WELCOME;
        public static string Menu => Resource.Menu;
        public static string SeeEmployeeHistory => Resource.SeeEmployeeHistory;
        public static string ConfirmEmail => Resource.ConfirmEmail;
        public static string EmailConfirmationBody => Resource.EmailConfirmationBody;
        public static string EmailConfirmationSubject => Resource.EmailConfirmationSubject;


    }
}
