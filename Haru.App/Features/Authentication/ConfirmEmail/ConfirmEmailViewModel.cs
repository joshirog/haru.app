using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Common.Responses;
using Haru.App.Features.Authentication.ConfirmEmail.DTOs;
using Haru.App.Features.Authentication.Services;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.ConfirmEmail;

// Add QueryProperty attribute if email is passed via navigation
[QueryProperty(nameof(Email), "email")]
public partial class ConfirmEmailViewModel : BaseViewModel
{
    private readonly IConfirmEmailService _confirmEmailService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly ILogger<ConfirmEmailViewModel> _logger;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _confirmationCode;

    public ConfirmEmailViewModel(
        IConfirmEmailService confirmEmailService,
        IDialogService dialogService,
        INavigationService navigationService,
        ILogger<ConfirmEmailViewModel> logger)
    {
        _confirmEmailService = confirmEmailService;
        _dialogService = dialogService;
        _navigationService = navigationService;
        _logger = logger;
    }

    [RelayCommand]
    private async Task ConfirmEmailAsync()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(ConfirmationCode)) return;

        await ExecuteBusyActionAsync(async () =>
        {
            var request = new ConfirmEmailRequestDto { Email = this.Email, ConfirmationCode = this.ConfirmationCode };
            var response = await _confirmEmailService.ConfirmEmailAsync(request);

            if (response.IsSuccess)
            {
                await _dialogService.ShowAlertAsync("Success", response.Message, "OK");
                // Navigate to SignIn or HomePage after successful confirmation
                await _navigationService.GoToAsync("//SignInPage"); // Or //HomePage if auto-login
            }
            else
            {
                await _dialogService.ShowAlertAsync("Error", response.Message, "OK");
            }
        });
    }

    [RelayCommand]
    private async Task ResendCodeAsync()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(Email)) 
        {
            await _dialogService.ShowAlertAsync("Error", "Email address is not available to resend code.", "OK");
            return;
        }

        await ExecuteBusyActionAsync(async () =>
        {
            var request = new ResendEmailCodeRequestDto { Email = this.Email };
            var response = await _confirmEmailService.ResendConfirmationCodeAsync(request);
            // Show feedback from response (success or error)
            await _dialogService.ShowAlertAsync(response.IsSuccess ? "Code Sent" : "Error", response.Message, "OK");
        });
    }
    
    [RelayCommand]
    private async Task GoToSignInAsync()
    {
        await _navigationService.GoToAsync("//SignInPage");
    }
}
