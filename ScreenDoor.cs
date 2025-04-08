namespace PeaShooter
{
    internal class ScreenDoor : Accessory
    {
        public override int Health { get; set; } = 25;
        public new bool isMetal = true;
        public override ZType Type => ZType.ScreenDoor;
    }
}
