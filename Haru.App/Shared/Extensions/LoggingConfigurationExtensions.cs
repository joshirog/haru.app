using Microsoft.Extensions.Logging;
using Serilog;

namespace Haru.App.Shared.Extensions;

public static class LoggingConfigurationExtensions
{
    public static void ConfigureLogging(this MauiAppBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog();
        
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Log.Fatal(args.ExceptionObject as Exception, "Unhandled exception");
            Log.CloseAndFlush();
        };
    }
}