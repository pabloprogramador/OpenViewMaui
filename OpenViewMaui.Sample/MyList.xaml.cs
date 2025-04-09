namespace OpenViewMaui.Sample;

public partial class MyList : BottomSheetView
{


    public MyList()
	{
		InitializeComponent();

	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await this.BottomSheet.CloseBottomSheet("CallBack OK !!!");
    }
}
