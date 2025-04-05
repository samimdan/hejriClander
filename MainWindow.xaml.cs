#region

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.UI.Composition;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

using WinRT;
using WinRT.Interop;
using Color = Windows.UI.Color;

#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{



    private readonly DispatcherTimer _dispatcherTimer = new();
    private Point _clickOffset;
    private bool _isDragging;
    private DispatcherQueue _dispatcherQueue;

    /* ------------------------------- MainWindow Constructor ------------------------------- */
    public MainWindow()
    {
        InitializeComponent();

        Activated += (e, s) =>
        {
            //MainWindow_Activated(e, s);
            ApplyAcrylicEffect();
        };
        TimerStart();
        PopulateWeatherInfo();
        PopulateDateInfo();
        StartBlinking("Blinking");
        FillIedaTb();
        
        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();
        GetDatafromApi.GetHollyTimesAsync();
        var amPm = DateTime.Now.Hour < 12 ? SunPosition.AM : SunPosition.PM;

        //var dateRespone = Task.Run(async () => await GetDatafromApi.FetchDataContentAsync()).Result;
      
        //DayNumTb.Text = Tools.ConvertPersianToEnglish(dateRespone.DateText);
        //DayOfWeekTb.Text = dateRespone.DayText;
        //MonthTb.Text = dateRespone.MonthText;
        OpenWeatherResponse weatherResponse = Task.Run(async () => await GetDatafromApi.GetWeatherDataAsync("Hamedan")).Result;
        // if (weatherResponse.Main.Temp != null) WeatherTb.Text = weatherResponse.Main.Temp?.ToString("0.0") + "°C";
        WeatherStates.WeatherStatesFill();


        var response = Task.Run(async () => await GetDatafromApi.FetchDataContentAsync()).Result;
        DayNumTb.Text = Tools.ConvertPersianToEnglish(response.DateText);
        DayOfWeekTb.Text = response.DayText;
        MonthTb.Text = response.MonthText;








        WeatherSample fillterdWeatherSamples = WeatherStates.GetWeatherSample(weatherResponse.Weather[0].Description, amPm);
        WeatherIcon.Source = new BitmapImage(new Uri(fillterdWeatherSamples.Image));
        
        Brush sunBrush = new SolidColorBrush(Color.FromArgb(255, 254, 240, 138));
        Brush moonBrush = new SolidColorBrush(Color.FromArgb(255, 254, 208, 254));
        var hwnd = WindowNative.GetWindowHandle(this);
        WindowAppearanceController.SetWindowsSize(this, 230, 1000);
        WindowAppearanceController.NakedWindow(hwnd);
        WindowAppearanceController.SetTopMost(this, true);
        WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);

        _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
        _dispatcherTimer.Tick += MoveWindowWhileDragging;


    }


    private void ApplyAcrylicEffect()
    {
        var desktopAcrylicBackdrop = new DesktopAcrylicBackdrop();
        SystemBackdrop = desktopAcrylicBackdrop;
        var acrylicController = new DesktopAcrylicController();
        acrylicController.Kind = DesktopAcrylicKind.Thin;
        acrylicController.TintColor = Color.FromArgb(1, 0, 0, 0); // Black color
        acrylicController.TintOpacity = 0f;
        acrylicController.LuminosityOpacity = 0.2f;
        //fall back color to transparent
        acrylicController.FallbackColor = Color.FromArgb(0, 0, 0, 0);

        // Set opacity
        var configurationSource = new SystemBackdropConfiguration();
        // Apply the controller to the backdrop
        acrylicController.AddSystemBackdropTarget(this.As<ICompositionSupportsSystemBackdrop>());
        acrylicController.SetSystemBackdropConfiguration(configurationSource);
    }


    public void HandleGridPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        _isDragging = true;

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

        _dispatcherTimer.Stop();
    }

  }