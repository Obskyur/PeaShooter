namespace PeaShooter;

internal class GameEventManager(GameObjectManager gmo)
{
    private readonly GameObjectManager _gmo = gmo;

    public static void DoDamage(int damage, IDamageable target)
    {
        target.TakeDamage(damage);
    }

    public static void ApplyMagnetForce(IDamageable target)
    {
        if (target is Accessory acc && acc.IsMetal)
        {
            target.Health = 0;
            target.Die();
        }
    }

    public void SimulateCollisionDetection(AType attack)
    {
        int damage = ATypeExtensions.ATypeToDmg[attack];
        IDamageable adversary = _gmo.Adversaries[0];

        switch (attack)
        {
            case AType.Peashooter:
                DoDamage(damage, adversary);
                break;
            case AType.Watermelon:
                if (adversary is ScreenDoor sd)
                {
                    DoDamage(damage, ((Zombie)sd.Wrappie!));
                }
                else
                {
                    DoDamage(damage, adversary);
                }
                break;
            case AType.MagnetShroom:
                ApplyMagnetForce(adversary);
                break;
        }
    }
}
