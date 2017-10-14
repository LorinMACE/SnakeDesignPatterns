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
            MSnake Snake = MGame.Instance.Snake;

            //Get the orientation of the snake
            SnakeOrientation orientation = Snake.Orientation;
            Tuple<int, int> PreviousPosition = Snake.snakebody.First();
            int newX = PreviousPosition.Item1;
            int newY = PreviousPosition.Item2;

            //New position depending on the orientation
            switch (orientation)
            {
                case SnakeOrientation.Bottom:
                    newY = newY + 1;
                    break;
                case SnakeOrientation.Up:
                    newY = newY - 1;
                    break;
                case SnakeOrientation.Right:
                    newX = newX + 1;
                    break;
                case SnakeOrientation.Left:
                    newX = newX - 1;
                    break;
            }
            Tuple<int, int> NewPosition = new Tuple<int, int>(newX,newY);

            //Check for the intern events (Collisions, GameOver, etc...)
            //...
            //...
            //...
        }
    }
}
