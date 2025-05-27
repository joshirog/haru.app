using Microsoft.Maui.Controls;

namespace Haru.App.Features.Authentication.ForgotPassword;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage(ForgotPasswordViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
