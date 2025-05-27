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
            // All other logic (delay for shell init, auth check, navigation) removed.
        });
    }
}