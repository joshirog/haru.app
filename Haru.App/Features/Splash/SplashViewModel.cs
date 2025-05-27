using Haru.App.Shared.Services;

namespace Haru.App.Features.Splash;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class SplashViewModel : ObservableObject
{
    private readonly IDispatcher _dispatcher;
    private readonly INavigationService _navigationService;

    public SplashViewModel(IDispatcher dispatcher, INavigationService navigationService)
    {
        _dispatcher = dispatcher;
        _navigationService = navigationService;
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
                await _navigationService.GoToAsync("//HomePage");
            else
                await _navigationService.GoToAsync("SignInPage");
        });
    }

    private static Task<bool> SimulateAuthCheck()
    {
        return Task.FromResult(false);
    }
}