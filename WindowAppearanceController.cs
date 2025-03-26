#region

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.ApplicationModel;
using Windows.Graphics;
using Windows.Media.Devices.Core;
using Windows.UI.WindowManagement;

#endregion

namespace sysinfo;

internal class WindowAppearanceController
{
    [StructLayout(LayoutKind.Sequential)]
    struct WINDOWCOMPOSITIONATTRIBDATA
    {
        public WINDOWCOMPOSITIONATTRIB Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }
    enum WINDOWCOMPOSITIONATTRIB
    {
        WCA_UNDEFINED = 0,
        WCA_ACCENT_POLICY = 19
    }

    public static void NakedWindow(IntPtr hWnd)
    {
        var style = GetWindowLong(hWnd, Win32Index.STYLE);
        var nakedWindowResut = SetWindowLong(hWnd, Win32Index.STYLE, (int)(style & ~WindowStyles.OVERLAPPEDWINDOW));
        if (nakedWindowResut == 0) throw new Exception("Failed to remove window frame.");

        var windowPos = SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, WindowPositionFlags.NOCHANGE);
        if (!windowPos) throw new Exception("Failed to remove window frame.");
    }

    public static void SetCornerRadius(IntPtr hWnd, int cornerRadius)
    {
        var pvAttribute = (uint)cornerRadius;
        var result = DwmSetWindowAttribute(hWnd, WindowCornerPreference.PREFERENCE, ref pvAttribute, sizeof(uint));
        if (result != 0) throw new Exception("Failed to set window corner radius.");
    }

    public static void SetTopMost(MainWindow window, bool isTopMost)
    {
        var presenter = window.AppWindow.Presenter as OverlappedPresenter;
        if (presenter != null) presenter.IsAlwaysOnTop = isTopMost;
    }
    public static void SetWindowsPosition(MainWindow window, int x, int y)
    {

        window.AppWindow.Move(new PointInt32 { X = x, Y = y });

    }
    public static void SetWindowsSize(MainWindow window, int width, int height)
    {
        window.AppWindow.Resize(new SizeInt32 { Width = width, Height = height });
    }


  
    public static void RestoreDwmRendering(IntPtr hwnd)
    {
        uint cornerPref = 2; // Rounded corners
        DwmSetWindowAttribute(hwnd, 33, ref cornerPref, sizeof(uint));

        uint ncRenderingEnabled = 2; // DWMNCRP_ENABLED
        DwmSetWindowAttribute(hwnd, 2, ref ncRenderingEnabled, sizeof(uint));
    }

    struct ACCENT_POLICY
    {
        public ACCENT_STATE AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    enum ACCENT_STATE
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
        ACCENT_ENABLE_HOSTBACKDROP = 5,
        ACCENT_INVALID_STATE = 6
    }

    public static void EnableBlurUsingUser32(IntPtr hwnd)
    {
        // Make the window layered
        int extendedStyle = GetWindowLong(hwnd, Win32Index.EXSTYLE);
        SetWindowLong(hwnd, Win32Index.EXSTYLE, extendedStyle | 0x00080000); // WS_EX_LAYERED

        // Set transparency (fully transparent)
        SetLayeredWindowAttributes(hwnd, 0, 0, WindowLayeredOptions.COLORKEY);

        // Apply the blur effect (DwmExtendFrameIntoClientArea)
        MARGINS margins = new MARGINS { Left = -1, Right = -1, Top = -1, Bottom = -1 }; // Apply blur to all edges
        DwmExtendFrameIntoClientArea(hwnd, ref margins);
    }
    public struct MARGINS
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }

    public static void ApplyBlurEffect(IntPtr hwnd)
    {
        MARGINS margins = new MARGINS { Left = -1, Right = -1, Top = -1, Bottom = -1 }; // Apply blur to all edges
        DwmExtendFrameIntoClientArea(hwnd, ref margins);
    }

    [DllImport(DllReferences.User32)]
#pragma warning disable SYSLIB1054
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
#pragma warning restore SYSLIB1054
        uint uFlags);



#pragma warning restore SYSLIB1054

    [DllImport(DllReferences.User32)]
#pragma warning disable SYSLIB1054
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
#pragma warning restore SYSLIB1054

    [DllImport(DllReferences.User32)]
#pragma warning disable SYSLIB1054
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
#pragma warning restore SYSLIB1054

    [DllImport(DllReferences.Dwmapi)]
    private static extern int
#pragma warning disable SYSLIB1054
        DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref uint pvAttribute, int cbAttribute);


    [DllImport(DllReferences.User32, SetLastError = true)]
    static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
#pragma warning restore SYSLIB1054
    [DllImport(DllReferences.User32)]
    static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WINDOWCOMPOSITIONATTRIBDATA data);
    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMargins);
}
