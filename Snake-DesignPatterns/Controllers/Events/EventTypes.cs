using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    enum Event
    {
        KeyPressedUp,
        KeyPressedDown,
        KeyPressedLeft,
        KeyPressedPause,
        CollisionEdge,
        CollisionSnake,
        CollisionFruit,
        ClockTick,
        NoLife,
        GameOver
    };
}
