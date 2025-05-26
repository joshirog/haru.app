using CommunityToolkit.Mvvm.DependencyInjection;

namespace Haru.App.Features.Account.SignIn;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = Ioc.Default.GetRequiredService<SignInViewModel>();
    }
}