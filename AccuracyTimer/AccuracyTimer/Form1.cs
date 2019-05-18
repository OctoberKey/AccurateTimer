using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccuracyTimer
{
    public partial class Form1 : Form
    {
        // P/Invoke declarations
        private delegate void TimerEventHandler(int id, int msg, IntPtr user, int dw1, int dw2);
        private const int TIME_PERIODIC = 1;
        private const int EVENT_TYPE = TIME_PERIODIC;// + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, TimerEventHandler handler, IntPtr user, int eventType);
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);
        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int msec);


        private int mTimerId;
        private TimerEventHandler mHandler;  // NOTE: declare at class scope so garbage collector doesn't release it!!!
        private int mTestTick;
        private DateTime mTestStart;
        AccurateTimer mTimer1 = null;
        int delay = 1000 ;
        bool fStart = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timeBeginPeriod(1);
            //mHandler = new TimerEventHandler(TimerCallback);
            //mTimerId = timeSetEvent(1, 0, mHandler, IntPtr.Zero, EVENT_TYPE);
            //mTestStart = DateTime.Now;
            //mTestTick = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //mTimerId = 0;
            //int err = timeKillEvent(mTimerId);
            //timeEndPeriod(1);
            //// Ensure callbacks are drained
            //System.Threading.Thread.Sleep(100);

            if (mTimer1 != null)
            {
                mTimer1.ReleaseSemaphore();
                mTimer1.Stop();
            }
        }

        private void TimerTick1()
        {
            //if (mTimer1.mTimerId != 0)
            {
                // Put your first timer code here!
                Application.DoEvents();
                //System.Threading.Thread.Sleep(10);// Ensure callbacks are drained
                DateTime dt = DateTime.Now;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                lstbxElapsedTime.Items.Add(elapsedTime);
                //mTimer1.ReleaseSemaphore();
                if (fStart == true)
                {
                    mTimer1 = new AccurateTimer(this, new Action(TimerTick1), delay);
                }
            }
        }

        private delegate void TestEventHandler(int tick, TimeSpan span);
        private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
        {
            mTestTick += 1;
            if ((mTestTick % 1) == 0 && mTimerId != 0)
                this.BeginInvoke(new TestEventHandler(ShowTick), mTestTick, DateTime.Now - mTestStart);
        }
        private void ShowTick(int msec, TimeSpan span)
        {
            label1.Text = msec.ToString();
            label2.Text = span.TotalMilliseconds.ToString();
        }

        private void btnStopStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimeIntervalInMiliseconds.Text) == false)
            {
                if (mTimer1 != null)
                {
                    //mTimer1.ReleaseSemaphore();
                    //System.Threading.Thread.Sleep(10);// Ensure callbacks are drained
                    //while (mTimer1.IsReady() == false) ;
                    if (mTimer1.mTimerId != 0)
                    {
                        mTimer1.Stop();
                    }
                    btnStopStart.Text = "Start";
                    mTimer1 = null;
                    fStart = false;
                }
                else
                {
                    
                    try
                    {
                        delay = Convert.ToInt32(txtTimeIntervalInMiliseconds.Text);   // In milliseconds. 10 = 1/100th second.
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                    mTimer1 = new AccurateTimer(this, new Action(TimerTick1), delay);
                    btnStopStart.Text = "Stop";
                    fStart = true;
                }
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstbxElapsedTime.Items.Clear();
        }
    }
}
