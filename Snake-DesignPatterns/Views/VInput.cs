using Snake_DesignPatterns.Controllers.Events;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake_DesignPatterns.Views
{
    class VInput
    {

        //Current pressed key
        private ConsoleKeyInfo key;

        private volatile bool shouldStop;

        //This array binds the inputs to the events
        Dictionary<ConsoleKey, Event> Binds = new Dictionary<ConsoleKey, Event>()
        {
            //Directional keys
            {ConsoleKey.UpArrow,Event.KeyPressedUp},
            {ConsoleKey.DownArrow,Event.KeyPressedDown},
            {ConsoleKey.LeftArrow,Event.KeyPressedLeft},
            {ConsoleKey.RightArrow,Event.KeyPressedRight},

            //Letters
            {ConsoleKey.Z,Event.KeyPressedUp},
            {ConsoleKey.S,Event.KeyPressedDown},
            {ConsoleKey.Q,Event.KeyPressedLeft},
            {ConsoleKey.D,Event.KeyPressedRight},

            //Spacebar
            {ConsoleKey.Spacebar,Event.KeyPressedPause},
            
            //Spacebar
            {ConsoleKey.Enter,Event.KeyPressedRestart}
        };

        Thread worker;

        public VInput()
        {
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
                while (!Console.KeyAvailable)
                {
                    Event e;
                    if (Binds.TryGetValue(Console.ReadKey(true).Key, out e))
                    {
                        Snake.EventManager.TriggerEvent(e);
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
