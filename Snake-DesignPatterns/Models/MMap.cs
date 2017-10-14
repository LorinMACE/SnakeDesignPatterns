using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    enum CellTypes
    {
        Empty,
        Edge,
        SnakeHeadUp,
        SnakeHeadDown,
        SnakeHeadLeft,
        SnakeHeadRight,
        SnakeBody,
        Fruit
    };

    class MMap
    {
        private int height;
        private int width;

        //pareil que MFruit, on passe les valeurs au constructeur pour faire plus propre
        public MMap(int h, int w)
        {
            height = h;
            width = w;
        }

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

    }
}
