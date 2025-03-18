using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal class GameManager
    {
        public bool isRunning = true;
        public Queue<Zombie> zombies = new();
        public int damage = 25;
        private ZombieFactory zf = new();
        private AccessoryFactory af = new();

        public void createZombie(int option)
        {
            zombies.Enqueue(zf.Create(af.Create(option)));
        }

        public void runRound()
        {
            Zombie z = zombies.Peek();
            simulateShot(z);
            if (zombies.Count == 0)
            {
                isRunning = false;
            }
        }

        private void simulateShot(Zombie z)
        {
            z.takeDamage(damage);
            if (z.Health <= 0)
            {
                zombies.Dequeue();
            }
        }
    }
}
