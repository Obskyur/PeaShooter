using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal class ZombieFactory : IZombieFactory
    {
        public Zombie Create(Accessory? accessory)
        {
            return new Zombie(accessory);
        }
    }
}
