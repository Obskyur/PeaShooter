namespace PeaShooter;

internal class ScreenDoor : Accessory
{
    public override int Health { get; set; } = 25;
    public override bool IsMetal => true;
    public override ZType Type => ZType.ScreenDoor;
}
