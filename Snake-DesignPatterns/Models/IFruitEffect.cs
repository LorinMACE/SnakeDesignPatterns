using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DesignPatterns.Models
{
    //interface for different kind of fruits, with different power up
    interface IFruitEffect
    {
        bool Effect();
    }
}
