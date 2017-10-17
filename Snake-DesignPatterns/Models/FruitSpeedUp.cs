using Snake_DesignPatterns.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake_DesignPatterns.Models
{
    class FruitSpeedUp : IFruitEffect
    {
        private int nbLifeUp;
        private int speed;

        public FruitSpeedUp()
        {
            speed = 40;
            nbLifeUp = 0;
        }

        public bool Effect()
        {
            CTick.Instance.Speed = CTick.Instance.Speed + speed;
            return true;
        }
    }
}
