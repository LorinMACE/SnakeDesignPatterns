using Snake_DesignPatterns.Controllers;
using Snake_DesignPatterns.Controllers.Events;
using Snake_DesignPatterns.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_DesignPatterns
{
    class Snake
    {
        static void Main(string[] args)
        {
            //Create and start the input manager
            VInput inputs  = new VInput();

            //Create and starts Tick Manager
            CTick ticks = new CTick();

            //inputs.Stop() to exit the thread

            //Starts a new game
            CGame.NewGame();
            while (true)
            {
                
            }
                
                
        }
    }
}
