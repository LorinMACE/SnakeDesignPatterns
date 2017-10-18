using Snake_DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    //Implementation of the singleton for an instance of the EventManager

    /*
     *  The observer class
     */
    class EventManager
    {
        private Dictionary<Event, List<IEvent>> listeners;

        // Block events to happen in the same time
        Mutex EventMutex;

        //Constructor
        public EventManager()
        {
            listeners = new Dictionary<Event, List<IEvent>>();
            EventMutex = new Mutex();
        }

        public void RegisterEvent(Event key,IEvent evenement)
        {
            //Check if the key exit
            if (!listeners.ContainsKey(key))
                //If the key doesn't exit, we ad it
                listeners.Add(key, new List<IEvent>());

            //Check if the event is already in the key
            if (!listeners[key].Contains(evenement))
                listeners[key].Add(evenement);
        }

        public void UnRegisterEvent(Event key, IEvent evenement)
        {
            if (!listeners.ContainsKey(key))
                return;

            listeners.Single(p => p.Key == key).Value.Remove(evenement);
        }

        public bool TriggerEvent(Event key)
        {
            lock (EventMutex)
            {
                List<IEvent> list = listeners.SingleOrDefault(p => p.Key == key).Value;

                //We need to check if the list is empty
                if (list == null || list.Count == 0)
                    return false;

                IEvent[] inputListeners = list.ToArray();

                //Execute 
                foreach (var listener in inputListeners)
                {

                    //If an observable return false, we exit the execution of the observables
                    if (!listener.Trigger())
                        return true;
                }

                return true;
            }
        }
    }
}
