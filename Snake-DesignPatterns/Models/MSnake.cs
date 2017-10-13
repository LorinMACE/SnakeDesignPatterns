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

        public volatile SnakeOrientation Orientation;

    }

}
