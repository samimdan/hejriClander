#region

using System;
using System.Drawing;
using System.Numerics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using WinRT.Interop;
using Color = Windows.UI.Color;

#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{
    private readonly BitmapImage _bitmapImage;
    private readonly DispatcherTimer _dispatcherTimer = new();
    private readonly DispatcherTimer _dateTime;
    private Point _clickOffset;

    private bool _isDragging;

    /* ------------------------------- MainWindow Constructor ------------------------------- */
    public MainWindow()

    {
        InitializeComponent();
      
        var hwnd = WindowNative.GetWindowHandle(this);
       // WindowAppearanceController.SetWindowsSize(this, 230, 1000);
        WindowAppearanceController.NakedWindow(hwnd);
        //WindowAppearanceController.SetTopMost(this, true);
        //WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);
        WindowAppearanceController.EnableBlur(hwnd,true);
        _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
        _dispatcherTimer.Tick += MoveWindowWhileDragging;

        _bitmapImage = new BitmapImage(FunnyGif.Morning);
        //FunnyStateGif.ImageSource = _bitmapImage;
        //ApplyBlur funnyGiftBlur = new(ImageShadowContainer, Color.FromArgb(128, 0, 0, 0), 35.0f, .2f,
          //  new Vector3(0, 4, 0));
        //WindowAppearanceController.RestoreDwmRendering(hwnd);
       // funnyGiftBlur.AddDropShadow();
        _dateTime = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _dateTime.Tick += (sender, e) => {
           var hour = DateTime.Now.Hour % 12;
            if (hour == 0) hour = 12;

            HourTb.Text = hour.ToString();
            MinuteTb.Text = DateTime.Now.Minute.ToString();
            SecondTb.Text = DateTime.Now.ToString("ss");
            TtTb.Text = DateTime.Now.Hour >= 12 ? "PM" : "AM";
            SecondAnimation.Begin();
        };
        _dateTime.Start();
    }


    public void HandleGridPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        _isDragging = true;
        _bitmapImage.UriSource = FunnyGif.SusageSit;
        var positionInElement = e.GetCurrentPoint((UIElement)sender).Position;
        _clickOffset = new Point((int)positionInElement.X, (int)positionInElement.Y);
        _dispatcherTimer.Start();
    }


    public void MoveWindowWhileDragging(object? sender, object e)
    {
        if (!_isDragging) return;
        var mouse = MouseController.GetMousePosition();
        WindowAppearanceController.SetWindowsPosition(this, mouse.X - _clickOffset.X, mouse.Y - _clickOffset.Y);
    }

    public void HandleGridPointerRelased(object sender, PointerRoutedEventArgs e)
    {
        _isDragging = false;
        _bitmapImage.UriSource = FunnyGif.GetRandomGif();
        _dispatcherTimer.Stop();
    }
}