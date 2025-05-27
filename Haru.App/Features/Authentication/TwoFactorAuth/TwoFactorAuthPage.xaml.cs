using Microsoft.Maui.Controls; // Added for ContentPage

namespace Haru.App.Features.Authentication.TwoFactorAuth;

public partial class TwoFactorAuthPage : ContentPage
{
    public TwoFactorAuthPage(TwoFactorAuthViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
