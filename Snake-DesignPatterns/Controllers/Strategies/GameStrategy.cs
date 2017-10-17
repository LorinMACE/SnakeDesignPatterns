using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Strategies
{
    class GameStrategy
    {
        IGameStrategy currentStrategy;
        GameContext ctx;

        //Create a singleton of EventManager
        private static GameStrategy instance;
        public static GameStrategy Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameStrategy();
                }
                return instance;
            }
        }

        protected GameStrategy()
        {
            currentStrategy = new GameRunStrategy();
        }

        public bool LaunchStrategy()
        {
            ctx = GameContext.Instance;

            //Introspection later...
            if (!ctx.IsOver) {
                if (!ctx.IsPaused)
                    currentStrategy = new GameRunStrategy();
                else
                    currentStrategy = new GamePausedStrategy();
            } else {
                if (ctx.HasHitTheWall)
                    currentStrategy = new GameOverHitWallStrategy();
                else
                    currentStrategy = new GameOverHitSelfStrategy();
            }

            return currentStrategy.Run();
        }
    }
}
