using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers.Strategies
{
    class GameContext
    {

        public bool IsPaused;
        public bool IsOver;
        public bool HasHitTheWall;

        //Create a singleton of EventManager
        private static GameContext instance;
        public static GameContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameContext();
                }
                return instance;
            }
        }

        protected GameContext() {
            IsPaused = false ;
            IsOver = false ;
            HasHitTheWall = false ;
        }

        public void Reset()
        {
            IsPaused = false;
            IsOver = false;
            HasHitTheWall = false;
        }
    }
}
