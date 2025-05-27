using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Features.Authentication.Services; // Updated: For ISignInService
using Haru.App.Features.Authentication.SignIn.DTOs; // Updated: For DTOs
using Haru.App.Shared.Services; // For IDialogService, INavigationService
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Haru.App.Features.Authentication.SignIn; // Updated namespace

public partial class SignInViewModel : BaseViewModel
{
    private readonly ISignInService _signInService; 
    private readonly IDialogService _dialogService;
    private readonly ILogger<SignInViewModel> _logger;
    private readonly INavigationService _navigationService;

    public SignInViewModel(
        ISignInService signInService, 
        IDialogService dialogService, 
        ILogger<SignInViewModel> logger, 
        INavigationService navigationService)
    {
        _signInService = signInService;
        _dialogService = dialogService;
        _logger = logger;
        _navigationService = navigationService;
    }

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    private async Task SignInAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await _dialogService.ShowAlertAsync("Error", "Usuario y contraseña son requeridos", "OK");
            return;
        }

        await ExecuteBusyActionAsync(async () =>
        {
            try
            {
                var request = new SignInRequestDto { Username = Username, Password = Password }; // Use DTO
                var response = await _signInService.SignInAsync(request);

                if (!string.IsNullOrEmpty(response?.Token)) 
                {
                    if (response.IsTwoFactorEnabled)
                    {
                        // Navigate to 2FA page, passing UserId
                        var navigationParameters = new Dictionary<string, object>
                        {
                            { "userId", response.UserId }
                        };
                        await _navigationService.GoToAsync("TwoFactorAuthPage", navigationParameters);
                    }
                    else
                    {
                        // TODO: Store token securely (e.g., using SecureStorage)
                        // For now, directly navigate to HomePage
                        await _navigationService.GoToAsync("//HomePage");
                    }
                }
                else
                {
                    await _dialogService.ShowAlertAsync("Acceso denegado", "Credenciales incorrectas", "OK");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sign-in error");
                await _dialogService.ShowAlertAsync("Error", "An unexpected error occurred during sign in. Please try again.", "OK");
            }
        });
    }
    
    [RelayCommand]
    private async Task GoToSignUpAsync()
    {
        await _navigationService.GoToAsync("SignUpPage");
    }

    [RelayCommand]
    private async Task GoToForgotPasswordAsync()
    {
        await _navigationService.GoToAsync("ForgotPasswordPage"); // Assuming "ForgotPasswordPage" will be the route name
    }
}
