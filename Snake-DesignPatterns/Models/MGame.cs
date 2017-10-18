using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            NewGame();
        }

        public void NewGame()
        {
            //Initialise all the gameboard here (all the others objects of the model)

            Map = new MMap(15, 30);

            Snake = new MSnake(3, Map.Width / 2, Map.Height / 2);
            Snake.SnakeGrows(Snake.snakebody.Last.Value.Item1, Snake.snakebody.Last.Value.Item2 + 1);
            Snake.SnakeGrows(Snake.snakebody.Last.Value.Item1, Snake.snakebody.Last.Value.Item2 + 1);
            Snake.SnakeGrows(Snake.snakebody.Last.Value.Item1, Snake.snakebody.Last.Value.Item2 + 1);

            GenerateFruit();
        }

        public void GenerateFruit()
        {

            //pour générer randomly deux entiers, qui seront un tuple
            Random rdn = new Random();

            //Liste des cases exclues
            List<Tuple<int, int>> excluded = Snake.snakebody.ToList();

            //Ici rayon de 3 autour de la TETE du serpent
            List<int> excludedX = Enumerable.Range(Snake.snakebody.First.Value.Item1 - 3, 6).ToList();
            List<int> excludedY = Enumerable.Range(Snake.snakebody.First.Value.Item2 - 3, 6).ToList();

            foreach (var x in excludedX)
            {
                foreach (var y in excludedY)
                {
                    if (x >= 0 && y >= 0 && x < Map.Width && y < Map.Height)
                    {
                        Tuple<int, int> newTuple = new Tuple<int, int>(x, y);
                        if (!excluded.Contains(newTuple))
                            excluded.Add(newTuple);
                    }
                }
            }

            int rdnx;int rdny;

            //générer le random entre 1 et 29 pour abscisse et 1 et 14 pour ordonnees
            //on regenere le rnd si il est dans un rayon de 3 autour de la tete du serpent
            do
            {
                rdnx = rdn.Next(0, Map.Width);
                rdny = rdn.Next(0, Map.Height);
            } while (excluded.Contains(new Tuple<int, int>(rdnx, rdny)));
 
            Tuple<int, int> posFruit = new Tuple<int, int>(rdnx, rdny);

            Fruit = new MFruit(posFruit);
        }

        //return the score, i.e the size of the LinkedList
        public int getScore()
        {
            return Snake.snakebody.Count;
        }
        
    }
}
