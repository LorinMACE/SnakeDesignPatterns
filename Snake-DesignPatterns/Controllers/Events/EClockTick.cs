using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    class EClockTick : IEvent
    {
        public bool Trigger()
        {
            //On tick, just update the snake
            CSnake.Move();
            CGame.PrintGameBoard();
            return true;
        }
    }
}
