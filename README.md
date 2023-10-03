# Open View Maui
A simple plugin to open a page on above of everything, it sits on top of the navigation and modules, with it you have the freedom to create a toast, popup, dialog, tips or window that opens over the entire application.

Thanks [lis](https://github.com/lisleitora) , [latinosamuel](https://github.com/latinosamuel) , [nuno](https://www.linkedin.com/in/nunomir/) , [flipper09112](https://github.com/flipper09112) , [LuckyDucko](https://github.com/LuckyDucko)
for inspiring this project.

The library consists of one NuGet packages:

[![NuGet](https://img.shields.io/nuget/v/OpenViewMaui.svg?label=OpenViewMaui)](https://www.nuget.org/packages/OpenViewMaui/)

[Sample](https://github.com/pabloprogramador/OpenViewMaui/tree/main/OpenViewMaui.Sample)

To use, simply install the package and add use to your builder:
```javascript
var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UseOpenViewMaui()
```

<img src="imagens/open2.gif" height="400">

You can use the OpenView:
```javascript
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
```
