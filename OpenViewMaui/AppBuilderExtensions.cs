using System;
namespace OpenViewMaui
{
    public static class AppBuilderExtensions
    {

        public static MauiAppBuilder UseOpenViewMaui(this MauiAppBuilder builder)
        {

            builder.ConfigureMauiHandlers((handlers) =>
            {
#if ANDROID
                handlers.AddHandler(typeof(OpenViewPage), typeof(OpenViewMaui.Platforms.Android.OpenViewPageHandler));
#elif IOS
             
#endif
            });
            return builder;
        }
    }
}