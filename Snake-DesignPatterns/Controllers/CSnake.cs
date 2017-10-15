using Snake_DesignPatterns.Controllers.Events;
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
            MGame Game = MGame.Instance;
            MSnake Snake = Game.Snake;

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
            if (newX < 0 || newY < 0 || newX > Game.Map.Width || newY > Game.Map.Height || Snake.Nblife.Equals(0))
            {
                throw new NotImplementedException();
            }

            //Check for collision with itself
            if (Snake.snakebody.Contains(new Tuple<int,int>(newX,newY)))
            {
                Snake.Nblife--;
                while (!Snake.snakebody.Last.Value.Equals(new Tuple<int, int>(newX, newY)))
                {
                    Snake.snakebody.RemoveLast();
                }

            }

            //We are OK => Go forward
            Snake.snakebody.AddFirst(new Tuple<int, int>(newX, newY));

            //Check if we are in the position of the fruit
            Tuple<int, int> positionFruit = MGame.Instance.Fruit.Position;
            bool FruitInCase = (newX == positionFruit.Item1 && newY == positionFruit.Item2);

            //If there is no fruit, we remove the last part of the snake
            if (FruitInCase)
                Game.GenerateFruit();
            else
                Snake.snakebody.RemoveLast();
        }
    }
}
