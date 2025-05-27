using CommunityToolkit.Mvvm.DependencyInjection;
using Haru.App.Features.Authentication.SignIn;
using Haru.App.Features.Authentication.SignUp;
using Haru.App.Features.Authentication.ForgotPassword;
using Haru.App.Features.Authentication.ConfirmEmail;
using Haru.App.Features.Authentication.TwoFactorAuth; // Added
using Haru.App.Features.UserProfile;
using Haru.App.Features.UserProfile.Services;
using Haru.App.Features.UserProfile.Services.Mock;
using Haru.App.Features.Home; // Added
using Haru.App.Features.Splash;
using Haru.App.Shared.Services;
using Haru.App.Features.Authentication.Services;
using Haru.App.Features.Authentication.Services.Mock;

namespace Haru.App.Shared.Extensions;

public static class ServiceRegistrationExtensions
{
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        var configuration = builder.Configuration;
        var baseUrl = configuration["ApiSettings:BaseUrl"];
        
        builder.Services.AddSingleton<SplashViewModel>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<Haru.App.Features.Authentication.SignUp.SignUpViewModel>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<ConfirmEmailViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<TwoFactorAuthViewModel>(); // Added

        // Register Pages
        builder.Services.AddTransient<SplashPage>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<ConfirmEmailPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<TwoFactorAuthPage>(); // Added

        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
        // Mock Service Registrations
        builder.Services.AddScoped<ISignInService, Haru.App.Features.Authentication.Services.Mock.SignInService>();
        builder.Services.AddScoped<ISignUpService, Haru.App.Features.Authentication.Services.Mock.SignUpService>();
        builder.Services.AddScoped<IForgotPasswordService, Haru.App.Features.Authentication.Services.Mock.ForgotPasswordService>();
        builder.Services.AddScoped<IConfirmEmailService, Haru.App.Features.Authentication.Services.Mock.ConfirmEmailService>();
        builder.Services.AddScoped<ITwoFactorAuthService, Haru.App.Features.Authentication.Services.Mock.TwoFactorAuthService>(); // Added
        builder.Services.AddScoped<IUserProfileService, Haru.App.Features.UserProfile.Services.Mock.UserProfileService>();
        
        Ioc.Default.ConfigureServices(builder.Services.BuildServiceProvider());

        return builder;
    }
}