using Mopups.Pages;
using Mopups.Services;

namespace OpenViewMaui.Sample;

public partial class LixoPopup : PopupPage
{
	public LixoPopup()
	{
		InitializeComponent();
	}

    void OnBack(System.Object sender, System.EventArgs e)
    {
        //MopupService.Instance.PopAllAsync();
        MopupService.Instance.PopAsync();
    }
}
