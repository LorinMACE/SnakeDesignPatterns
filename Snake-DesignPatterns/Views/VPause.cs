using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Views
{
    class VPause
    {


        public static Dictionary<int, System.ConsoleColor> listcolor = new Dictionary<int, System.ConsoleColor>();

        public void Print( int height, int width)
        {

            listcolor.Add(1, ConsoleColor.Yellow);
            listcolor.Add(2, ConsoleColor.Blue);
            listcolor.Add(3, ConsoleColor.Green);
            listcolor.Add(4, ConsoleColor.Magenta);
            listcolor.Add(5, ConsoleColor.Cyan);

            int k = 1;
            for (int i = 4; i < width; i += 20)
            {
                for (int j = 5; j < height; j += 5)
                {

                    Console.SetCursorPosition(i, j);

                    Console.ForegroundColor = listcolor[k];

                    Console.WriteLine("Game paused  ...");

                    k++;
                    if (k > 5) k = 1;
                }
            }


        }





    }
}
