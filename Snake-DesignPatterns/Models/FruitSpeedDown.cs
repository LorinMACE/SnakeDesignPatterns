using Snake_DesignPatterns.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    class FruitSpeedDown : IFruitEffect
    {

        private int nbLifeUp;
        private int speed;

        public FruitSpeedDown()
        {
            nbLifeUp = 0;
            speed = -40;
        }

        public bool Effect()
        {
            CTick.Instance.Speed = CTick.Instance.Speed + speed;
            return true;
        }
    }
}
