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
        public ZType Type { get; }
        int TakeDamage(int damage);
        void Die();
        string ToString();
    }
}
