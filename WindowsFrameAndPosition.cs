#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;

#endregion

namespace sysinfo;

internal class WindowsFrameAndPosition
{
    private static extern int
        DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref uint pvAttribute, int cbAttribute);

    public static void NakedWindow(IntPtr hWnd)
    {
        var style = GetWindowLong(hWnd, Win32Index.STYLE);
        var nakedWindowResut = SetWindowLong(hWnd, Win32Index.STYLE, (int)(style & ~WindowStyles.OVERLAPPEDWINDOW));
        if (nakedWindowResut == 0) throw new Exception("Failed to remove window frame.");

        var windowPos = SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, WindowPositionFlags.NOCHANGE);
        if (!windowPos) throw new Exception("Failed to remove window frame.");
    }

    [DllImport (DllReferences.User32)]
#pragma warning disable SYSLIB1050
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
        uint uFlags);

    //private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    private static extern bool GetCursorPos(out Point lpPoint);
    [DllImport(DllReferences.User32)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    [DllImport(DllReferences.User32)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
#pragma warning restore SYSLIB1050
//        [LibraryImport(DllReferences.Dwmapi)]
//        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
//#pragma warning disable SYSLIB1050
}