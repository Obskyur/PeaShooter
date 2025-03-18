using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal interface IDamageable
    {
        int Health { get; set; }
        int takeDamage(int damage);
        void die();
    }
}
