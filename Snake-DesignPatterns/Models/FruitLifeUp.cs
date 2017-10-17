using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    class FruitLifeUp : IFruitEffect
    {
        private int nbLifeUp;
        private int speed;

        
        public FruitLifeUp()
        {
            nbLifeUp = 1;
            speed = 0;
        }

        public bool Effect()
        {
            MGame.Instance.Snake.Nblife = MGame.Instance.Snake.Nblife + nbLifeUp;
            return true;
        }
    }
}
