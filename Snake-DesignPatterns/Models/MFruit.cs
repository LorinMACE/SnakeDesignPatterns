using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{

    class MFruit
    {
        private Tuple<int,int> position;
        
        public Tuple<int, int> Position { get => position; set => position = value; }

        //On passe les valeurs au constructeur car ce n'est pas le modèle qui doit calculer 
        //randomly la position du fruit
        public MFruit(Tuple<int, int> pos)
        {
            position = pos;
        }
    }
}
