using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Haru.App.Features.Account.SignIn;

public partial class SignInViewModel : ObservableObject
{
    private readonly SignInService _signInService;

    public SignInViewModel(SignInService signInService)
    {
        _signInService = signInService;
    }

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private bool isBusy;

    [RelayCommand]
    private async Task SignInAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Usuario y contraseña son requeridos", "OK");
            return;
        }

        IsBusy = true;

        try
        {
            var request = new SignInRequest
            {
                Username = Username,
                Password = Password
            };

            var response = await _signInService.SignInAsync(request);

            if (response?.Token != null)
            {
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await Application.Current!.MainPage!.DisplayAlert("Acceso denegado", "Credenciales incorrectas", "OK");
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task GoToSignUpAsync()
    {
        await Shell.Current.GoToAsync("SignUpPage");
    }
}