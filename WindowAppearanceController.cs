#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.UI.Windowing;
using Windows.Media.Devices.Core;

#endregion

namespace sysinfo;

internal class WindowAppearanceController
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
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

    public static void SetTopMost(MainWindow window)
    {
        var presenter = window.AppWindow.Presenter as OverlappedPresenter;
        if (presenter != null) presenter.IsAlwaysOnTop = true;
    }
    public static Point GetCursorPosition()
    {
        GetCursorPos(out var point);
        return point;
    }

    [DllImport(DllReferences.User32)]
#pragma warning disable SYSLIB1054
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
#pragma warning restore SYSLIB1054
        uint uFlags);

    [DllImport(DllReferences.User32)]
#pragma warning restore SYSLIB1054
#pragma warning disable SYSLIB1054
    private static extern bool GetCursorPos(out Point lpPoint);
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
#pragma warning restore SYSLIB1054
}
