using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter;

internal class GameObjectManager
{
    public bool IsRunning { get; private set; } = true;
    public List<IDamageable> Adversaries { get; } = new();
    private readonly ZBuilder _zb;
    private readonly ZDirector _zDir;
    private readonly GameEventManager _gem;

    public GameObjectManager()
    {
        _zb = new();
        _zDir = new(_zb);
        _gem = new(this);
    }

    public void CreateZombie(ZType type)
    {
        IDamageable adversary = _zDir.Construct(type);
        Adversaries.Add(adversary);
        if (adversary is Accessory acc)
        {
            acc.OnDeath += () => HandleAccessoryDeath(acc);
            ((Zombie)acc.Wrappie!).OnDeath += () => HandleAccessoryDeath(acc);
            ((Zombie)acc.Wrappie!).OnDeath += () => HandleZombieDeath(acc.Wrappie!);
        }
        else
        {
            ((Zombie)adversary).OnDeath += () => HandleZombieDeath(adversary);
        }
    }

    public void RunRound(AType attack)
    {
        if (Adversaries.Count > 0)
        {
            _gem.SimulateCollisionDetection(attack);
            if (Adversaries.Count == 0)
            {
                IsRunning = false;
            }
        }
    }

    private void HandleAccessoryDeath(Accessory acc)
    {
        int index = Adversaries.IndexOf(acc);
        if (index != -1 && acc.Wrappie != null)
        {
            Adversaries[index] = acc.Wrappie;
        }
    }

    private void HandleZombieDeath(IDamageable adversary)
    {
        Adversaries.Remove(adversary);
    }
}
