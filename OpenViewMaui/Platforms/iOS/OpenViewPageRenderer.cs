using CoreGraphics;
using Foundation;
using UIKit;

namespace OpenViewMaui.Platforms.iOS
{
	internal class OpenViewPageRenderer : UIViewController
	{
        private OpenViewPageHandler? _renderer;
        public OpenViewPageHandler? Handler => _renderer;

        public OpenViewPageRenderer(OpenViewPageHandler handler)
		{
            _renderer = handler;
        }

        public OpenViewPageRenderer(IntPtr handle) : base(handle)
        {
        }
    }
}