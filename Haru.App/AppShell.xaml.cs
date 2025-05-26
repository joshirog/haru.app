using Haru.App.Features.Account.SignIn;
using Haru.App.Features.Account.SignUp;
using Haru.App.Features.Splash;
using Haru.App.Features.Home;

namespace Haru.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("SplashPage", typeof(SplashPage));
        Routing.RegisterRoute("SignInPage", typeof(SignInPage));
        Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
    }
}