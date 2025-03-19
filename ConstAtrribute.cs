using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysinfo
{//This file contains the enums and constants used in the MainWindow.xaml.cs file
    /// <summary>
    /// Contains constants for various DWM (Desktop Window Manager) window attributes.
    /// These attributes can be used with the DwmSetWindowAttribute and DwmGetWindowAttribute functions
    /// to modify or retrieve the properties of a window's non-client area.
    /// </summary>
    //internal static class DwmWindowAttributes
    //{
    //    // Class definition
    //}
         
     }

internal static class DwmColorizationColor
{
    public const int DWM_COLORIZATION_COLOR = 0;
    public const int DWM_COLORIZATION_AFTERGLOW = 1;
    public const int DWM_COLORIZATION_COLOR_BALANCE = 2;
    public const int DWM_COLORIZATION_AFTERGLOW_BALANCE = 3;
    public const int DWM_COLORIZATION_BLUR_BALANCE = 4;
    public const int DWM_COLORIZATION_GLASS_REFLECTION_INTENSITY = 5;
    public const int DWM_COLORIZATION_OPACITY = 6;
    public const int DWM_COLORIZATION_RED = 7;
    public const int DWM_COLORIZATION_GREEN = 8;
    public const int DWM_COLORIZATION_BLUE = 9;
    public const int DWM_COLORIZATION_OPACITY_MASK = 10;
    public const int DWM_COLORIZATION_COLORIZATION_COLOR = 11;
    public const int DWM_COLORIZATION_COLORIZATION_AFTERGLOW = 12;
    public const int DWM_COLORIZATION_COLORIZATION_COLOR_BALANCE = 13;
    public const int DWM_COLORIZATION_COLORIZATION_AFTERGLOW_BALANCE = 14;
    public const int DWM_COLORIZATION_COLORIZATION_BLUR_BALANCE = 15;
    public const int DWM_COLORIZATION_COLORIZATION_GLASS_REFLECTION_INTENSITY = 16;
    public const int DWM_COLORIZATION_COLORIZATION_OPACITY = 17;
    public const int DWM_COLORIZATION_COLORIZATION_RED = 18;
    public const int DWM_COLORIZATION_COLORIZATION_GREEN = 19;
    public const int DWM_COLORIZATION_COLORIZATION_BLUE = 20;
    public const int DWM_COLORIZATION_COLORIZATION_OPACITY_MASK = 21;
    public const int DWM_COLORIZATION_LAST = 22;
   
}
public static class WindowStyles
{
    public const long WS_BORDER = 0x00800000L; // The window has a thin-line border.
    public const long WS_CAPTION = 0x00C00000L; // The window has a title bar (includes the WS_BORDER style).
    public const long WS_CHILD = 0x40000000L; // The window is a child window.
    public const long WS_CHILDWINDOW = WS_CHILD; // Same as the WS_CHILD style.
    public const long WS_CLIPCHILDREN = 0x02000000L; // Excludes child window areas when drawing.
    public const long WS_CLIPSIBLINGS = 0x04000000L; // Clips child windows relative to each other.
    public const long WS_DISABLED = 0x08000000L; // The window is initially disabled.
    public const long WS_DLGFRAME = 0x00400000L; // The window has a dialog-box style border.
    public const long WS_GROUP = 0x00020000L; // The window is the first control of a group.
    public const long WS_HSCROLL = 0x00100000L; // The window has a horizontal scroll bar.
    public const long WS_ICONIC = 0x20000000L; // The window is initially minimized.
    public const long WS_MAXIMIZE = 0x01000000L; // The window is initially maximized.
    public const long WS_MAXIMIZEBOX = 0x00010000L; // The window has a maximize button.
    public const long WS_MINIMIZE = 0x20000000L; // The window is initially minimized.
    public const long WS_MINIMIZEBOX = 0x00020000L; // The window has a minimize button.
    public const long WS_OVERLAPPED = 0x00000000L; // The window is an overlapped window.
    public const long WS_POPUP = 0x80000000L; // The window is a pop-up window.
    public const long WS_SIZEBOX = 0x00040000L; // The window has a sizing border.
    public const long WS_SYSMENU = 0x00080000L; // The window has a system menu.
    public const long WS_TABSTOP = 0x00010000L; // The window can receive focus with TAB key.
    public const long WS_THICKFRAME = 0x00040000L; // The window has a sizing border.
    public const long WS_TILED = WS_OVERLAPPED; // The window is an overlapped window.
    public const long WS_VISIBLE = 0x10000000L; // The window is initially visible.
    public const long WS_VSCROLL = 0x00200000L; // The window has a vertical scroll bar.

    public const long WS_OVERLAPPEDWINDOW =
        (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX); // Overlapped window.

    public const long WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW; // Same as WS_OVERLAPPEDWINDOW.

    public const long WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU); // Pop-up window.

}

internal static class DwmColorizationColorBalance
{
    public const uint DWMWA_COLOR_NONE = 0xFFFFFFFE;
    public const int DWM_COLORIZATION_AFTERGLOW_BALANCE = 1;
    public const int DWM_COLORIZATION_BLUR_BALANCE = 2;
    public const int DWM_COLORIZATION_GLASS_REFLECTION_INTENSITY = 3;
    public const int DWM_COLORIZATION_LAST = 4;
}

internal static class DwmNcRenderingPolicy
{
    public const int DWMNCRP_USEWINDOWSTYLE = 0;
    public const int DWMNCRP_DISABLED = 1;
    public const int DWMNCRP_ENABLED = 2;
    public const int DWMNCRP_LAST = 3;
}

internal static class DwmWindowCornerPreference
{
 public const int DEFAULT = 0;
 public const int  DONOTROUND = 1;
 public const int  ROUND = 2;
 public const int  ROUNDSMALL = 3;
}

internal static class PvAttribute
{
    public const int PVATRUE = 1;
    public const int PVAFALSE = 0;
}

internal static class DwmWindowBackdropType{
 public const int DWMSBT_AUTO=1;
 public const int DWMSBT_NONE=2;
 public const int DWMSBT_MAINWINDOW=3;
 public const int DWMSBT_TRANSIENTWINDOW=4;
 public const int DWMSBT_TABBEDWINDOW=5;
}
internal static class Win32Index
{
    /// <summary>
    /// Retrieves or sets the window procedure.
    /// </summary>
    public const int WNDPROC = -4;
    ///<summary>
    /// Retrieves or sets the application instance handle.
    /// </summary>
    public const int INSTANCE = -6;
    ///<summary>
    /// Retrieves or sets the parent window handle.
    /// </summary>
    public const int PARENT = -8;
    /// <summary>
    /// Retrieves or sets the window styles.
    /// </summary>
    public const int STYLE = -16;
    ///<summary>
    /// Retrieves or sets the extended window styles.
    /// </summary>
    public const int EXSTYLE = -20;
    ///<summary>
    /// Retrieves or sets the user data associated with the window.
    /// </summary>
    public const int USERDATA = -21;
    /// <summary>
    /// Retrieves or sets the window identifier.
    /// </summary>
    public const int ID = -12;
}
