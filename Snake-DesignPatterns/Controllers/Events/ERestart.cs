using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    class ERestart : IEvent
    {
        public bool Trigger()
        {
            CGame.Restart();
            return true;
        }
    }
}
