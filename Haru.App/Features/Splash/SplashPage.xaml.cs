using Microsoft.Maui.Controls;

namespace Haru.App.Features.Splash;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        BindingContext = new SplashViewModel(Application.Current.Dispatcher);
    }
}