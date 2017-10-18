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
            CGame.PrintGameBoard();
            CGame.EndGame();
            VGameOver.Print(CGame.GameBoard,MGame.Instance.getScore(),DeathCause.HitSelf);
            return true;
        }
    }
    class GameOverHitWallStrategy : IGameStrategy
    {
        public bool Run()
        {
            CGame.BuildGameboard();
            CGame.PrintGameBoard();
            CGame.EndGame();
            VGameOver.Print(CGame.GameBoard, MGame.Instance.getScore(), DeathCause.HitWall);
            return true;
        }
    }

}
