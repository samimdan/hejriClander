using System;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using System.Diagnostics;
using WinRT.Interop;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Input;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml.Media;
using System.Xml.Linq;
using Microsoft.UI;

namespace sysinfo
{

    public sealed partial class MainWindow : Window
    {
        


        /* ------------------------------- MainWindow Constructor ------------------------------- */
        public MainWindow()
        {
            this.InitializeComponent();
            var hwnd = WindowNative.GetWindowHandle(this);
            WindowAppearanceController.NakedWindow(hwnd);
            WindowAppearanceController.SetTopMost(this);
            WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);
            var  courserPosition = WindowAppearanceController.GetCursorPosition();
            Debug.WriteLine(courserPosition.X);
            Debug.WriteLine(courserPosition.Y);

        }





    }
}