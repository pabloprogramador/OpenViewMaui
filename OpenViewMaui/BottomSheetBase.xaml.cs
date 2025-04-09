using Microsoft.Maui.Controls.Shapes;

namespace OpenViewMaui;

public partial class BottomSheetBase : OpenViewPage
{
    public double BackgroundOpacity = .4;
    public bool AllowScrollToTop = true;

    bool _isCloseBlocked;
    double _sizeScroll;
    double _screenWidth;
    double _screenHeight;
    double _y;
    double _ypan;
    readonly double _headHeight = 280;
    readonly double _minFree = 70;
    bool _isFirst = true;
    double _baseY;

    public BottomSheetBase(BottomSheetView view, bool isCloseBlocked = false)
    {
        _isCloseBlocked = isCloseBlocked;

        InitializeComponent();

        AddedBottomMargin(view);
        pgViewContent.Add(view);
        pgBorderDrawer.BackgroundColor = view.BackgroundColor ?? Colors.White;

        pgRectangle.IsVisible = !_isCloseBlocked;

    }

    private static void AddedBottomMargin(BottomSheetView view)
    {
#if ANDROID
        var resourceId = Platform.CurrentActivity.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
        if (resourceId > 0)
        {
            var value = Platform.CurrentActivity.Resources.GetDimensionPixelSize(resourceId) / DeviceDisplay.Current.MainDisplayInfo.Density;

            view.Margin = new Thickness(0, 0, 0, value - 15);
        }
#endif
    }

    protected override bool OnBackButtonPressed()
    {
        if (!_isCloseBlocked)
            CloseBottomSheet();
        return true;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        if (_screenWidth > 0 && _screenHeight > 0)
        {
            return;
        }

        base.OnSizeAllocated(width, height);

        _screenWidth = width;
        _screenHeight = height;

        _isFirst = false;

        Open();
    }

    public async void Open()
    {
        pgGridDrawer.CancelAnimations();
        pgGridDrawer.TranslationY = _screenHeight + 50;
        if (_isFirst) { return; }

        while (pgScrollContent.Height < 0)
        {
            await Task.Delay(100).ConfigureAwait(true);
        }

        _sizeScroll = pgScrollContent.Height;
        _baseY = _screenHeight - Math.Max(pgScrollContent.Height + 100, _headHeight);
        _baseY = Math.Max(_baseY, 0);

        if (_baseY == 0)
        {
            pgScrollContent.HeightRequest = _screenHeight;
            pgScrollContent.ScrollToAsync(0, 0, false);
        }

        _y = _baseY;
        _ypan = 0;
        pgBackgroundGrid.CancelAnimations();
        pgBackgroundGrid.Opacity = 0;
        pgBackgroundGrid.FadeTo(.4, 500);
        pgGridDrawer.TranslateTo(0, _baseY, 500, Easing.CubicOut);
        await Task.Delay(300).ConfigureAwait(true);
        ChangeBorder(_baseY == 0);
    }

    public async Task CloseBottomSheet(object obj = null)
    {
        pgGridDrawer.CancelAnimations();
        pgBackgroundGrid.CancelAnimations();

        pgBackgroundGrid.FadeTo(0, 500);
        await pgGridDrawer.TranslateTo(0, _screenHeight + 50, 500, Easing.CubicOut).ConfigureAwait(true);
        await this.OpenView.Hide(obj);
        _y = pgGridDrawer.TranslationY;
        pgScrollContent.HeightRequest = _sizeScroll;
    }

