using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Strategies
{
    class GameRunStrategy : IGameStrategy
    {
        public bool Run()
        {
            CSnake.Move();
            CGame.BuildGameboard();
            CGame.PrintGameBoard();
            return true;
        }
    }
}
