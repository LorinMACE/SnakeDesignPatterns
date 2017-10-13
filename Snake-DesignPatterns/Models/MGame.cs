using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    class MGame
    {

        //Implementation of the singleton for an instance of the game
        private static MGame instance;
        public static MGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MGame();
                }
                return instance;
            }
        }


        public MSnake Snake;

        public MGame()
        {
            //Initialise all the gameboard here (all the others objects of the model)
            Snake = new MSnake();
        }

       


    }
}
