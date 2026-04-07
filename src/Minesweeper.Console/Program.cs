using Minesweeper.Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== MINESWEEPER ===");
        Console.WriteLine("Choose Difficulty:");
        Console.WriteLine("1. Easy   8x8");
        Console.WriteLine("2. Medium 12x12");
        Console.WriteLine("3. Hard   16x16");

        int rows = 8, cols = 8, mines = 10;

        while (true)
        {
            Console.Write("Enter choice (1-3): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                rows = 8; cols = 8; mines = 10;
                break;
            }
            else if (choice == "2")
            {
                rows = 12; cols = 12; mines = 25;
                break;
            }
            else if (choice == "3")
            {
                rows = 16; cols = 16; mines = 40;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }

        Console.Write("\nEnter seed (blank = random): ");
        string input = Console.ReadLine();

        int seed = string.IsNullOrWhiteSpace(input)
            ? Environment.TickCount
            : int.Parse(input);

        Game game = new Game(rows, cols, mines, seed);
        game.Start();
    }
}