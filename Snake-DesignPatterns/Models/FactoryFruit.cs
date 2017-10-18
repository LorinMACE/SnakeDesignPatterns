using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    class FactoryFruit
    {
        public IFruitEffect createFruit(string typefruit)
        {
            switch (typefruit)
            {
                case "FruitLifeUp":
                    return new FruitLifeUp();
                    break;
                case "FruitSpeedUp":
                    return new FruitSpeedUp();
                    break;
                case "FruitSpeedDown":
                    return new FruitSpeedDown();
                    break;
                default:
                    return new Fruit();
                    break;
            }
            
        }
    }
}
