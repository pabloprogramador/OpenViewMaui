using Android.Views;
using Android.Widget;
using OpenViewMaui.Contracts;
using AView = Android.Views.View;

namespace OpenViewMaui.Platforms.Android
{
	public class OpenViewAndroid : Contracts.IOpenViewPlatform
	{
        private static FrameLayout? DecoreView => Platform.CurrentActivity?.Window?.DecorView as FrameLayout;

        public OpenViewAndroid()
		{
		}

        public Task AddAsync(OpenViewPage page)
        {
            try
            {
                page.Parent = MauiApplication.Current.Application.Windows[0].Content as Element;

                var AndroidNativeView = IOpenViewPlatform.GetOrCreateHandler<OpenViewPageHandler>(page).PlatformView as AView;
                DecoreView?.AddView(AndroidNativeView);

                return PostAsync(AndroidNativeView);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task RemoveAsync(OpenViewPage page)
        {
            var renderer = IOpenViewPlatform.GetOrCreateHandler<OpenViewPageHandler>(page);

            if (renderer != null)
            {
                DecoreView?.RemoveView(renderer.PlatformView as AView);
                renderer.DisconnectHandler(); //?? no clue if works
                page.Parent = null;

                return PostAsync(DecoreView);
            }

            return Task.CompletedTask;
        }

        Task<bool> PostAsync(AView? nativeView)
        {
            if (nativeView == null)
            {
                return Task.FromResult(true);
            }

            var tcs = new TaskCompletionSource<bool>();

            nativeView.Post(() => tcs.SetResult(true));

            return tcs.Task;
        }
    }
}