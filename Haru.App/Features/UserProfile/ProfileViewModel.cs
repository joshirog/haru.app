using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Features.UserProfile.DTOs;
using Haru.App.Features.UserProfile.Services;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Haru.App.Features.UserProfile;

public partial class ProfileViewModel : BaseViewModel
{
    private readonly IUserProfileService _userProfileService;
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService; // For potential messages
    private readonly ILogger<ProfileViewModel> _logger;
    // TODO: Later, inject an IAuthenticationStateService to get current UserId and handle logout state

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsProfileLoadedAndNotNull))] // If UserProfile changes, this also changes
    private UserProfileDto _userProfile;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsProfileLoadedAndNotNull))]
    private bool _isLoadingProfile = true;

    public bool IsProfileLoadedAndNotNull => UserProfile != null && !IsLoadingProfile;

    public ProfileViewModel(
        IUserProfileService userProfileService,
        INavigationService navigationService,
        IDialogService dialogService,
        ILogger<ProfileViewModel> logger)
    {
        _userProfileService = userProfileService;
        _navigationService = navigationService;
        _dialogService = dialogService;
        _logger = logger;

        // Load profile when ViewModel is created or navigated to
        // LoadUserProfileCommand.Execute(null); // Alternative: call directly or use [RelayCommand(IncludeCancelCommand = true)] for OnAppearing
    }
    
    // This method can be called from Page's OnAppearing
    public async Task OnAppearingAsync()
    {
        await LoadUserProfileAsync();
    }

    [RelayCommand]
    private async Task LoadUserProfileAsync()
    {
        if (IsBusy) return; 
        IsLoadingProfile = true;
        UserProfile = null; // Clear old data, triggers IsProfileLoadedAndNotNull to be false

        await ExecuteBusyActionAsync(async () => 
        {
            try
            {
                UserProfile = await _userProfileService.GetUserProfileAsync("mockUserId123");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading user profile.");
                await _dialogService.ShowAlertAsync("Error", "Could not load user profile.", "OK");
                UserProfile = null; // Explicitly null on error
            }
            finally
            {
                IsLoadingProfile = false; // Triggers IsProfileLoadedAndNotNull update
            }
        });
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        // TODO: Clear authentication state (e.g., secure storage token) via an Auth service
        // For now, just navigate to SignInPage
        bool confirm = await _dialogService.ShowConfirmationAsync("Logout", "Are you sure you want to logout?", "Yes, Logout", "Cancel");
        if (confirm)
        {
             // Simulate logout
            _logger.LogInformation("User logged out.");
            await _navigationService.GoToAsync("//SignInPage"); 
            // The "//" ensures it clears the navigation stack and SignInPage becomes the new root of navigation.
        }
    }
}
