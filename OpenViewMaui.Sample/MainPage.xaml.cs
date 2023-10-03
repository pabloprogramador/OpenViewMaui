namespace OpenViewMaui.Sample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		var openView = new OpenViewMaui.OpenView(new ItemPage());
	}
}


