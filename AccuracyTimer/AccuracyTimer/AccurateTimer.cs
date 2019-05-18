using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccuracyTimer
{
    class AccurateTimer
    {
        private delegate void TimerEventDel(int id, int msg, IntPtr user, int dw1, int dw2);
        private const int TIME_PERIODIC = 1;
        private const int EVENT_TYPE = TIME_PERIODIC;// + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, TimerEventDel handler, IntPtr user, int eventType);
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);

        Action mAction;
        Form mForm;
        public int mTimerId;
        private TimerEventDel mHandler;  // NOTE: declare at class scope so garbage collector doesn't release it!!!
        Stopwatch stopWatch = null;
        bool fCalculateElapsedTime = false ;
        int iCounter = 0;
        //private Semaphore semaphore = null;
        bool IsInCallback = false;


        public AccurateTimer(Form form, Action action, int delay, bool fCalculateElapsedTime = false)
        {
            //semaphore = new Semaphore(1, 1);
            if (fCalculateElapsedTime == true)
            {
                stopWatch = new Stopwatch();
            }
            mAction = action;
            mForm = form;
            timeBeginPeriod(1);
            mHandler = new TimerEventDel(TimerCallback);
            mTimerId = timeSetEvent(delay, 0, mHandler, IntPtr.Zero, EVENT_TYPE);

            if (fCalculateElapsedTime == true)
            {
                stopWatch.Start();
            }
        }

        public bool IsReady()
        {
            return (IsInCallback == false) ;
        }
        public void Stop()
        {
            //semaphore.Release(); 
            //while (IsInCallback == true) ;
            int err = timeKillEvent(mTimerId);
            timeEndPeriod(1);
            mTimerId = 0;
            if (fCalculateElapsedTime == true)
            {
                stopWatch.Stop();
                stopWatch = null;
            }
            //System.Threading.Thread.Sleep(100);// Ensure callbacks are drained
        }

        public void ReleaseSemaphore()
        {
            try
            {
                //semaphore.Release();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
        {
            //semaphore.WaitOne();
            if (mTimerId != 0)
            {
                Stop();
                //IsInCallback = true;
                Trace.WriteLine("RunTime " + iCounter++.ToString());
                if (fCalculateElapsedTime == true)
                {
                    stopWatch.Stop();
                }
                
                mForm.BeginInvoke(mAction);
                
                if (fCalculateElapsedTime == true)
                {
                    ShowTimeElapsed();
                    stopWatch.Start();
                }
                IsInCallback = false;
            }
        }

        private void ShowTimeElapsed()
        {
            // Get the elapsed time as a TimeSpan value.
            if (fCalculateElapsedTime == true)
            {
                TimeSpan ts = stopWatch.Elapsed;
                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                Trace.WriteLine("RunTime " + elapsedTime);
            }
        }  
    }
}
