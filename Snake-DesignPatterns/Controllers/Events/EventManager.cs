using Snake_DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    //Implementation of the singleton for an instance of the EventManager

    /*
     *  The observer class
     */
    class EventManager
    {

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


        public void RegisterEvent(Event e)
        {

        }

        public void UnRegisterEvent(Event e)
        {

        }

        public void TriggerEvent(Event e)
        {

        }
    }

}
