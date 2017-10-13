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

        //Put to
        private volatile bool shouldStop;

        //This array binds the inputs to the events
        Dictionary<ConsoleKey, Event> Binds = new Dictionary<ConsoleKey, Event>()
        {
            //Directional keys
            {ConsoleKey.UpArrow,Event.KeyPressedUp},
            {ConsoleKey.DownArrow,Event.KeyPressedDown},
            {ConsoleKey.LeftArrow,Event.KeyPressedLeft},
            {ConsoleKey.RightArrow,Event.KeyPressedPause},

            //Letters
            {ConsoleKey.Z,Event.KeyPressedUp},
            {ConsoleKey.S,Event.KeyPressedDown},
            {ConsoleKey.Q,Event.KeyPressedLeft},
            {ConsoleKey.D,Event.KeyPressedPause},

            //Spacebar
            {ConsoleKey.Spacebar,Event.KeyPressedPause}
        };

        Thread worker;
        public VInput()
        {
            shouldStop = false;

            //Start the thread at start
            worker = new Thread(Start);
            worker.Start();
        }

        // This method will be called when the thread is started.
        public void Start()
        {
            while (!shouldStop)
            {
                while (!Console.KeyAvailable)
                {
                    Event e;
                    if (Binds.TryGetValue(Console.ReadKey(true).Key, out e))
                    {
                        EventManager.Instance.TriggerEvent(e);
                    }
                }
                Thread.Sleep(100);
            }
        }
        public void Stop()
        {
            shouldStop = true;
        }
    }
}
