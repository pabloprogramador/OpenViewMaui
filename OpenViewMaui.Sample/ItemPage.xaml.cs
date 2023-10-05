namespace OpenViewMaui.Sample;

public partial class ItemPage : OpenViewPage
{
	public ItemPage()
	{
		InitializeComponent();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		this.OpenView.Hide();
    }
}
