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
        public Queue<IDamageable> adversaries = new();
        public int damage = 25;
        private readonly ZBuilder zb;
        private readonly ZDirector zDir;

        public GameManager()
        {
            zb = new();
            zDir = new(zb);
        }

        public void CreateZombie(ZType type)
        {
            adversaries.Enqueue(zDir.Construct(type));
        }

        public void RunRound()
        {
            IDamageable adversary = adversaries.Peek();
            SimulateShot(adversary);
            if (adversaries.Count == 0)
            {
                isRunning = false;
            }
        }

        private void SimulateShot(IDamageable adversary)
        {
            adversary.TakeDamage(damage);
            if (adversary.Health <= 0)
            {
                adversaries.Dequeue();
            }
        }
    }
}
