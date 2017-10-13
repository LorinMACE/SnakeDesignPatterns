using Snake_DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers
{
    static class CSnake
    {
        public static void Move()
        {
            //Get the orientation of the snake
            SnakeOrientation orientation = MGame.Instance.Snake.Orientation;


            //Check for the intern events (Collisions, GameOver, etc...)
            //...
            //...
            //...
        }
    }
}
