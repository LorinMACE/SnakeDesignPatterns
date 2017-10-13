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

         /*
          * This complicated stuff just make a Mutex on the orientation in case two threads are trying to access it at the same time.
          * You just need to access the Orientation value like a classic value.
          * Warning: Don't try to access the private orientation value directly.
          */
        private System.Object OrientationMutex = new System.Object();
        private SnakeOrientation orientation;
        public SnakeOrientation Orientation
        {
            get {
                lock (OrientationMutex){return orientation;}
            }
            set {
                lock (OrientationMutex)
                { orientation=value;}
            }
        }


    }

}
