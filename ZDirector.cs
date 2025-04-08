namespace PeaShooter;
internal class ZDirector(IBuilder builder)
{
    private readonly IBuilder builder = builder;

    public IDamageable Construct(ZType type) => type switch
    {
        ZType.Regular => new Zombie(),
        ZType.Cone => Make(new Cone()),
        ZType.Bucket => Make(new Bucket()),
        ZType.ScreenDoor => Make(new ScreenDoor()),
        _ => throw new ArgumentException("Invalid zombie type")
    };

    private Accessory Make(Accessory accessory)
    {
        builder.Reset();
        builder.SetAccessory(accessory);
        return (Accessory)builder.GetProduct();
    }
}
