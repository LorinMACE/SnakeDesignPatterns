using Snake_DesignPatterns.Controllers.Events;
using System.Threading;

namespace Snake_DesignPatterns.Controllers
{
    class CTick
    {
        //Create a singleton of CTick()
        private static CTick instance;
        public static CTick Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CTick();
                }
                return instance;
            }
        }


        private volatile bool shouldStop;
        public volatile int Speed;

        Thread worker;
        public CTick()
        {
            Speed = 250;
            worker = new Thread(work);
        }

        public void Start()
        {
            //Start only if not started
            if (!worker.IsAlive)
            {
                shouldStop = false;
                worker.Start();
            }
        }

        public void Stop()
        {
            shouldStop = true;
        }

        // This method will be called when the thread is started.
        private void work()
        {
            while (!shouldStop)
            {
                //Wait 1 seconds and send a Tick
                Thread.Sleep(Speed);
                EventManager.Instance.TriggerEvent(Event.ClockTick);
            }
        }
    }
}
