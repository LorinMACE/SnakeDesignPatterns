using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    /*
     * Design pattern Observer
     */
    interface IEvent
    {
        bool Trigger();
    }
}
