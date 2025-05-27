using CommunityToolkit.Mvvm.DependencyInjection;

namespace Haru.App.Features.Authentication.SignIn; // Updated namespace

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = Ioc.Default.GetRequiredService<SignInViewModel>();
    }
}