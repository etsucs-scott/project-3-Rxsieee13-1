namespace Minesweeper.Core;

public class Game
{
    private Board board;
    private int score;
    private DateTime startTime;
    private ScoreManager scoreManager;

    public Game(int rows, int cols, int mines, int seed)
    {
        board = new Board(rows, cols, mines, seed);
        scoreManager = new ScoreManager();
        score = 0;
    }

    public void Start()
    {
        startTime = DateTime.Now;

        while (true)
        {
            board.Print();
            DisplayStats();

            Console.Write("Command (r row col | f row col): ");
            string input = Console.ReadLine();

            if (!ParseInput(input, out char cmd, out int r, out int c))
                continue;

            if (cmd == 'f')
            {
                board.ToggleFlag(r, c);
            }
            else if (cmd == 'r')
            {
                if (board.IsMine(r, c))
                {
                    GameOver();
                    break;
                }

                board.Reveal(r, c);
                score += 10;

                if (board.CheckWin())
                {
                    Win();
                    break;
                }
            }
        }
    }

    private void DisplayStats()
    {
        TimeSpan elapsed = DateTime.Now - startTime;
        Console.WriteLine($"\nScore: {score} | Time: {elapsed.Seconds}s\n");
    }

    private bool ParseInput(string input, out char cmd, out int r, out int c)
    {
        cmd = ' ';
        r = c = 0;

        string[] parts = input.Split();

        if (parts.Length != 3) return false;

        cmd = parts[0][0];

        return int.TryParse(parts[1], out r) &&
               int.TryParse(parts[2], out c);
    }

    private void GameOver()
    {
        board.RevealAll();
        board.Print();

        Console.WriteLine("Game Over!");

        scoreManager.SaveScore(score, DateTime.Now - startTime);
    }

    private void Win()
    {
        board.RevealAll();
        board.Print();

        Console.WriteLine("You Win!");

        scoreManager.SaveScore(score, DateTime.Now - startTime);
    }
}
