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
                Console.WriteLine(outputline);
            }




        }
    }

}
}
