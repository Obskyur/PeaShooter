namespace PeaShooter
{
    internal class AccessoryFactory : IAccessoryFactory
    {
        public Accessory? Create(int option)
        {
            return option switch
            {
                1 => null,
                2 => new Cone(),
                3 => new Bucket(),
                4 => new Door(),
                _ => throw new ArgumentException("Invalid option"),
            };
        }
    }
}
