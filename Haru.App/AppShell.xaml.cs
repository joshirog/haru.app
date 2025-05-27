using Haru.App.Features.Authentication.SignIn;
using Haru.App.Features.Authentication.SignUp;
using Haru.App.Features.Authentication.ForgotPassword;
using Haru.App.Features.Authentication.ConfirmEmail;
using Haru.App.Features.Authentication.TwoFactorAuth; // Added
using Haru.App.Features.UserProfile;
using Haru.App.Features.Splash;
using Haru.App.Features.Home;
using System.Threading.Tasks; // Added for Task

namespace Haru.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("SplashPage", typeof(SplashPage));
        Routing.RegisterRoute("SignInPage", typeof(Haru.App.Features.Authentication.SignIn.SignInPage));
        Routing.RegisterRoute("SignUpPage", typeof(Haru.App.Features.Authentication.SignUp.SignUpPage));
        Routing.RegisterRoute("ForgotPasswordPage", typeof(ForgotPasswordPage));
        Routing.RegisterRoute("ConfirmEmailPage", typeof(ConfirmEmailPage));
        Routing.RegisterRoute("TwoFactorAuthPage", typeof(TwoFactorAuthPage)); // Added
        Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
    }

    private static Task<bool> SimulateAuthCheck()
    {
        return Task.FromResult(false); // Or true, depending on desired test outcome
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Ensure this runs on the UI thread, especially if OnAppearing itself might not be on it or for safety.
        // However, OnAppearing is typically on the UI thread. A direct await might be fine.
        // For maximum safety with navigation, especially after an await, dispatching is good.
        await Dispatcher.DispatchAsync(async () =>
        {
            var isAuthenticated = await SimulateAuthCheck();
            if (isAuthenticated)
            {
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await Shell.Current.GoToAsync("SignInPage");
            }
        });
    }
}