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
        public static string LogIn => Resource.Login;
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
        public static string Email => Resource.Email;
        public static string Admin => Resource.Admin;
        public static string Employe => Resource.Employe;

        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;

        public static string EmailError => Resource.EmailError;

        public static string Password => Resource.Password;

        public static string PasswordError => Resource.PasswordError;

        public static string PasswordPlaceHolder => Resource.PasswordPlaceHolder;

        public static string Register => Resource.Register;
        public static string LoginError=> Resource.LoginError;

        public static string ChangePasswordSuccess => Resource.ChangePasswordSuccess;

        //

        public static string Address => Resource.Address;

        public static string AddressError => Resource.AddressError;

        public static string AddressPlaceHolder => Resource.AddressPlaceHolder;

        public static string Phone => Resource.Phone;

        public static string PhoneError => Resource.PhoneError;

        public static string PhonePlaceHolder => Resource.PhonePlaceHolder;

        public static string RegisterAs => Resource.RegisterAs;

        public static string RegisterAsError => Resource.RegisterAsError;

        public static string RegisterAsPlaceHolder => Resource.RegisterAsPlaceHolder;

        public static string PasswordConfirm => Resource.PasswordConfirm;

        public static string PasswordConfirmError1 => Resource.PasswordConfirmError1;

        public static string PasswordConfirmError2 => Resource.PasswordConfirmError2;

        public static string PasswordConfirmPlaceHolder => Resource.PasswordConfirmPlaceHolder;

        public static string User => Resource.User;

        public static string DocumentError => Resource.DocumentError;

        public static string FirstNameError => Resource.FirstNameError;

        public static string LastNameError => Resource.LastNameError;


    }
}
