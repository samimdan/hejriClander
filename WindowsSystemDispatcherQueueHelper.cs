using Windows.System;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Dispatching;
using System;
using System.Runtime.InteropServices;

public class WindowsSystemDispatcherQueueHelper
{
    [StructLayout(LayoutKind.Sequential)]
    struct DispatcherQueueOptions
    {
        public int dwSize;
        public int threadType;
        public int apartmentType;
    }

    [DllImport("CoreMessaging.dll")]
    private static extern int CreateDispatcherQueueController(
        DispatcherQueueOptions options,
        out IntPtr dispatcherQueueController);

    private IntPtr _dispatcherQueueController;

    public void EnsureWindowsSystemDispatcherQueueController()
    {
        if (Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread() != null)
            return;

        DispatcherQueueOptions options = new DispatcherQueueOptions
        {
            dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions)),
            threadType = 2,    // DQTYPE_THREAD_CURRENT
            apartmentType = 2  // DQTAT_COM_STA
        };

        CreateDispatcherQueueController(options, out _dispatcherQueueController);
    }
}
