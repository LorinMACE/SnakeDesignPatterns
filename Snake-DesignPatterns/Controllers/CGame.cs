using Snake_DesignPatterns.Controllers.Events;
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
            GameBoard[fruitX, fruitY] = CellTypes.Fruit;

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
            EventManager mgr = EventManager.Instance;

            //Key events
            mgr.RegisterEvent(Event.KeyPressedDown,new KeyboardDown());
            mgr.RegisterEvent(Event.KeyPressedUp, new KeyboardUP());
            mgr.RegisterEvent(Event.KeyPressedLeft, new KeyboardLeft());
            mgr.RegisterEvent(Event.KeyPressedRight, new KeyboardRight());

            //Register to clock ticks
            mgr.RegisterEvent(Event.ClockTick, new EClockTick());

            //Starts the input trigger thread
            VInput.Instance.Start();

            //Start the ticks trigger thread
            CTick.Instance.Start();
        }

        public static void EndGame()
        {
            //We do not need the tick thread
            CTick.Instance.Stop();

            EventManager mgr = EventManager.Instance;

            //UnRegister to clock ticks
            mgr.UnRegisterEvent(Event.ClockTick, new EClockTick());
        }
    }
}
