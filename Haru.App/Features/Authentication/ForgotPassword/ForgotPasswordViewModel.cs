using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Common.Responses;
using Haru.App.Features.Authentication.ForgotPassword.DTOs;
using Haru.App.Features.Authentication.Services;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging; // Added for consistency, though not used in mock logic yet
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.ForgotPassword;

public partial class ForgotPasswordViewModel : BaseViewModel
{
    private readonly IForgotPasswordService _forgotPasswordService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly ILogger<ForgotPasswordViewModel> _logger;

    [ObservableProperty]
    private string _email;

    public ForgotPasswordViewModel(
        IForgotPasswordService forgotPasswordService,
        IDialogService dialogService,
        INavigationService navigationService,
        ILogger<ForgotPasswordViewModel> logger)
    {
        _forgotPasswordService = forgotPasswordService;
        _dialogService = dialogService;
        _navigationService = navigationService;
        _logger = logger;
    }

    [RelayCommand]
    private async Task SendResetLinkAsync()
    {
        if (IsBusy) return;

        await ExecuteBusyActionAsync(async () =>
        {
            var request = new ForgotPasswordRequestDto { Email = this.Email };
            var response = await _forgotPasswordService.SendPasswordResetLinkAsync(request);

            if (response.IsSuccess)
            {
                await _dialogService.ShowAlertAsync("Check Your Email", response.Message, "OK");
                // Optionally navigate back or to a confirmation page
                // For now, just show message. Can navigate back to SignIn:
                // await _navigationService.GoToAsync("//SignInPage"); 
            }
            else
            {
                await _dialogService.ShowAlertAsync("Error", response.Message, "OK");
            }
        });
    }

    [RelayCommand]
    private async Task GoToSignInAsync()
    {
        await _navigationService.GoToAsync("//SignInPage");
    }
}
