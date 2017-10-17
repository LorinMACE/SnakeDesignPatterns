using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake_DesignPatterns.Views
{
    class VGameOver
    {

        public static void PrintHitItSelf(int Score)
        {
            Thread FeuArtifice;

            FeuArtifice = new Thread(new ThreadStart(ThreadFeu));
            FeuArtifice.Start();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 20);
            Console.WriteLine(" The Snake Hit his Body and DIED .");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("Your Score is : " + Score);
        }

        public static void PrintHitTheWall(int Score, int Lifes)
        {

            Thread FeuArtifice;

            FeuArtifice = new Thread(new ThreadStart(ThreadFeu));
            FeuArtifice.Start();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(8, 3);
            Console.WriteLine(" The Snake Hit the wall and DIED .");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(8, 4);
            Console.WriteLine("Your Score is : " + Score);

        }

        public static void ThreadFeu()
        {

            Dictionary<int, System.ConsoleColor> listcolor = new Dictionary<int, System.ConsoleColor>();

            listcolor.Add(1, ConsoleColor.Yellow);
            listcolor.Add(2, ConsoleColor.Blue);
            listcolor.Add(3, ConsoleColor.Green);
            listcolor.Add(4, ConsoleColor.Magenta);
            listcolor.Add(5, ConsoleColor.Cyan);
            listcolor.Add(6, ConsoleColor.Gray);
            listcolor.Add(7, ConsoleColor.DarkYellow);
            listcolor.Add(8, ConsoleColor.White);



            int k = 1;
            for (int i = 0; i < 50; i++)
            {
                Random aleatoire = new Random();
                int entier = aleatoire.Next();
                int x = aleatoire.Next(5, 9);
                int y = aleatoire.Next(10, 19);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = listcolor[k];
    
                Console.WriteLine((char)0x002A);

                Thread.Sleep(15);
                k++;
                if (k > 8) k = 1;


            }

            for (int i = 0; i < 150; i++)
            {
                Random aleatoire = new Random();
                int entier = aleatoire.Next();
                int x = aleatoire.Next(2, 14);
                int y = aleatoire.Next(2, 29);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = listcolor[k];
                Console.WriteLine((char)0x002A);

                Thread.Sleep(15);
                k++;
                if (k > 8) k = 1;


            }



        }



    }
}
