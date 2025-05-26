using Haru.App.Shared.Extensions;
using Serilog;

namespace Haru.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		try
		{
			var builder = MauiApp.CreateBuilder();
			
			builder
				.ConfigureSettings()
				.UseMauiApp<App>()
				.RegisterAppServices()
				.ConfigureCustomFonts()
				.ConfigureLogging();
			
			return builder.Build();
		}
		catch (Exception ex)
		{
			Log.Fatal(ex, "La aplicación falló al arrancar.");
			throw;
		}
		finally
		{
			Log.CloseAndFlush();
		}
	}
}
