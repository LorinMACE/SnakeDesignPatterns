using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Views
{
    class VGameOver
    {

        public static void PrintHitItSelf(int Score)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 20);
            Console.WriteLine(" The Snake Hit his Body and DIED .");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("Your Score is : " + Score);


        }

        public static void PrintHitTheWall(int Score, int Lifes)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 21);
            Console.WriteLine(" The Snake Hit the wall and DIED .");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("Your Score is : " + Score);

        }

    }
}
