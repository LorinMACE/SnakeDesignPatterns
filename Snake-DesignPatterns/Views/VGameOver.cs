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

        private static string msghitSelf = "The Snake Hit his Body & DIED.";
        private static string msghitWall = "The Snake Hit the wall & DIED.";
        private static string msgScore = "Your Score is : ";
        private static string msgRestart = "Press Enter to restart";


        public static bool WriteGameBoard(string msg, int heightMsg)
        {
            int length = msg.Length;
            int j = 0;
           
            foreach (char c in msg)
            {
                gameBoard[j, 2] = CellTypes.Text;
                //We have to calculate the offset considering the length 
                int offset = 32 - length; //30 + 2 for the total size, 30 gameboard and 2 for # 2 sides
                Console.SetCursorPosition( j + offset/2 +1, heightMsg );
                Console.Write(c);
                j++;
             
            }
            return true;
        }


        public static void Print(CellTypes[,] GameBoard,int Score, DeathCause cause)
        {

            Thread FeuArtifice;
            gameBoard = GameBoard;
            msgScore += Score;

            Console.ForegroundColor = ConsoleColor.Red;
            if (cause == DeathCause.HitSelf)
               
                WriteGameBoard(msghitSelf, 8);
            else
                WriteGameBoard(msghitWall, 8);

            Console.ForegroundColor = ConsoleColor.Green;
            WriteGameBoard(msgScore, 10);

            Console.ForegroundColor = ConsoleColor.White;
            WriteGameBoard(msgRestart, 18);

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
