using CommunityToolkit.Mvvm.ComponentModel; // For ObservableObject if BaseViewModel not used, or for [RelayCommand]
using CommunityToolkit.Mvvm.Input;
using Haru.App.Shared.Services; // For INavigationService
using Haru.App.Shared.ViewModels; // For BaseViewModel
using System.Threading.Tasks;

namespace Haru.App.Features.Home;

public partial class HomePageViewModel : BaseViewModel // Inherit from BaseViewModel
{
    private readonly INavigationService _navigationService;

    // Example property
    [ObservableProperty]
    private string _welcomeMessage = "Welcome to HaruApp!";

    public HomePageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        // Title can be set here or in XAML
    }

    [RelayCommand]
    private async Task GoToProfileAsync()
    {
        await _navigationService.GoToAsync("ProfilePage");
    }
}
