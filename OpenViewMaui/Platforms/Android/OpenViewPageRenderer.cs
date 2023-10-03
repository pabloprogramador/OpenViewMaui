﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.Content;
using Android.Graphics;
using Android.Views;

using Microsoft.Maui.Platform;

using AndroidGraphics = Android.Graphics; //Weird conflict with Microsoft namespace?
using AndroidView = Android.Views;

using Android.OS;
using Rect = Microsoft.Maui.Graphics.Rect;

namespace OpenViewMaui.Platforms.Android
{
    public class OpenViewPageRenderer : ContentViewGroup
    {
        public OpenViewPageHandler OpenViewHandler;

        //private readonly MopupGestureDetectorListener _gestureDetectorListener;
        //private readonly GestureDetector _gestureDetector;
        //private DateTime _downTime;
        //private Microsoft.Maui.Graphics.Point _downPosition;
        //private bool _disposed;

        public OpenViewPageRenderer(Context context) : base(context)
        {
        }

        //_gestureDetectorListener = new MopupGestureDetectorListener();
        //_gestureDetectorListener.Clicked += OnBackgroundClick;

        //_gestureDetector = new GestureDetector(Context, _gestureDetectorListener);


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _disposed = true;

        //        //_gestureDetectorListener.Clicked -= OnBackgroundClick;
        //        //_gestureDetectorListener.Dispose();
        //        //_gestureDetector.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}

        //protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        //{
        //    try
        //    {
        //        var activity = Platform.CurrentActivity;
        //        var decoreView = activity?.Window?.DecorView;

        //        Thickness systemPadding;
        //        var keyboardOffset = 0d;

        //        var visibleRect = new AndroidGraphics.Rect();

        //        decoreView?.GetWindowVisibleDisplayFrame(visibleRect);

        //        if (Build.VERSION.SdkInt >= BuildVersionCodes.M && RootWindowInsets != null)
        //        {
        //            var h = bottom - top;

        //            var windowInsets = RootWindowInsets;
        //            var bottomPadding = Math.Min(windowInsets.StableInsetBottom, windowInsets.SystemWindowInsetBottom);

        //            if (h - visibleRect.Bottom > windowInsets.StableInsetBottom)
        //            {
        //                keyboardOffset = Context.FromPixels(h - visibleRect.Bottom);
        //            }

        //            systemPadding = new Thickness
        //            {
        //                Left = Context.FromPixels(windowInsets.SystemWindowInsetLeft),
        //                Top = Context.FromPixels(windowInsets.SystemWindowInsetTop),
        //                Right = Context.FromPixels(windowInsets.SystemWindowInsetRight),
        //                Bottom = Context.FromPixels(bottomPadding)
        //            };
        //        }
        //        else if (Build.VERSION.SdkInt < BuildVersionCodes.M && decoreView != null)
        //        {
        //            var screenSize = new AndroidGraphics.Point();
        //            activity?.WindowManager?.DefaultDisplay?.GetSize(screenSize);

        //            var keyboardHeight = 0d;

        //            var decoreHeight = decoreView.Height;
        //            var decoreWidht = decoreView.Width;

        //            if (visibleRect.Bottom < screenSize.Y)
        //            {
        //                keyboardHeight = screenSize.Y - visibleRect.Bottom;
        //                keyboardOffset = Context.FromPixels(decoreHeight - visibleRect.Bottom);
        //            }

        //            systemPadding = new Thickness
        //            {
        //                Left = Context.FromPixels(visibleRect.Left),
        //                Top = Context.FromPixels(visibleRect.Top),
        //                Right = Context.FromPixels(decoreWidht - visibleRect.Right),
        //                Bottom = Context.FromPixels(decoreHeight - visibleRect.Bottom - keyboardHeight)
        //            };
        //        }
        //        else
        //        {
        //            systemPadding = new Thickness();
        //        }

        //        //(OpenViewHandler.VirtualView as OpenViewPage).SetValue(OpenViewPage.SystemPaddingProperty, systemPadding);
        //        //(OpenViewHandler.VirtualView as OpenViewPage).SetValue(OpenViewPage.KeyboardOffsetProperty, keyboardOffset);

