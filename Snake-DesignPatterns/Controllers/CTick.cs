using Snake_DesignPatterns.Controllers.Events;
using System;
using System.Diagnostics;
using System.Threading;

namespace Snake_DesignPatterns.Controllers
{
    class CTick
    {
        private Thread worker;
        private Mutex WorkingMutex;
        private int count;
        private static bool pauseWorker = false;
        public volatile int Speed;

        public CTick()
        {
            worker = new Thread(work);
            WorkingMutex = new Mutex();
            count = 0;
            Speed = 250;
        }

        //Method to re-initialize the Speed
        public bool SpeedInit()
        {
            count = 0;
            Speed = 250;
            return true;
        }

        public void Start()
        {
            worker.Start();
        }

        public void Restart()
        {
            lock (WorkingMutex)
            {
                pauseWorker = false;
            }
            
        }

        public void Stop()
        {
            lock (WorkingMutex)
            {
                pauseWorker = true;
            }
        }

        // This method will be called when the thread is started.
        private void work()
        {
            while (true)
            {
                //Wait 1 seconds and send a Tick
                Thread.Sleep(Speed);

                //Mutex after
                if (count.Equals(30*count) || ((Speed - 20).Equals(20)))
                {
                    Speed = Speed - 20;
                    count = 0;
                }

                count++;

                lock (WorkingMutex)
                {
                    if (!pauseWorker)
                        Snake.EventManager.TriggerEvent(Event.ClockTick);
                }
            }

        }
    }
}
