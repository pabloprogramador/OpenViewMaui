
namespace OpenViewMaui.Sample;

public partial class MainPage : ContentPage
{
	
	private OpenViewMaui.OpenView openView;

	public MainPage()
	{
		InitializeComponent();
        openView = new OpenViewMaui.OpenView(new ItemPage(), value =>
        {
            pgText.Text = (string)value;
        });
    }

	private async void OnOpen(object sender, EventArgs e)
	{
		await openView.Show();
	}

    private async void OnClose(object sender, EventArgs e)
    {
        await openView.Hide();
    }

    private async void OnOpenPage1(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(Page1));
    }

    private async void OnToast(object sender, EventArgs e)
    {
        var toast = new OpenViewMaui.OpenView(new ToastOpenView());
        await toast.Show();
    }

    async void OnOpenBottomSheet(System.Object sender, System.EventArgs e)
    {
        Action<object> callBack = value =>
        {
            pgText.Text = (string)value;
        };

        var bottomSheet = new BottomSheet(new MyList(), callBack);
        await bottomSheet.Show();
    }
}


