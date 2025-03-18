using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal interface IZombieFactory
    {
        Zombie Create(Accessory accessory);
    }
}
