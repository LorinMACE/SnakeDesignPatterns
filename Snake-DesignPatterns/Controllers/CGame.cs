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
            CellTypes[][] GameBoard = new CellTypes[10][];
            int score = 0;
            int lifes = 0;

            //Stuff here to get and organise the data. => Call the model

            Views.VGame.Print(GameBoard,score,lifes);
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
