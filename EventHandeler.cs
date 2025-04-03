#region

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{
    private static ManualResetEvent _suspendEvent = new(true);
    private static Stopwatch _stopwatch = new();
    private Thread _worker;

    
   
    private void TimerToggled(object sender, RoutedEventArgs e)

    {
        
        _worker = new Thread(WorkTimer);
        _worker.Start();
        _stopwatch.Start();

        if (TimerSwitch.IsOn)
        {
            ResumeThread();
        }
        else
        {
            SuspendThread();
            _stopwatch.Stop();
        }
    }

    private void WorkTimer()
    {
        while (true)

        {
            _suspendEvent.WaitOne();

            _dispatcherQueue.TryEnqueue(() =>


            {
                WorkerTimerTb.Text = _stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
            });
                

           
            Thread.Sleep(1000);
        }

        
        // ReSharper disable once FunctionNeverReturns
    }

    private void SuspendThread()
    {
        _suspendEvent.Reset();
        Debug.WriteLine("suspend Therad");
    }

    private static void ResumeThread()
    {
        _suspendEvent.Set();
        Debug.WriteLine("resume Therad");
    }
    private void ResetTimer_Click(object sender, RoutedEventArgs e)
    {
        _stopwatch.Restart();
    }
}