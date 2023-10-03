using Android.Content;
using Microsoft.Maui.Platform;

namespace OpenViewMaui.Platforms.Android
{
    public class OpenViewPageRenderer : ContentViewGroup
    {
        public OpenViewPageHandler OpenViewHandler;

        public OpenViewPageRenderer(Context context) : base(context)
        {
        }
    }
}