    private double startedY;
    public async void PanGestureRecognizerPanUpdated(System.Object sender, Microsoft.Maui.Controls.PanUpdatedEventArgs e)
    {

        if (pgGridDrawer.AnimationIsRunning("TranslateTo")) { return; }

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                pgGridDrawer.CancelAnimations();
                startedY = pgGridDrawer.TranslationY;
                break;

            case GestureStatus.Running:
                double aux = Math.Max(_y + e.TotalY, 0);

                if (AllowScrollToTop)
                {
                    pgGridDrawer.TranslationY = aux;
                    pgImagePanGesture.TranslationY = _ypan - e.TotalY;
                }
                else if (_isCloseBlocked)
                {
                    pgGridDrawer.TranslationY = _baseY;
                    pgImagePanGesture.TranslationY = _ypan;
                }
                else
                {
                    pgGridDrawer.TranslationY = aux < _baseY ? _baseY : aux;
                    pgImagePanGesture.TranslationY = _ypan - e.TotalY;
                }

                ChangeBorder(pgGridDrawer.TranslationY == 0);
                break;

            case GestureStatus.Completed:
                pgImagePanGesture.TranslationY = _ypan = 0;
                if (startedY == 0 && _baseY > 0)
                {
                    if (pgGridDrawer.TranslationY - startedY < _minFree)
                    {
                        pgGridDrawer.TranslateTo(0, 0, 100, Easing.CubicOut);
                        ChangeBorder(true);
                        _y = 0;
                    }
                    else
                    {
                        await pgGridDrawer.TranslateTo(0, _baseY, 300, Easing.CubicOut).ConfigureAwait(true);
                        ChangeBorder(_baseY == 0);
                        _y = _baseY;
                    }
                }
                else
                {
                    if (_baseY == 0 && !_isCloseBlocked)
                    {
                        if (pgGridDrawer.TranslationY - startedY < _minFree)
                        {
                            pgGridDrawer.TranslateTo(0, 0, 100, Easing.CubicOut);
                            ChangeBorder(true);
                            _y = 0;
                        }
                        else
                        {
                            await CloseBottomSheet().ConfigureAwait(true);
                        }
                    }
                    else
                    {
                        if (pgGridDrawer.TranslationY - _baseY + (_minFree * 2) < _minFree)
                        {
                            if (AllowScrollToTop)
                            {
                                pgGridDrawer.TranslateTo(0, 0, 300, Easing.CubicOut);
                                await Task.Delay(100).ConfigureAwait(true);
                                ChangeBorder(true);
                                _y = 0;
                            }
                            else
                            {
                                await pgGridDrawer.TranslateTo(0, _baseY, 300, Easing.CubicOut).ConfigureAwait(true);
                                ChangeBorder(_baseY == 0);
                                _y = _baseY;
                            }
                        }
                        else
                        {

                            if (pgGridDrawer.TranslationY > _baseY && Math.Abs(pgGridDrawer.TranslationY - _baseY) > _minFree && !_isCloseBlocked)
                            {
                                await CloseBottomSheet().ConfigureAwait(true);
                            }
                            else
                            {
                                await pgGridDrawer.TranslateTo(0, _baseY, 100, Easing.CubicOut).ConfigureAwait(true);
                                ChangeBorder(_baseY == 0);
                                _y = _baseY;
                            }
                        }
                    }
                }
                break;
        }
    }

    public void PgBackgroundClicked(System.Object sender, System.EventArgs e)
    {
        if (!_isCloseBlocked)
            CloseBottomSheet();
    }

    private void ChangeBorder(bool isZero)
    {

        if (isZero)
        {
            pgBorderDrawer.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(0, 0, 0, 0)
            };
        }
        else
        {
            pgBorderDrawer.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(24, 24, 0, 0)
            };
        }
    }




//    /// <summary>
//    /// 
//    /// </summary>
//    public partial class BottomSheetBase : OpenViewPage
//{
//    public bool HasBackground = true;

//	public BottomSheetBase(BottomSheetView view)
//	{
//        InitializeComponent();

//        pgContentView.Add(view);

//        Init();
        
//        //view.CallBackReturn = new Command(async (object obj) =>
//        //{
//        //   await CloseBottomSheet(obj);
//        //});

//    }

//    public async void Init()
//    {

//        if (HasBackground)
//        {
//            await pgBackground.FadeTo(.4, 700);
//        }
//    }

//    public double BackgroundOpacity = .4;

//    bool isFirstCache;
//    double sizeScroll;
//    double screenWidth;
//    double screenHeight;
//    double y;
//    double ypan;
//    double headHeight = 280;
//    double minFree = 70;
//    bool isFull = false;
//    bool isFirst = true;
//    double baseY;

//    protected override void OnSizeAllocated(double width, double height)
//    {
//        base.OnSizeAllocated(width, height);
//        screenWidth = width;
//        screenHeight = height;
//        isFirst = false;
//        Open();
//    }

//    public async void Open()
//    {
//        pgBottomSheet.CancelAnimations();
//        pgBottomSheet.TranslationY = screenHeight + 50;
//        if (isFirst) return;


//        while (pgContentScroll.Height < 0)
//        {
//            await Task.Delay(100);
//        }

