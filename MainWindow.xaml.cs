#region

using System.Diagnostics;
using System.Drawing;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using WinRT.Interop;

#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{
    private readonly DispatcherTimer _dispatcherTimer = new();

    /* ------------------------------- MainWindow Constructor ------------------------------- */
    public MainWindow()
    {
        InitializeComponent();
        //set the width of the window
        WindowAppearanceController.SetWindowsSize(this, 300, 1000);
        var hwnd = WindowNative.GetWindowHandle(this);
        WindowAppearanceController.NakedWindow(hwnd);
        WindowAppearanceController.SetTopMost(this, true);
        WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);

        // Change this line to set the width of the window
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
