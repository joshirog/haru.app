using Microsoft.Maui.Controls; // Required for ContentPage

namespace Haru.App.Features.Authentication.ConfirmEmail;

public partial class ConfirmEmailPage : ContentPage
{
    public ConfirmEmailPage(ConfirmEmailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
