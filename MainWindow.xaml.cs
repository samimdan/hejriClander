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
using Microsoft.Foundation;

namespace sysinfo
{

    public sealed partial class MainWindow : Window
    {
    
        

        /* ------------------------------- MainWindow Constructor ------------------------------- */
        public MainWindow()
        {
            InitializeComponent();
           
            var hwnd = WindowNative.GetWindowHandle(this);
            WindowAppearanceController.NakedWindow(hwnd);
            WindowAppearanceController.SetTopMost(this,true);
            WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);
            var point= MouseController.RetrieveMousePosition();
            WindowAppearanceController.SetWindowsPosition(this,point.X,point.Y);

           



        }
    }
}