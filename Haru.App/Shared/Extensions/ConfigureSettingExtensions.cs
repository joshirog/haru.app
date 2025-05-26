using Microsoft.Extensions.Configuration;

namespace Haru.App.Shared.Extensions;

public static class ConfigureSettingExtensions
{
    public static MauiAppBuilder ConfigureSettings(this MauiAppBuilder builder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        builder.Configuration.AddConfiguration(config);
        
        //builder.Services.Configure<SettingConfiguration>(config.GetSection("ApiSettings"));

        return builder;
    }
}