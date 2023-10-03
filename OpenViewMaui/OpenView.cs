using System;
using OpenViewMaui.Contracts;

namespace OpenViewMaui
{
    public class OpenView
    {
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
            
#elif MACCATALYST
            
#elif WINDOWS
            
#endif

                throw new PlatformNotSupportedException();
            }
        }

        public OpenView(OpenViewPage contentPage)
        {
            OpenViewPlatform.AddAsync(contentPage);
        }

        public void Close()
        {

        }
    }
}