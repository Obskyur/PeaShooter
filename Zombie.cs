using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal class Zombie : IDamageable
    {
        public char symbol;
        public int Health { get; set; } = 50;
        public Accessory? Accessory { get; private set; }
        public Zombie(Accessory? accessory)
        {
            Accessory = accessory;
            if (Accessory != null)
            {
                Accessory.OnDeath += HandleAccessoryDeath;
            }
            symbol = accessory switch
            {
                Cone => 'C',
                Bucket => 'B',
                Door => 'S',
                _ => 'Z',
            };
        }

        public int takeDamage(int damage)
        {
            if (Accessory != null)
            {
                damage = Accessory.takeDamage(damage);
                Health -= damage;
            }
            else
            {
                Health -= damage;
            }

            if (Health <= 0)
            {
                die();
            }

            return Health <= 0 ? 0 : Health;
        }

        public void die()
        {
        }

        private void HandleAccessoryDeath()
        {
            Accessory = null;
            symbol = 'Z';
        }
    }
}
