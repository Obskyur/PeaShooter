namespace PeaShooter
{
    internal abstract class Accessory : IDamageable
    {
        public event Action? OnDeath;
        public abstract int Health { get; set; }
        public virtual bool IsMetal { get; set; } = false;
        public IDamageable? Wrappie { get; set; }

        public abstract ZType Type { get; }

        public void Die()
        {
            if (Wrappie != null)
            {
                int remainingDamage = Math.Abs(Health);
                Wrappie.TakeDamage(remainingDamage);
            }
            OnDeath?.Invoke();
        }

        public int TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
            return Health;
        }

        public void Wrap(IDamageable i)
        {
            Wrappie = i;
        }

        public override string ToString()
        {
            return ZTypeExtensions.ZTypeToString[Type] ?? string.Empty;
        }
    }
}
