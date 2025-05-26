using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Haru.App.Features.Account.SignUp;

public partial class SignUpViewModel : ObservableObject
{
    [ObservableProperty] private string email;
    [ObservableProperty] private string phone;
    [ObservableProperty] private string password;
    [ObservableProperty] private string confirmPassword;
    [ObservableProperty] private bool isBusy;

    [RelayCommand]
    private async Task SignUpCommand()
    {
        if (string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Phone) ||
            string.IsNullOrWhiteSpace(Password) ||
            string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await Application.Current?.MainPage?.DisplayAlert("Error", "Todos los campos son obligatorios", "OK")!;
            return;
        }

        if (Password != ConfirmPassword)
        {
            await Application.Current?.MainPage?.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
            return;
        }

        IsBusy = true;

        try
        {
            await Task.Delay(1500); // Simulación
            await Application.Current?.MainPage?.DisplayAlert("Éxito", "Cuenta creada correctamente", "OK");
            await Shell.Current.GoToAsync("//SignInPage");
        }
        finally
        {
            IsBusy = false;
        }
    }
}