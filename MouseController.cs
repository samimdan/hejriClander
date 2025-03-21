#region

using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;

#endregion

namespace sysinfo;

internal class MouseController
{
 
    public static Point RetrieveMousePosition()
    {
        GetCursorPos(out var point);
        return point;
    }

    public void MouseTimer()
    {
        var MouseDispatcherTimer = new DispatcherTimer();
      

    }

#pragma warning disable SYSLIB1054
    [DllImport(DllReferences.User32)]
    private static extern bool GetCursorPos(out Point lpPoint);
#pragma warning restore SYSLIB1054
}
