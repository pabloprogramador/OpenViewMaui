using UIKit;

namespace OpenViewMaui.Platforms.iOS
{
	internal class OpenViewPageRenderer : UIViewController
	{
		public OpenViewPageRenderer(OpenViewPageHandler handler)
		{
		}

        public OpenViewPageRenderer(IntPtr handle) : base(handle)
        {
        }

    }
}