using CommunityToolkit.Mvvm.Input;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Haru.App.Features.Account.SignIn;

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
                var request = new SignInRequest { Username = Username, Password = Password };
                var response = await _signInService.SignInAsync(request);

                if (!string.IsNullOrEmpty(response?.Token))
                {
                    await _navigationService.GoToAsync("//HomePage");
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
}