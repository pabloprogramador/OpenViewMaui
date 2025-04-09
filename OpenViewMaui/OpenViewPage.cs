using System;
using Microsoft.Maui.Controls.PlatformConfiguration;
#if IOS
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
#endif
namespace OpenViewMaui
{
	public class OpenViewPage : ContentPage
	{
        public OpenView OpenView;

        public OpenViewPage()
		{
#if IOS
            On<iOS>().SetUseSafeArea(false);
#endif
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}

