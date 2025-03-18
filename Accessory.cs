namespace PeaShooter
{
    internal abstract class Accessory : IDamageable
    {
        public event Action? OnDeath;
        public abstract int Health { get; set; }

        public void die()
        {
            OnDeath?.Invoke();
        }

        public int takeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                die();
            }
            return Health <= 0 ? Math.Abs(Health) : 0;
        }
    }
}
