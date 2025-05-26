using Haru.App.Features.Splash;

namespace Haru.App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new SplashPage();
        
        //Shell.Current.GoToAsync(nameof(SplashPage));
    }
}