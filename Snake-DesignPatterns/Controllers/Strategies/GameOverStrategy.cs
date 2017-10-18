using Snake_DesignPatterns.Models;
using Snake_DesignPatterns.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Strategies
{
    class GameOverHitSelfStrategy : IGameStrategy
    {
        public bool Run()
        {
            CGame.BuildGameboard();
            CGame.EndGame();
            CGame.PrintGameBoard();
            VGameOver.PrintHitItSelf(CGame.GameBoard,MGame.Instance.getScore());
            return true;
        }
    }
    class GameOverHitWallStrategy : IGameStrategy
    {
        public bool Run()
        {
            CGame.BuildGameboard();
            CGame.EndGame();
            CGame.PrintGameBoard();
            VGameOver.PrintHitTheWall(CGame.GameBoard,MGame.Instance.getScore(),MGame.Instance.Snake.Nblife);
            return true;
        }
    }

}
