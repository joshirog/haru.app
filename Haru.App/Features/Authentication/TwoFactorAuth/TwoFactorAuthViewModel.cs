using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Common.Responses;
using Haru.App.Features.Authentication.TwoFactorAuth.DTOs;
using Haru.App.Features.Authentication.Services;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.TwoFactorAuth;

[QueryProperty(nameof(UserId), "userId")] // To receive UserId from SignInViewModel
public partial class TwoFactorAuthViewModel : BaseViewModel
{
    private readonly ITwoFactorAuthService _twoFactorAuthService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly ILogger<TwoFactorAuthViewModel> _logger;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasUserId))] // If UserId changes, this also changes
    private string _userId; 

    public bool HasUserId => !string.IsNullOrEmpty(UserId);

    [ObservableProperty]
    private string _twoFactorCode;

    public TwoFactorAuthViewModel(
        ITwoFactorAuthService twoFactorAuthService,
        IDialogService dialogService,
        INavigationService navigationService,
        ILogger<TwoFactorAuthViewModel> logger)
    {
        _twoFactorAuthService = twoFactorAuthService;
        _dialogService = dialogService;
        _navigationService = navigationService;
        _logger = logger;
    }

    [RelayCommand]
    private async Task VerifyCodeAsync()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(TwoFactorCode)) return;

        await ExecuteBusyActionAsync(async () =>
        {
            var request = new VerifyTwoFactorCodeRequestDto { UserId = this.UserId, Code = this.TwoFactorCode };
            var response = await _twoFactorAuthService.VerifyCodeAsync(request);

            if (response.IsSuccess)
            {
                // Successful 2FA verification, navigate to HomePage
                // TODO: Consider if a new token/session update is needed from a real backend
                await _navigationService.GoToAsync("//HomePage"); 
            }
            else
            {
                await _dialogService.ShowAlertAsync("Error", response.Message, "OK");
                TwoFactorCode = string.Empty; // Clear the code on error
            }
        });
    }
    
    [RelayCommand]
    private async Task GoToSignInAsync()
    {
        // Allow user to go back to Sign In if they somehow landed here by mistake or want to cancel
        await _navigationService.GoToAsync("//SignInPage");
    }
}
