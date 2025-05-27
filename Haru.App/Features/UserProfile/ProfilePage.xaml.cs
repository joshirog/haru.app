using Microsoft.Maui.Controls; // Added for ContentPage

namespace Haru.App.Features.UserProfile;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel != null) // Added null check
        {
            await _viewModel.OnAppearingAsync(); // Call ViewModel's OnAppearing
        }
    }
}
