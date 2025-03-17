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
        /* ----------------------------------- API ---------------------------------- */
        [DllImport("user32.dll")]

        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("dwmapi.dll")]
        internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref uint pvAttribute, int cbAttribute);

        private const int GWL_STYLE = -16;
        private const int WS_POPUP = unchecked((int)0x80000000);
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

      
        /* --------------------------------- fields --------------------------------- */
        private struct Point
        {
            public int X, Y;
        }

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOZORDER = 0x0004;
        private bool isTopMost = true;
        private bool isMouseDown = false;
        private static Point mouseDownPos;
        private DispatcherTimer mouseTimer;
        private MicaBackdrop micaBackdrop;

        /* ------------------------------- MainWindow Constructor ------------------------------- */
        public MainWindow()
        {
            micaBackdrop = new MicaBackdrop();

            this.InitializeComponent();
            
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(null);

           // RemoveWindowFrame();
            SetWindowSize(250, 1000);
           RemoveTitleBar();
          //  RemoveWhiteBorder();
        ; mouseTimer = new DispatcherTimer
        {
             Interval = TimeSpan.FromMilliseconds(10)
            };
            mouseTimer.Tick += MoveWindow;
         

        }
     

        private void RemoveTitleBar()
        {

       

        }
        public void RemoveWhiteBorder()
        {
            var hWnd = WindowNative.GetWindowHandle(this);
            uint colorNone = 0;

            var result = DwmSetWindowAttribute(hWnd, DwmWindowAttributes.DWMWA_BORDER_COLOR, ref colorNone, sizeof(uint));
           
            if (result !=0)
            {
                // Handle error
                Debug.WriteLine($"DwmSetWindowAttribute failed with error code {result}");
            }
        }
        private void SetWindowSize(int width, int height)
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId windowID;
            windowID = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowID);
           
            appWindow.Resize(new SizeInt32(width, height));
        }

        /// <summary>
        /// Removes the window frame, including the border and title bar, from the current window.
        /// This method also prevents the window from being resized.
        /// </summary>
        private void RemoveWindowFrame()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            var windowID = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowID);

            if (appWindow.Presenter is not OverlappedPresenter presenter) return;
            presenter.SetBorderAndTitleBar(false, false); // Completely removes title bar and border
            presenter.IsResizable = false;
        }



        private void WindowMouseDown(object sender, PointerRoutedEventArgs e)
        {
            isMouseDown = true;
            var position = e.GetCurrentPoint(sender as UIElement).Position;
            mouseDownPos = new Point { X = (int)position.X, Y = (int)position.Y };
            mouseTimer?.Start();
        }

        private void WindowMouseLeave(object sender, PointerRoutedEventArgs e)
        {
            isMouseDown = false;
            mouseTimer?.Stop();
        }

        // Change the GetCursorPosition method to match the expected signature for the Tick event handler
        private void MoveWindow(object? sender, object e)

        {
            if (isMouseDown)
            {
                if (!GetCursorPos(out Point pointFromScreen)) return;
                var hWnd = WindowNative.GetWindowHandle(this);
                SetWindowPos(hWnd, IntPtr.Zero, pointFromScreen.X - mouseDownPos.X, pointFromScreen.Y - mouseDownPos.Y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
            }
            else
            {
                if (!GetCursorPos(out Point pointFromScreen)) return;
                var hWnd = WindowNative.GetWindowHandle(this);
                SetWindowPos(hWnd, HWND_TOPMOST, pointFromScreen.X - mouseDownPos.X, pointFromScreen.Y - mouseDownPos.Y, 0, 0, SWP_NOSIZE | SWP_NOMOVE);
            }

        }
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        
    }
}
