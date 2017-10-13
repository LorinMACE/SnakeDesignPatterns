using Snake_DesignPatterns.Controllers.Events;
using Snake_DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Controllers
{
    static class CGame
    {
        static void PrintGameBoard()
        {
            CellTypes[][] GameBoard = new CellTypes[10][];
            int score = 0;
            int lifes = 0;

            //Stuff here to get and organise the data. => Call the model

            Views.VGame.Print(GameBoard,score,lifes);
        }
    }
}
