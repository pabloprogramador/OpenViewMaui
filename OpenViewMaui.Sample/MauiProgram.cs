using Microsoft.Extensions.Logging;

namespace OpenViewMaui.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                handlers.AddHandler(typeof(OpenViewPage), typeof(OpenViewMaui.Platforms.Android.OpenViewPageHandler));
#endif
#if IOS
                handlers.AddHandler(typeof(PopupPage), typeof(Platforms.iOS.PopupPageHandler));
#endif
#if WINDOWS
                handlers.AddHandler(typeof(PopupPage), typeof(Platforms.Windows.PopupPageHandler));
#endif
            }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

