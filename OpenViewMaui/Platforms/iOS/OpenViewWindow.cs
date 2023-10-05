using System;
using CoreGraphics;
using SpriteKit;
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
            var platformHandler = (OpenViewPageRenderer?)RootViewController;
            var renderer = platformHandler?.Handler;
            var hitTestResult = base.HitTest(point, uievent);

            if (!(platformHandler?.Handler?.VirtualView is OpenViewPage formsElement))
                return null;

            if (renderer?.PlatformView == hitTestResult)
                return null;

            return hitTestResult;

        }
    }
}

