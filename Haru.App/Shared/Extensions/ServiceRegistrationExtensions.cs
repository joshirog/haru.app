using CommunityToolkit.Mvvm.DependencyInjection;
using Haru.App.Features.Account.SignIn;
using Haru.App.Features.Splash;

namespace Haru.App.Shared.Extensions;

public static class ServiceRegistrationExtensions
{
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        var configuration = builder.Configuration;
        var baseUrl = configuration["ApiSettings:BaseUrl"];
        
        builder.Services.AddSingleton<SplashViewModel>();
        builder.Services.AddSingleton<SignInViewModel>();
        
        builder.Services.AddHttpClient<SignInService>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });
        
        Ioc.Default.ConfigureServices(builder.Services.BuildServiceProvider());

        return builder;
    }
}