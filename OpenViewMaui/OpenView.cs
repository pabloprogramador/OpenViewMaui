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

        OpenViewPage _page;

        public OpenView(OpenViewPage page)
        {
            _page = page;
            _page.BackgroundColor = Color.FromArgb("#01000000");
            _page.OpenView = this;
        }

        public void Show()
        {
            if (_isShow) return; _isShow = true;
            OpenViewPlatform.AddAsync(_page);
        }

        public void Hide()
        {
            if (!_isShow) return; _isShow = false;
            OpenViewPlatform.RemoveAsync(_page);
        }
    }
}