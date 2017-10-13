using Snake_DesignPatterns.Controllers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers
{
    class CTick
    {
        private volatile bool shouldStop;
        public volatile int Speed;

        Thread worker;
        public CTick()
        {
            shouldStop = false;
            Speed = 1000;

            //Start the thread at start
            worker = new Thread(Start);
            worker.Start();
        }

        // This method will be called when the thread is started.
        public void Start()
        {
            while (!shouldStop)
            {
                //Wait 1 seconds and send a Tick
                Thread.Sleep(Speed);
                EventManager.Instance.TriggerEvent(Event.ClockTick);
            }
        }
        public void Stop()
        {
            shouldStop = true;
        }
    }
}
