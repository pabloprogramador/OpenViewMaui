using System;
using Microsoft.Maui.Handlers;

namespace OpenViewMaui.Platforms.iOS
{
    public class OpenViewPageHandler : PageHandler
    {
        public OpenViewPageHandler()
        {
            this.SetMauiContext(MauiUIApplicationDelegate.Current.Application.Windows[0].Handler.MauiContext);
        }

        protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
        {
            return base.CreatePlatformView();
        }

        protected override void DisconnectHandler(Microsoft.Maui.Platform.ContentView nativeView)
        {
            base.DisconnectHandler(nativeView);
        }
    }
}

