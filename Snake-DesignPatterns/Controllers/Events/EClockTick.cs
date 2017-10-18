using Snake_DesignPatterns.Controllers.Strategies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    class EClockTick : IEvent
    {
        public bool Trigger()
        {
            Debug.WriteLine("Tick");
            //On tick, execute game strategy
            return GameStrategy.Instance.LaunchStrategy();
        }
    }
}
