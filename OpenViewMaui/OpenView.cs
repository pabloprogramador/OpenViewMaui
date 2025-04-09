using System;
using OpenViewMaui.Contracts;

namespace OpenViewMaui
{
    public class OpenView
    {
        private bool _isShow;
        private static readonly Lazy<IOpenViewPlatform> lazyImplementation = new(() => GeneratePlatform(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private readonly IOpenViewPlatform OpenViewPlatform = lazyImplementation.Value;

        private static IOpenViewPlatform GeneratePlatform()
        {
            return PullPlatformImplementation();


            static IOpenViewPlatform PullPlatformImplementation()
            {
#if ANDROID
            return new OpenViewMaui.Platforms.Android.OpenViewAndroid();
#elif IOS
            return new OpenViewMaui.Platforms.iOS.OpenViewiOS();
#elif MACCATALYST
            
#elif WINDOWS
            
#endif

                throw new PlatformNotSupportedException();
            }
        }

        public OpenViewPage PageView;

        public Action<object> CallBack;

        public OpenView(OpenViewPage page, Action<object> callback = null)
        {
            PageView = page;
            PageView.BackgroundColor = Color.FromArgb("#01000000");
            PageView.OpenView = this;
            CallBack = callback;
        }

        public async Task Show()
        {
            if (_isShow) return; _isShow = true;
            await OpenViewPlatform.AddAsync(PageView);
        }

        public async Task Hide(object obj = null)
        {
            if (!_isShow) return; _isShow = false;
            await OpenViewPlatform.RemoveAsync(PageView);
            if (obj != null)
            {
                CallBack?.Invoke(obj);
            }

        }

    }
}