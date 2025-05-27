using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haru.App.Shared.Services;
using Haru.App.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Haru.App.Features.Authentication.Services; // For ISignUpService
using Haru.App.Features.Authentication.SignUp.DTOs; // For SignUpRequestDto

namespace Haru.App.Features.Authentication.SignUp; // Updated namespace

public partial class SignUpViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;
    private readonly ILogger<SignUpViewModel> _logger;
    private readonly INavigationService _navigationService;
    private readonly ISignUpService _signUpService;

    public SignUpViewModel(
        IDialogService dialogService, 
        ILogger<SignUpViewModel> logger, 
        INavigationService navigationService,
        ISignUpService signUpService) // Injected ISignUpService
    {
        _dialogService = dialogService;
        _logger = logger;
        _navigationService = navigationService;
        _signUpService = signUpService; // Assigned
    }

    [ObservableProperty] private string email;
    [ObservableProperty] private string phone;
    [ObservableProperty] private string password;
    [ObservableProperty] private string confirmPassword;

    [RelayCommand(Name = "SignUpCommand")] // Explicitly named the command
    private async Task SignUpAsync() 
    {
        if (string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Phone) ||
            string.IsNullOrWhiteSpace(Password) ||
            string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await _dialogService.ShowAlertAsync("Validation Error", "All fields are required.", "OK");
            return;
        }

        if (Password != ConfirmPassword)
        {
            await _dialogService.ShowAlertAsync("Validation Error", "Passwords do not match.", "OK");
            return;
        }

        await ExecuteBusyActionAsync(async () =>
        {
            try
            {
                var request = new SignUpRequestDto
                {
                    Email = Email,
                    Phone = Phone,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                };

                var response = await _signUpService.SignUpAsync(request);

                if (response.IsSuccess)
                {
                    // await _dialogService.ShowAlertAsync("Sign Up Successful", response.Message, "OK"); 
                    // Navigate to ConfirmEmailPage and pass the email as a parameter
                    var navigationParameters = new Dictionary<string, object>
                    {
                        { "email", Email } // Email is the [ObservableProperty]
                    };
                    await _navigationService.GoToAsync("ConfirmEmailPage", navigationParameters);
                }
                else
                {
                    await _dialogService.ShowAlertAsync("Sign Up Failed", response.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sign-up process error");
                await _dialogService.ShowAlertAsync("Error", "An unexpected error occurred during sign up. Please try again.", "OK");
            }
        });
    }

    [RelayCommand]
    private async Task GoToSignInAsync()
    {
        await _navigationService.GoToAsync("//SignInPage");
    }
}
