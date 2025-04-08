namespace PeaShooter;

internal enum AType
{
    Peashooter,
    Watermelon,
    MagnetShroom,
}

internal class ATypeExtensions
{
    public static Dictionary<int, AType> IntToAType = new()
    {
        { 1, AType.Peashooter },
        { 2, AType.Watermelon },
        { 3, AType.MagnetShroom },
    };

    public static Dictionary<AType, int> ATypeToDmg = new()
    {
        { AType.Peashooter, 25 },
        { AType.Watermelon, 40 },
        { AType.MagnetShroom, 0 },
    };
}
