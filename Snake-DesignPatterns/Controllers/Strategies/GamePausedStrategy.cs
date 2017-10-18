using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_DesignPatterns.Views;
using Snake_DesignPatterns.Models;

namespace Snake_DesignPatterns.Controllers.Strategies
{
    class GamePausedStrategy : IGameStrategy
    {
        public bool Run()
        {
            //Go to pause and stop clock tick
            CGame.Pause();
            CGame.PrintGameBoard();
            VPause.Print(height: MGame.Instance.Map.Height, width: MGame.Instance.Map.Width);
            return true;
        }
    }
}
