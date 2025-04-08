namespace PeaShooter;

public class Program
{
    private static readonly GameManager game = new();
    public static void Main()
    {
        do
        {
            int selection = GetOption();
            if (selection == 1)
            {
                ZType zombieType = GetZombieType();
                game.CreateZombie(zombieType);
            }
            else
            {
                game.damage = GetDamage();
                SimulateGame();
            }

        } while (game.isRunning);
    }

    private static int GetOption()
    {
        int option = 0;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1. Create Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2. Run Game?");
        Console.ResetColor();

        while (option < 1 || option > 2)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out option) || option <= 1 && option >= 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option. Please enter 1 or 2.");
                Console.ResetColor();
            }
        }
        return option;
    }

    private static ZType GetZombieType()
    {
        int option = 0;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1. Normal Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2. Cone Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("3. Bucket Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("4. ScreenDoor Zombie?");
        Console.ResetColor();

        while (option < 1 || option > 4)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out option) || option <= 1 && option >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option. Please enter 1, 2, 3, or 4.");
                Console.ResetColor();
            }
        }
        return ZTypeExtensions.IntToZType[option];
    }

    private static int GetDamage()
    {
        Console.WriteLine("Please enter damage value. Default is 25.");
        int damage = 25;
        while (true)
        {
            string? input = Console.ReadLine();
            if (input == string.Empty || int.TryParse(input, out damage))
            {
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ResetColor();
            }
        }
        return damage;
    }

    private static void SimulateGame() // Change to static
    {
        int round = 0;
        Console.Write($"Round {round}: ");
        PrintZombies();
        while (game.isRunning)
        {
            round++;
            Thread.Sleep(500);
            Console.Write($"Round {round}: ");
            game.RunRound();
            PrintZombies();
        }
    }

    private static void PrintZombies()
    {
        var adversaries = game.adversaries;

        Console.Write("[ ");
        foreach (var adversary in adversaries)
        {
            int totalHealth = adversary.Health;
            if (adversary is Accessory accessory)
            {
                totalHealth += accessory.wrappie?.Health ?? 0;
            }
            Console.Write($"{ZTypeExtensions.ZTypeToString[adversary.Type]}/{totalHealth} ");
        }
        Console.WriteLine("]");
    }
}