using System;
using Android.Content;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace OpenViewMaui.Platforms.Android
{
	public class OpenViewPageHandler : PageHandler
    {
        public bool _disposed;

        public OpenViewPageHandler()
		{
            this.SetMauiContext(MauiApplication.Current.Application.Windows[0].Handler.MauiContext);
        }

        protected override void ConnectHandler(ContentViewGroup platformView)
        {
            (platformView as OpenViewPageRenderer).OpenViewHandler = this;
            base.ConnectHandler(platformView);
        }

        protected override ContentViewGroup CreatePlatformView()
        {
            return new OpenViewPageRenderer(Context);
        }


        protected override void DisconnectHandler(ContentViewGroup platformView)
        {
            base.DisconnectHandler(platformView);
        }
    }
}