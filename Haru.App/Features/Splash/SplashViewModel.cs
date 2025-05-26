using Haru.App.Features.Account.SignIn;

namespace Haru.App.Features.Splash;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class SplashViewModel : ObservableObject
{
    private readonly IDispatcher _dispatcher;

    public SplashViewModel(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        Start();
    }

    private void Start()
    {
        _dispatcher.Dispatch(async () =>
        {
            await Task.Delay(2000); // Simula carga

            Application.Current.MainPage = new AppShell();
            
            await Task.Delay(500); // esperar que Shell se inicialice
            
            var isAuthenticated = await SimulateAuthCheck();
            
            if (isAuthenticated)
                await Shell.Current?.GoToAsync("SignUpPage");
            else
                await Shell.Current?.GoToAsync("SignInPage");
        });
    }

    private static Task<bool> SimulateAuthCheck()
    {
        return Task.FromResult(false);
    }
}