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
            Console.WriteLine("UP");
            MGame.Instance.Snake.Orientation = SnakeOrientation.Up;
            return true;
        }
    }

    class KeyboardLeft : IEvent
    {
        public bool Trigger()
        {
            Console.WriteLine("LEFT");
            MGame.Instance.Snake.Orientation = SnakeOrientation.Left;
            return true;
        }
    }

    class KeyboardDown : IEvent
    {
        public bool Trigger()
        {
            Console.WriteLine("DOWN");
            MGame.Instance.Snake.Orientation = SnakeOrientation.Bottom;
            return true;
        }
    }

    class KeyboardRight : IEvent
    {
        public bool Trigger()
        {
            Console.WriteLine("RIGHT");
            MGame.Instance.Snake.Orientation = SnakeOrientation.Right;
            return true;
        }
    }
}
