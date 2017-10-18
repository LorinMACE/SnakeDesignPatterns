using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Snake_DesignPatterns.Models;

namespace Snake_DesignPatterns.Views
{
    static class VGameOver
    {
        private static CellTypes[,] gameBoard;


        public static void PrintHitItSelf(CellTypes[,] GameBoard,int Score)
        {
            Thread FeuArtifice;
            gameBoard = GameBoard;
            FeuArtifice = new Thread(new ThreadStart(ThreadFeu));
            FeuArtifice.Start();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("The Snake Hit his Body & DIED."); //32
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(8, 10);
            Console.WriteLine("Your Score is :  " + Score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(6, 18);
            Console.WriteLine("Press Enter to restart");

        }

        public static void PrintHitTheWall(CellTypes[,] GameBoard,int Score, int Lifes)
        {

            Thread FeuArtifice;
            gameBoard = GameBoard;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("The Snake Hit the wall & DIED.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(8, 10);
            Console.WriteLine("Your Score is :  " + Score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(6, 18);
            Console.WriteLine("Press Enter to restart");

            FeuArtifice = new Thread(new ThreadStart(ThreadFeu));
            FeuArtifice.Start();

           

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
                int x = aleatoire.Next(14, 19);
                int y = aleatoire.Next(9, 14);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = listcolor[k];

                if (gameBoard[x - 3, y - 5] == CellTypes.Empty && y!=8 && y !=10 && y!=18)
                    Console.WriteLine((char)0x002A);

                Thread.Sleep(15);
                k++;
                if (k > 8) k = 1;


            }

            for (int i = 0; i < 150; i++)
            {
                Random aleatoire = new Random();
                int entier = aleatoire.Next();
                int x = aleatoire.Next(3, 31);
                int y = aleatoire.Next(5, 20);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = listcolor[k];

                if (gameBoard[x-3, y-5]==CellTypes.Empty && y != 8 && y != 10 && y != 18)
                    Console.WriteLine((char)0x002A);

                Thread.Sleep(15);
                k++;
                if (k > 8) k = 1;


            }



        }



    }
}
