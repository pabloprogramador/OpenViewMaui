namespace OpenViewMaui.Sample;

public partial class MainPage : ContentPage
{
	
	private OpenViewMaui.OpenView openView;

	public MainPage()
	{
		InitializeComponent();
        openView = new OpenViewMaui.OpenView(new ItemPage());
    }

	private void OnOpen(object sender, EventArgs e)
	{
		openView.Show();
	}

    private void OnClose(object sender, EventArgs e)
    {
        openView.Hide();
    }

    private void OnOpenPage1(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(Page1));
    }
}


