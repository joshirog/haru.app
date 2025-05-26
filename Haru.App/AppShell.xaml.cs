using Haru.App.Features.Account.SignIn;
using Haru.App.Features.Account.SignUp;
using Haru.App.Features.Splash;

namespace Haru.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("SplashPage", typeof(SplashPage));
        Routing.RegisterRoute("SignInPage", typeof(SignInPage));
        Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
    }
}