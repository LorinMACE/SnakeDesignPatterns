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

        public MMap Map;
        public MFruit Fruit;
        public MSnake Snake;

        public MGame()
        {
            //Initialise all the gameboard here (all the others objects of the model)
            
            Map = new MMap(30, 15);

            Snake = new MSnake(3, Map.Height/2, Map.Width/2 );

            //pour générer randomly deux entiers, qui seront un tuple
            Random rdn = new Random();

            //générer le random entre 1 et 19 pour abscisse et 1 et 14 pour ordonnees
            int rdnx = rdn.Next(1, 29);
            int rdny = rdn.Next(1, 14);
            
            Tuple<int, int> posFruit = new Tuple<int, int>(rdnx, rdny);

            Fruit = new MFruit(posFruit);
            

        }

        public bool init()
        {

            return true;
        }

       


    }
}