//        sizeScroll = pgContentScroll.Height;
//        baseY = screenHeight - Math.Max(pgContentScroll.Height + 32, headHeight);
//        baseY = Math.Max(baseY, 0);

//        if (baseY == 0)
//        {
//            pgContentScroll.HeightRequest = screenHeight;
//            pgContentScroll.ScrollToAsync(0, 0, false);
//        }

//        y = baseY;
//        ypan = 0;
//        pgBottomSheet.TranslateTo(0, baseY, 500, Easing.CubicOut);
//        await Task.Delay(300);
//        ChangeBorder(baseY == 0);
//    }

//    public async Task CloseBottomSheet(object obj = null)
//    {
//        pgBottomSheet.CancelAnimations();
//        pgBackground.FadeTo(0, 500);
//        await pgBottomSheet.TranslateTo(0, screenHeight + 50, 500, Easing.CubicOut);
//        y = pgBottomSheet.TranslationY;
//        pgContentScroll.HeightRequest = sizeScroll;
//        await this.OpenView.Hide(obj);
//    }


//    private double startedY = 0;
//    public async void PanGestureRecognizer_PanUpdated(System.Object sender, Microsoft.Maui.Controls.PanUpdatedEventArgs e)
//    {
//        if (pgBottomSheet.AnimationIsRunning("TranslateTo")) return;

//        switch (e.StatusType)
//        {
//            case GestureStatus.Started:
//                pgBottomSheet.CancelAnimations();
//                startedY = pgBottomSheet.TranslationY;
//                break;

//            case GestureStatus.Running:
//                //System.Diagnostics.Debug.WriteLine(y +" :: "+e.TotalY+" :: "+e.GestureId);
//                double aux = Math.Max(y + e.TotalY, 0);
//                pgBottomSheet.TranslationY = aux;
//                pgPanGesture.TranslationY = ypan - e.TotalY;
//                ChangeBorder(pgBottomSheet.TranslationY == 0);
//                break;

//            case GestureStatus.Completed:
//                pgPanGesture.TranslationY = ypan = 0;
//                if (startedY == 0 && baseY > 0)
//                {
//                    if (pgBottomSheet.TranslationY - startedY < minFree)
//                    {
//                        pgBottomSheet.TranslateTo(0, 0, 100, Easing.CubicOut);
//                        ChangeBorder(true);
//                        y = 0;
//                    }
//                    else
//                    {
//                        await pgBottomSheet.TranslateTo(0, baseY, 300, Easing.CubicOut);
//                        ChangeBorder(baseY == 0);
//                        y = baseY;
//                    }
//                }
//                else
//                {
//                    if (baseY == 0)
//                    {
//                        if (pgBottomSheet.TranslationY - startedY < minFree)
//                        {
//                            pgBottomSheet.TranslateTo(0, 0, 100, Easing.CubicOut);
//                            ChangeBorder(true);
//                            y = 0;
//                        }
//                        else
//                        {
//                            await CloseBottomSheet();
//                        }
//                    }
//                    else
//                    {
//                        if (pgBottomSheet.TranslationY - baseY + (minFree * 2) < minFree)
//                        {
//                            pgBottomSheet.TranslateTo(0, 0, 300, Easing.CubicOut);
//                            await Task.Delay(100);
//                            ChangeBorder(true);
//                            y = 0;
//                        }
//                        else
//                        {

//                            if (pgBottomSheet.TranslationY > baseY && Math.Abs(pgBottomSheet.TranslationY - baseY) > minFree)
//                            {
//                                await CloseBottomSheet();
//                            }
//                            else
//                            {
//                                await pgBottomSheet.TranslateTo(0, baseY, 100, Easing.CubicOut);
//                                ChangeBorder(baseY == 0);
//                                y = baseY;
//                            }
//                        }
//                    }
//                }
//                break;
//        }
//    }

//    public void pgBackground_Clicked(System.Object sender, System.EventArgs e)
//    {
//        CloseBottomSheet();
//    }

//    private void ChangeBorder(bool isZero)
//    {

//        if (isZero)
//        {
//            pgBottomSheetBorder.StrokeShape = new RoundRectangle
//            {
//                CornerRadius = new CornerRadius(0, 0, 0, 0)
//            };
//        }
//        else
//        {
//            pgBottomSheetBorder.StrokeShape = new RoundRectangle
//            {
//                CornerRadius = new CornerRadius(24, 24, 0, 0)
//            };
//        }
//    }
}