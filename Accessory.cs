namespace PeaShooter
{
    internal abstract class Accessory : IDamageable
    {
        public event Action? OnDeath;
        public abstract int Health { get; set; }
        public bool isMetal = false;
        public IDamageable? wrappie;

        public abstract ZType Type { get; }

        public void Die()
        {
            OnDeath?.Invoke();
        }

        public int TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
            return Health <= 0 ? Math.Abs(Health) : 0;
        }

        public void Wrap(IDamageable i)
        {
            wrappie = i;
        }

        public new string ToString()
        {
            return ZTypeExtensions.ZTypeToString[Type] ?? String.Empty;
        }
    }
}
