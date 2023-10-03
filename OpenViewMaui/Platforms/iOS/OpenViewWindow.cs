using System;
using CoreGraphics;
using UIKit;

namespace OpenViewMaui.Platforms.iOS
{
	internal class OpenViewWindow : UIWindow
	{
        public OpenViewWindow(IntPtr handle) : base(handle)
        {
        }

        public OpenViewWindow()
		{
		}

        public OpenViewWindow(UIWindowScene uiWindowScene) : base(uiWindowScene)
        {

        }

        public override UIView HitTest(CGPoint point, UIEvent? uievent)
        {
            return null;
        }
    }
}

