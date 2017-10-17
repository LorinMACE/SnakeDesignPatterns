using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{

    class MFruit
    {
        //Chaque fruit a un type
        private IFruitEffect typeFruit;
        public IFruitEffect GetTypeFruit { get => typeFruit; }

        private Tuple<int,int> position;
        
        public Tuple<int, int> Position { get => position; set => position = value; }

        //On passe les valeurs au constructeur car ce n'est pas le modèle qui doit calculer 
        //randomly la position du fruit
        public MFruit(Tuple<int, int> pos)
        {
            //random selection of the typeFruit
            Random rdn = new Random();
            int RdnType = rdn.Next(1, 4);
            
            switch (RdnType)
            {
                case 1:
                    typeFruit = new FruitLifeUp();
                    break;
                case 2:
                    typeFruit = new FruitSpeedUp();
                    break;
                case 3:
                    typeFruit = new FruitSpeedDown();
                    break;
            }
            position = pos;
        }
    }
}
