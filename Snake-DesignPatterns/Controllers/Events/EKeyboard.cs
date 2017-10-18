using Snake_DesignPatterns.Controllers.Strategies;
using Snake_DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Events
{
    class KeyboardUP : IEvent
    {
        public bool Trigger()
        {
            MGame.Instance.Snake.Orientation = SnakeOrientation.Up;
            return true;
        }
    }

    class KeyboardLeft : IEvent
    {
        public bool Trigger()
        {
            MGame.Instance.Snake.Orientation = SnakeOrientation.Left;
            return true;
        }
    }

    class KeyboardDown : IEvent
    {
        public bool Trigger()
        {
            MGame.Instance.Snake.Orientation = SnakeOrientation.Bottom;
            return true;
        }
    }

    class KeyboardRight : IEvent
    {
        public bool Trigger()
        {
            MGame.Instance.Snake.Orientation = SnakeOrientation.Right;
            return true;
        }
    }

    class KeyboardPaused : IEvent
    {
        public bool Trigger()
        {

            GameContext.Instance.IsPaused = !GameContext.Instance.IsPaused;
            if (!GameContext.Instance.IsPaused)
                CGame.UnPause();
            return true;
        }
    }
}
