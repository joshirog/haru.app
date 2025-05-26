using CommunityToolkit.Mvvm.DependencyInjection;
using Haru.App.Features.Account.SignIn;
using Haru.App.Features.Account.SignUp;
using Haru.App.Features.Splash;
using Haru.App.Shared.Services;

namespace Haru.App.Shared.Extensions;

public static class ServiceRegistrationExtensions
{
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        var configuration = builder.Configuration;
        var baseUrl = configuration["ApiSettings:BaseUrl"];
        
        builder.Services.AddSingleton<SplashViewModel>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignUpViewModel>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
        builder.Services.AddHttpClient<ISignInService, SignInService>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });
        
        Ioc.Default.ConfigureServices(builder.Services.BuildServiceProvider());

        return builder;
    }
}