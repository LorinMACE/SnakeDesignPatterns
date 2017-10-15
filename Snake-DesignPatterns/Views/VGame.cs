using Snake_DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Views
{
    static class VGame
    {
        public static Dictionary<CellTypes, Char> cellsbind = new Dictionary<Models.CellTypes, Char>() {
            { CellTypes.Empty,' '},
            { CellTypes.Edge,'X'},
            { CellTypes.SnakeHeadUp,'^'},
            { CellTypes.SnakeHeadDown,'v'},
            { CellTypes.SnakeHeadLeft,'<'},
            { CellTypes.SnakeHeadRight,'>'},
            { CellTypes.SnakeBody,'o'},
            { CellTypes.Fruit,'F'}
            };
        /*
         * Gameboard: An array with a dimension MapHeight*MapWidth, filled with Cells
         * Score: The global score of the player
         * Lifes: The remainging number of lifes of the player
         */
        public static void Print(CellTypes[,] gameBoard, int height, int width, int Score, int Lifes)
        {


             for (int i = 0; i < height; i++)
             {
                 String outputline = "";
                 for (int j = 0; j < width; j++)
                 {
                     outputline = outputline + cellsbind[gameBoard[j,i]];
                 }
                Console.SetCursorPosition(2, i+5);
                Console.WriteLine(outputline);
             }

            printWall(height+5, width+2, Score, Lifes);


        }

        public static void printWall(int height, int width, int score, int lifes)
        {

            char wallChar = '#';

            //dessiner les deux les murs verticaux
            for (int i = 1; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write(wallChar);
                Console.SetCursorPosition(width, i);
                Console.Write(wallChar);
            }
            //dessiner la ligne qui sépare Score de Life
            for (int k = 1; k < 4; k++)
            {
                Console.SetCursorPosition(width / 2, k);
                Console.Write(wallChar);
            }
            //Affichage du score et de Lifes
            Console.SetCursorPosition(4, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SCORE :  " + score);
            Console.SetCursorPosition(width / 2+4, 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lifes : " + lifes);

            //dessiner les deux les murs horizontaux
            for (int j = 1; j < width; j++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(j, 1);
                Console.Write(wallChar);
                Console.SetCursorPosition(j, 4);
                Console.Write(wallChar);
                Console.SetCursorPosition(j, height);
                Console.Write(wallChar);

            }




        }
    }

}
