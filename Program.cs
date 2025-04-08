namespace PeaShooter;

public class Program
{
    private static readonly GameObjectManager GMO = new();
    public static void Main()
    {
        while (GMO.IsRunning)
        {
            int selection = GetOption();
            if (selection == 1)
            {
                ZType zombieType = GetZombieType();
                GMO.CreateZombie(zombieType);
            }
            else
            {
                SimulateGame();
            }
        }
    }

    private static int GetOption()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1. Create Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2. Run Game?");
        Console.ResetColor();

        return GetValidInput(1, 2);
    }

    private static ZType GetZombieType()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1. Normal Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2. Cone Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("3. Bucket Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("4. ScreenDoor Zombie?");
        Console.ResetColor();

        int option = GetValidInput(1, 4);
        return ZTypeExtensions.IntToZType[option];
    }

    private static int GetValidInput(int min, int max)
    {
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || option < min || option > max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid option. Please enter a number between {min} and {max}.");
            Console.ResetColor();
        }
        return option;
    }

    private static void SimulateGame()
    {
        int round = 0;
        Console.Write($"Round {round}: ");
        PrintZombies();
        while (GMO.IsRunning)
        {
            round++;
            Thread.Sleep(500);
            Console.Write($"Round {round}: ");
            AType attack = GetAType();
            GMO.RunRound(attack);
            PrintZombies();
        }
    }

    private static AType GetAType()
    {
        Console.WriteLine("Please select a plant to attack with:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1. Peashooter");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2. Watermelon");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("3. MagnetShroom");
        Console.ResetColor();

        int option = GetValidInput(1, 3);
        return ATypeExtensions.IntToAType[option];
    }

    private static void PrintZombies()
    {
        Console.Write("[ ");
        foreach (var adversary in GMO.Adversaries)
        {
            int totalHealth = adversary.Health;
            if (adversary is Accessory accessory)
            {
                totalHealth += accessory.Wrappie?.Health ?? 0;
            }
            Console.Write($"{ZTypeExtensions.ZTypeToString[adversary.Type]}/{totalHealth} ");
        }
        Console.WriteLine("]");
    }
}
