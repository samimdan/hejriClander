using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace sysinfo
{
    internal class Timer
    {
        private  DispatcherTimer _dispatcherTime;
        private readonly Date _workTimer;
        public Timer()
        {
            _dispatcherTime = new DispatcherTimer();
            _dispatcherTime.Tick += _dispatcherTime_Tick;
            _dispatcherTime.Interval=new TimeSpan(0, 0, 1);

        }

        private void _dispatcherTime_Tick(object? sender, object e)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {

        }
        public void Stop()
        {
        }
        public void Reset()
        {

        }
    }
}
