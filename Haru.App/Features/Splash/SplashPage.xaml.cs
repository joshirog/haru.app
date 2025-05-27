using Microsoft.Maui.Controls;

namespace Haru.App.Features.Splash;

public partial class SplashPage : ContentPage
{
    public SplashPage(SplashViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}