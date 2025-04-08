namespace PeaShooter;
internal class ZBuilder : IBuilder
{
    private IDamageable product = new Zombie();
    public void Reset()
    {
        product = new Zombie();
    }
    public void SetAccessory(Accessory accessory)
    {
        accessory.Wrap(product);
        product = accessory;
    }

    public IDamageable GetProduct()
    {
        return product;
    }
}
