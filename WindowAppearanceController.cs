#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Windows.Media.Devices.Core;

#endregion

namespace sysinfo;

internal class WindowAppearanceController
{
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

    public static void SetTopMost(IntPtr hWnd, bool pvAttribute)
    {
        var hWndInsertAfter = pvAttribute ? new IntPtr(-1) : new IntPtr(-2);
        var result = SetWindowPos(hWnd, hWndInsertAfter, 0, 0, 0, 0, WindowPositionFlags.TOPMOST);
        if (!result) throw new Exception("Failed to set window topmost.");
    }

    [DllImport(DllReferences.User32)]
#pragma warning disable SYSLIB1054
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
#pragma warning restore SYSLIB1054
        uint uFlags);

    private static extern bool GetCursorPos(out Point lpPoint);

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
