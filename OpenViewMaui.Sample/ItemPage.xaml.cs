﻿namespace OpenViewMaui.Sample;

public partial class ItemPage : OpenViewPage
{
	public ItemPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		await this.OpenView.Hide("popup");
    }
}
