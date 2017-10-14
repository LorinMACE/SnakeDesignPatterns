using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    enum SnakeOrientation
    {
        Up,
        Bottom,
        Left,
        Right
    };

    class MSnake
    {

        //volatile pour que ce soit accessible par plusieurs threads en meme temps
        public volatile SnakeOrientation Orientation;

        private int nblife;

        //liste contient des cases avec x et y, une case est un tuple de deux int
        private Tuple<int, int> tuple;

        public LinkedList<Tuple<int, int>> snakebody;

        public int Nblife { get => nblife; set => nblife = value; }

        public MSnake(int nlife, int x, int y)
        {
            nblife = nlife;

            //on definit le premier tuple qui est la position du serpent
            tuple = new Tuple<int, int>(x, y);

            //initialisation de la liste chainee 
            snakebody = new LinkedList<Tuple<int,int>>();

            //on ajoute a la liste le premier tuple qui est le depart du snake
            snakebody.AddFirst(tuple);
        }

        //On lui passe deux valeurs du dernier tuple du serpent pour ajouter un élément 
        public bool SnakeGrows(int x, int y)
        {
            //ajout à la fin du snake
            snakebody.AddLast(new Tuple<int, int>(x, y));
            return true;
        }

        //Méthode pour récupérer le tuple de fin du snake, peut etre utile pour appeler
        // SnakeGrows
        public Tuple<int, int> LastTupleBody()
        {
            return snakebody.Last.Value;
        }

    }

}
