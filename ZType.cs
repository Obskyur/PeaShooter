namespace PeaShooter;
internal enum ZType
{
    Regular,
    Cone,
    Bucket,
    ScreenDoor
}

internal static class ZTypeExtensions
{
    internal static readonly Dictionary<ZType, string> ZTypeToString = new()
    {
        { ZType.Regular, "R" },
        { ZType.Cone, "C" },
        { ZType.Bucket, "B" },
        { ZType.ScreenDoor, "S" }
    };

    internal static readonly Dictionary<int, ZType> IntToZType = new()
    {
        { 1, ZType.Regular },
        { 2, ZType.Cone },
        { 3, ZType.Bucket },
        { 4, ZType.ScreenDoor }
    };
}