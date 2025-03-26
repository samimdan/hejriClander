#region

using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using WinRT.Interop;
using Color = Windows.UI.Color;
using Microsoft.UI.Composition.SystemBackdrops;
using WinRT;
#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{
    private readonly BitmapImage _bitmapImage;
    private readonly DispatcherTimer _dispatcherTimer = new();
    private readonly DispatcherTimer _dateTime;
    private Point _clickOffset;

    private bool _isDragging;
    Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration m_configurationSource;

    /* ------------------------------- MainWindow Constructor ------------------------------- */
    public MainWindow()

    {
        InitializeComponent();

        this.Activated += (e, s) =>
        {
            MainWindow_Activated(e, s);
            ApplyAcrylicEffect();
        };
        
        ApplyAcrylicEffect();

        var hwnd = WindowNative.GetWindowHandle(this);
       WindowAppearanceController.SetWindowsSize(this, 230, 1000);
       WindowAppearanceController.NakedWindow(hwnd);
        WindowAppearanceController.SetTopMost(this, true);
        WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);
        
        _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
        _dispatcherTimer.Tick += MoveWindowWhileDragging;

        _bitmapImage = new BitmapImage(FunnyGif.Morning);
        //FunnyStateGif.ImageSource = _bitmapImage;
        //ApplyBlur funnyGiftBlur = new(ImageShadowContainer, Color.FromArgb(128, 0, 0, 0), 35.0f, .2f,
          //  new Vector3(0, 4, 0));
        //WindowAppearanceController.RestoreDwmRendering(hwnd);
        //funnyGiftBlur.AddDropShadow();
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

    private void ApplyAcrylicEffect()
    {
        var desktopAcrylicBackdrop = new DesktopAcrylicBackdrop();
        this.SystemBackdrop = desktopAcrylicBackdrop;
        var acrylicController= new DesktopAcrylicController();
        acrylicController.Kind = DesktopAcrylicKind.Thin;
        acrylicController.TintColor = Color.FromArgb(2, 0, 0, 0); // Black color
        acrylicController.TintOpacity = 0.2f; // Set opacity
        m_configurationSource = new Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration();
        // Apply the controller to the backdrop
        acrylicController.AddSystemBackdropTarget(this.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
        acrylicController.SetSystemBackdropConfiguration(m_configurationSource);
    }

    private void MainWindow_Activated(object sender, WindowActivatedEventArgs e)
    {
        if (e.WindowActivationState == WindowActivationState.Deactivated)
        {
            // Do nothing when the window is deactivated
            Debug.WriteLine("deactive");
        }
        
        else
        {
            // Apply the effect when the window gains focus (active)
            Window.Current.Activate();
            ApplyAcrylicEffect();
            Debug.WriteLine("other active");
        }
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