using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Haru.App.Features.Account.SignUp;

public partial class SignUpViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;
    private readonly ILogger<SignUpViewModel> _logger;
    private readonly INavigationService _navigationService;

    public SignUpViewModel(IDialogService dialogService, ILogger<SignUpViewModel> logger, INavigationService navigationService)
    {
        _dialogService = dialogService;
        _logger = logger;
        _navigationService = navigationService;
    }

    [ObservableProperty] private string email;
    [ObservableProperty] private string phone;
    [ObservableProperty] private string password;
    [ObservableProperty] private string confirmPassword;

    [RelayCommand]
    private async Task SignUpCommand()
    {
        if (string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Phone) ||
            string.IsNullOrWhiteSpace(Password) ||
            string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await _dialogService.ShowAlertAsync("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        if (Password != ConfirmPassword)
        {
            await _dialogService.ShowAlertAsync("Error", "Las contraseñas no coinciden", "OK");
            return;
        }

        await ExecuteBusyActionAsync(async () =>
        {
            try
            {
                // Simulate actual sign-up process
                await Task.Delay(1500); // Simulación
                                        // In a real app, you would call a SignUpService here.
                                        // Example: var result = await _signUpService.SignUpAsync(Email, Phone, Password);
                                        // if (result.IsSuccess) { ... } else { ... }

                await _dialogService.ShowAlertAsync("Éxito", "Cuenta creada correctamente", "OK");
                await _navigationService.GoToAsync("//SignInPage");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sign-up error");
                await _dialogService.ShowAlertAsync("Error", "An unexpected error occurred during sign up. Please try again.", "OK");
            }
        });
    }
}