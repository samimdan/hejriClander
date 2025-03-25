#region

using System;
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

    public static void MakeWindowTransparent(IntPtr hWnd)
    {



        int extendedStyle = GetWindowLong(hWnd, Win32Index.EXSTYLE);
        SetWindowLong(hWnd, Win32Index.EXSTYLE, extendedStyle | WindowLayeredOptions.EXLAYERS);
        SetLayeredWindowAttributes(hWnd, 0, 0, WindowLayeredOptions.COLORKEY);
    }
    public static void EnableBlur(IntPtr hwnd, bool useAcrylic = true)
    {
        var accent = new ACCENT_POLICY
        {
            AccentState = useAcrylic
                ? ACCENT_STATE.ACCENT_ENABLE_ACRYLICBLURBEHIND
                : ACCENT_STATE.ACCENT_ENABLE_BLURBEHIND,
            GradientColor = unchecked((int)0xCC1E1E1E)
        };

        int size = Marshal.SizeOf(accent);
        IntPtr accentPtr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(accent, accentPtr, false);

        var data = new WINDOWCOMPOSITIONATTRIBDATA
        {
            Attribute = WINDOWCOMPOSITIONATTRIB.WCA_ACCENT_POLICY,
            SizeOfData = size,
            Data = accentPtr
        };

        SetWindowCompositionAttribute(hwnd, ref data);
        Marshal.FreeHGlobal(accentPtr);

        // DWM - corner radius & rendering policy
        uint cornerPref = 2; // DWMWCP_ROUND
        DwmSetWindowAttribute(hwnd, 33, ref cornerPref, sizeof(uint));

        uint ncRenderingEnabled = 2; // DWMNCRP_ENABLED
        DwmSetWindowAttribute(hwnd, 2, ref ncRenderingEnabled, sizeof(uint));

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

}
