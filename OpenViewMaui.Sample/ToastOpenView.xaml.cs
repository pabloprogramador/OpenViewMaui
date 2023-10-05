namespace OpenViewMaui.Sample;

public partial class ToastOpenView : OpenViewPage
{
    public ToastOpenView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
        pgGrid.Opacity = 0;
        pgGrid.TranslationY = -300;
        pgGrid.FadeTo(1, 500);
        pgGrid.TranslateTo(0, 30, 1000, Easing.SpringOut);
    }

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        pgGrid.FadeTo(0, 500);
        await pgGrid.TranslateTo(0, -300, 500, Easing.SpringIn);
        OpenView.Hide();
    }
}
