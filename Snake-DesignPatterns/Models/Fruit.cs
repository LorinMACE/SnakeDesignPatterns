﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    class Fruit : IFruitEffect
    {
        public bool Effect()
        {
            return true;
        }
    }
}
