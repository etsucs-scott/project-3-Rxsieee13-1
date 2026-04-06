using Minesweeper.Core;

class Program
{
    static void Main()
    {
        Console.Write("Enter seed (blank = random): ");
        string input = Console.ReadLine();

        int seed = string.IsNullOrWhiteSpace(input)
            ? Environment.TickCount
            : int.Parse(input);

        Game game = new Game(10, 10, 15, seed);
        game.Start();
    }
}
