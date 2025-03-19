using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sysinfo
{
    internal  class WindowsFrameAndPosition
    {
        [LibraryImport(DllReferences.User32)]
        #pragma warning disable SYSLIB1050
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        private static extern bool GetCursorPos(out Point lpPoint);
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    #pragma warning restore SYSLIB1050
        [LibraryImport(DllReferences.Dwmapi)]
#pragma warning disable SYSLIB1050
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref uint pvAttribute, int cbAttribute);

#pragma warning restore SYSLIB1050


    }
}
