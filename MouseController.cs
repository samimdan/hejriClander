#region

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;
using Windows.Media.Core;

#endregion

namespace sysinfo;

internal class MouseController
{

   

    public static Point GetMousePosition()
    {
        GetCursorPos(out var lpPoint);
        return lpPoint;


    }

 
#pragma warning disable SYSLIB1054
        [DllImport(DllReferences.User32)]
    private static extern bool GetCursorPos(out Point lpPoint);
#pragma warning restore SYSLIB1054
}