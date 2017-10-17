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
        //We count 10 ticks and we accelerate the snake
        private int count;

        public int Count { get => count; }

        //Method to re-initialize the Speed
        public bool SpeedInit()
        {
            count = 0;
            return true;
        }

        Thread worker;
        public CTick()
        {
            //We need  to reduce the tick to highten the speed
            Speed = 250;
            count = 0;
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

                //each count=30*count(30,60,90....), we accelerate the snake, and if Speed = 40, we won't accelerate anymore (enough)
                if (count.Equals(30 * count) || ((Speed - 20).Equals(20)))
                {
                    Speed = Speed - 20;
                    count = 0;
                }

                //modify the speed using the count
                count++;
                EventManager.Instance.TriggerEvent(Event.ClockTick);
            }
        }
    }
}
