using System;
using System.Threading.Tasks;

namespace OpenViewMaui
{
    public class BottomSheet : OpenView
    {

        public BottomSheet(BottomSheetView view, Action<object> callback = null) : base(new BottomSheetBase(view), callback)
        {
            view.BottomSheet = (BottomSheetBase)this.PageView;
        }

    }

    public class BottomSheetView : ContentView
    {
        public BottomSheetBase BottomSheet;

        public BottomSheetView()
        {

        }
    }

}