        //        if (changed)
        //            (OpenViewHandler.VirtualView as OpenViewPage).Layout(new Rect(Context.FromPixels(left), Context.FromPixels(top), Context.FromPixels(right), Context.FromPixels(bottom)));
        //        else
        //            (OpenViewHandler.VirtualView as OpenViewPage).ForceLayout();
        //        base.OnLayout(changed, left, top, right, bottom);
        //        //base.OnLayout(changed, 20, 500, 1080, 2000);
        //        //base.OnLayout(changed, visibleRect.Left, visibleRect.Top, visibleRect.Right, visibleRect.Bottom);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //protected override void OnAttachedToWindow()
        //{
        //    //var activity = Platform.CurrentActivity;
        //    //var decoreView = activity?.Window?.DecorView;
        //    //activity?.Window?.SetSoftInputMode(SoftInput.AdjustResize);
        //    //Context.HideKeyboard(decoreView);
        //    base.OnAttachedToWindow();
        //}

        //protected override void OnDetachedFromWindow()
        //{
        //    Device.StartTimer(TimeSpan.FromMilliseconds(0), () =>
        //    {
        //        var activity = Platform.CurrentActivity;
        //        var decoreView = activity?.Window?.DecorView;
        //        Context.HideKeyboard(decoreView);
        //        return false;
        //    });

        //    base.OnDetachedFromWindow();
        //}

        //TODO VERIFICAR DEPOIS
        //protected override void OnWindowVisibilityChanged(ViewStates visibility)
        //{
        //    base.OnWindowVisibilityChanged(visibility);

        //    // It is needed because a size of popup has not updated on Android 7+. See #209
        //    if (visibility == ViewStates.Visible)
        //        RequestLayout();
        //}


        //public override bool DispatchTouchEvent(MotionEvent e)
        //{
        //    if (_disposed)
        //    {
        //        return false;
        //    }
        //    if ((OpenViewHandler.VirtualView as OpenViewPage).BackgroundInputTransparent)
        //    {
        //        return base.DispatchTouchEvent(e);
        //    }

        //    base.DispatchTouchEvent(e);

        //    return true;
        //}


        //public override bool OnTouchEvent(MotionEvent e)
        //{
        //    try
        //    {
        //        if (_disposed)
        //            return false;

        //        var baseValue = base.OnTouchEvent(e);

        //        _gestureDetector.OnTouchEvent(e);

        //        if ((PopupHandler?.VirtualView as PopupPage).BackgroundInputTransparent)
        //        {
        //            if ((ChildCount > 0 && !IsInRegion(e.RawX, e.RawY, PopupHandler?.PlatformView.GetChildAt(0)!)) || ChildCount == 0)
        //            {
        //                (PopupHandler?.VirtualView as PopupPage).SendBackgroundClick();

        //                return false;
        //            }
        //        }

        //        return baseValue;
        //    }
        //    catch (Exception f)
        //    {
        //    }

        //    return base.OnTouchEvent(e);
        //}

        //private bool IsInRegion(float x, float y, AndroidView.View v)
        //{
        //    var mCoordBuffer = new int[2];

        //    v.GetLocationOnScreen(mCoordBuffer);
        //    return mCoordBuffer[0] + v.Width > x &&    // right edge
        //           mCoordBuffer[1] + v.Height > y &&   // bottom edge
        //           mCoordBuffer[0] < x &&              // left edge
        //           mCoordBuffer[1] < y;                // top edge
        //}

        //private async void OnBackgroundClick(object sender, MotionEvent e)
        //{
        //    if (ChildCount == 0)
        //        return;

        //    var isInRegion = IsInRegion(e.RawX, e.RawY, PopupHandler.PlatformView.GetChildAt(0));

        //    if (!isInRegion)
        //    {
        //        (PopupHandler.VirtualView as PopupPage).SendBackgroundClick();
        //    }
        //}
    }
}