using Snake_DesignPatterns.Controllers.Events;
using Snake_DesignPatterns.Controllers.Strategies;
using Snake_DesignPatterns.Models;
using Snake_DesignPatterns.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers
{
    static class CGame
    {
        public static void PrintGameBoard()
        {
            MGame Game = MGame.Instance;

            CellTypes[,] GameBoard = new CellTypes[Game.Map.Width,Game.Map.Height];
            int score = Game.getScore();
            int lifes = Game.Snake.Nblife;

            //Print the fruit
            int fruitX = Game.Fruit.Position.Item1; int fruitY = Game.Fruit.Position.Item2;

            if (Game.Fruit.GetTypeFruit is FruitLifeUp)
            {
                GameBoard[fruitX, fruitY] = CellTypes.FruitLifeUp;
            }
            if (Game.Fruit.GetTypeFruit is FruitSpeedUp)
            {
                GameBoard[fruitX, fruitY] = CellTypes.FruitSpeedUp;
            }
            if (Game.Fruit.GetTypeFruit is FruitSpeedDown)
            {
                GameBoard[fruitX, fruitY] = CellTypes.FruitSpeedDown;
            }
            //GameBoard[fruitX, fruitY] = CellTypes.Fruit;

            bool first = true;
            //Print the snake in the gameboard
            foreach (var bodypart in Game.Snake.snakebody)
            {
                int bodypartX = bodypart.Item1; int bodypartY = bodypart.Item2;

                // The 1st is the head
                if (first)
                {
                    switch (Game.Snake.Orientation)
                    {
                        case SnakeOrientation.Bottom:
                            GameBoard[bodypartX, bodypartY] = CellTypes.SnakeHeadDown;
                            break;
                        case SnakeOrientation.Up:
                            GameBoard[bodypartX, bodypartY] = CellTypes.SnakeHeadUp;
                            break;
                        case SnakeOrientation.Left:
                            GameBoard[bodypartX, bodypartY] = CellTypes.SnakeHeadLeft;
                            break;
                        case SnakeOrientation.Right:
                            GameBoard[bodypartX, bodypartY] = CellTypes.SnakeHeadRight;
                            break;
                    }
                    first = false;
                } else
                {
                    GameBoard[bodypartX, bodypartY] = CellTypes.SnakeBody;
                }
                
                
            }

            VGame.Print(GameBoard, Game.Map.Height, Game.Map.Width,score, lifes);
        }

        public static void NewGame()
        {
            MGame game = MGame.Instance;
            EventManager mgr = Snake.EventManager;

            //Key events
            mgr.RegisterEvent(Event.KeyPressedDown,new KeyboardDown());
            mgr.RegisterEvent(Event.KeyPressedUp, new KeyboardUP());
            mgr.RegisterEvent(Event.KeyPressedLeft, new KeyboardLeft());
            mgr.RegisterEvent(Event.KeyPressedRight, new KeyboardRight());
            mgr.RegisterEvent(Event.KeyPressedPause, new KeyboardPaused());

            //Register to clock ticks
            mgr.RegisterEvent(Event.ClockTick, new EClockTick());

        }

        public static void Pause()
        {
            //Stop ticks for pause
            Snake.TickThread.Stop();

            EventManager mgr = Snake.EventManager;
        }

        public static void UnPause()
        {
            EventManager mgr = Snake.EventManager;

            //Restart ticks after pause
            Snake.TickThread.Restart();
        }

        public static void EndGame()
        {
            //We do not need the tick thread
            Snake.TickThread.Stop();

            EventManager mgr = Snake.EventManager;
        }
    }
}
