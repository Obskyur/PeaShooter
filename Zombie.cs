using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal class Zombie : IDamageable
    {
        public ZType Type => ZType.Regular;
        public int Health { get; set; } = 50;

        public int TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }

            return Health <= 0 ? 0 : Health;
        }

        public void Die()
        {
        }

        public override string ToString()
        {
            return ZTypeExtensions.ZTypeToString[Type];
        }
    }
}
