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

        public CTick()
        {
            worker = new Thread(work);
            WorkingMutex = new Mutex();
            count = 0;
        }
        
        private static bool pauseWorker = false;

        //Method to re-initialize the Speed
        public bool SpeedInit()
        {
            count = 0;
            return true;
        }

        private volatile bool shouldStop;
        public volatile int Speed;

        Thread worker;
        public CTick()
        {
            Speed = 250;
            worker = new Thread(work);
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
                count++;
                //Wait 1 seconds and send a Tick
                Thread.Sleep(Speed);
                EventManager.Instance.TriggerEvent(Event.ClockTick);
            }

        }
    }
}
