using Haru.App.Features.Authentication.SignIn;
using Haru.App.Features.Authentication.SignUp;
using Haru.App.Features.Authentication.ForgotPassword;
using Haru.App.Features.Authentication.ConfirmEmail;
using Haru.App.Features.Authentication.TwoFactorAuth; // Added
using Haru.App.Features.UserProfile;
using Haru.App.Features.Splash;
using Haru.App.Features.Home;

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
}