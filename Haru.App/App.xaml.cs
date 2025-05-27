using Haru.App.Features.Splash;

namespace Haru.App;

public partial class App : Application
{
    public App(SplashPage splashPage)
    {
        InitializeComponent();

        MainPage = splashPage;
        
        //Shell.Current.GoToAsync(nameof(SplashPage));
    }
}