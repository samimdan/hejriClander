#region
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using System;
using System.Numerics;

using Windows.UI.Composition;
using Windows.Graphics.Imaging;
using System.Diagnostics;
using System.Drawing;
using Windows.Graphics.Capture;
using Microsoft.UI;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using WinRT.Interop;
using WinRT;

#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{
    private readonly DispatcherTimer _dispatcherTimer = new();
    private Microsoft.UI.Composition.SpriteVisual _spriteVisual;
    private Microsoft.UI.Composition.Compositor _compositor;
    /* ------------------------------- MainWindow Constructor ------------------------------- */
    public MainWindow()
    {
        InitializeComponent();
        //set the width of the window
        WindowAppearanceController.SetWindowsSize(this, 230, 1000);
        var hwnd = WindowNative.GetWindowHandle(this);
        WindowAppearanceController.NakedWindow(hwnd);
        WindowAppearanceController.SetTopMost(this, true);
        WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);
    }
    
    
    public void HandleGridPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        Point mousePosition; // Added declaration for mousePosition
        var mousePositionFromWindow = e.GetCurrentPoint((UIElement)sender);
        Debug.WriteLine(mousePositionFromWindow.Position.X);
        _dispatcherTimer.Tick += (s, m) =>
        {
            mousePosition = MouseController.GetMousePosition();
            WindowAppearanceController.SetWindowsPosition(this, mousePosition.X - (int)mousePositionFromWindow.Position.X, mousePosition.Y - (int)mousePositionFromWindow.Position.Y);
        };

        _dispatcherTimer.Start();
    }

    public void HandleGridPointerRelased(object sender, PointerRoutedEventArgs e)
    {
        _dispatcherTimer.Stop();
    }
}
