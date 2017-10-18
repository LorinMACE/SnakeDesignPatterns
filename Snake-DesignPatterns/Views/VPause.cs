using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Views
{
    static class VPause
    {


        public static Dictionary<int, System.ConsoleColor> listcolor = new Dictionary<int, System.ConsoleColor>(){
            { 1,ConsoleColor.Yellow },
            { 2,ConsoleColor.Blue },
            { 3,ConsoleColor.Green },
            { 4,ConsoleColor.Magenta},
            { 5,ConsoleColor.Cyan }
        };

        static public void Print( int height, int width)
        {

            int k = 1;
            for (int i = 10; i < width; i += 20)
            {
                for (int j = 5; j < height+5; j += 4)
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
