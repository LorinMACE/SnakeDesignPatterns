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

        //Constructor
        public EventManager()
        {
            listeners = new Dictionary<Event, List<IEvent>>();
        }

        //Create a singleton of EventManager
        private static EventManager instance;
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManager();
                }
                return instance;
            }
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
            //Check if the event is present in the key list
            if (listeners.ContainsKey(key) && listeners[key].Contains(evenement))
            {

                listeners[key].Remove(evenement);

                //If the key's Observable list is empty, we remove it.
                if (listeners[key].Count == 0)
                    listeners.Remove(key);

            }
        }

        // Block events to happen in the same time
        Mutex EventMutex = new Mutex();

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
