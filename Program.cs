using PeaShooter;

public class Program
{
    private static GameManager game = new();
    public static void Main()
    {
        int selection = 0;
        do
        {
            selection = getOption();
            if (selection == 1)
            {
                int zombieType = getZombieType();
                game.createZombie(zombieType);
            }
            else
            {
                game.damage = getDamage();
                simulateGame();
            }

        } while (game.isRunning);
    }

    private static int getOption()
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

    private static int getZombieType()
    {
        int option = 0;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1. Normal Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2. Cone Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("3. Bucket Zombie?");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("4. Door Zombie?");
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
        return option;
    }

    private static int getDamage()
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

    private static void simulateGame() // Change to static
    {
        int round = 0;
        Console.Write($"Round {round}: ");
        printZombies();
        while (game.isRunning)
        {
            round++;
            Thread.Sleep(500);
            Console.Write($"Round {round}: ");
            game.runRound();
            printZombies();
        }
    }

    private static void printZombies()
    {
        var zombies = game.zombies;

        Console.Write("[ ");
        foreach (var z in zombies)
        {
            int totalHealth = z.Health + (z.Accessory?.Health ?? 0);
            Console.Write($"{z.symbol}/{totalHealth} ");
        }
        Console.WriteLine("]");
    }
}
