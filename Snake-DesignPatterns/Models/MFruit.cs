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
        public FactoryFruit factoryFruit;

        private Tuple<int,int> position;
        
        public Tuple<int, int> Position { get => position; set => position = value; }

        //On passe les valeurs au constructeur car ce n'est pas le modèle qui doit calculer 
        //randomly la position du fruit
        public MFruit(Tuple<int, int> pos)
        {
            factoryFruit = new FactoryFruit();

            //random selection of the typeFruit
            Random rdn = new Random();
            int RdnType = rdn.Next(1, 100);

            if (RdnType < 50)
                typeFruit = factoryFruit.createFruit("default");
            else if (RdnType < 60)
                typeFruit = factoryFruit.createFruit("FruitLifeUp");
            else if (RdnType < 70)
                typeFruit = factoryFruit.createFruit("FruitSpeedDown");
            else
                typeFruit = factoryFruit.createFruit("FruitSpeedUp");

            position = pos;
        }
    }
}
