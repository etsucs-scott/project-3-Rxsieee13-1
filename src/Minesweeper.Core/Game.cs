namespace Minesweeper.Core;

public class Game
{
    // Manages the overall game flow, user input,
    // and interactions with the Board and ScoreManager.
    private Board board;
    private int score;
    private DateTime startTime;
    private ScoreManager scoreManager;

    // Initializes the game with the specified board dimensions,
    // mine count, and seed for reproducibility.
    public Game(int rows, int cols, int mines, int seed)
    {
        board = new Board(rows, cols, mines, seed);
        scoreManager = new ScoreManager();
        score = 0;
    }

    // Starts the main game loop, handling user input and game state updates.
    public void Start()
    {
        startTime = DateTime.Now;

        while (true)
        {
            board.Print();
            DisplayStats();

            Console.Write("Command (r row col | f row col | q): ");
            string input = Console.ReadLine();

            string trimmed = input.Trim().ToLower();


            if (trimmed == "q" || trimmed == "quit" || trimmed == "exit")
            {
                QuitGame();
                break;
            }

            if (!ParseInput(input, out char cmd, out int r, out int c))
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.ReadKey();
                continue;
            }

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

    // Displays the current score and elapsed time to the player.
    private void DisplayStats()
    {
        TimeSpan elapsed = DateTime.Now - startTime;
        Console.WriteLine($"\nScore: {score} | Time: {elapsed.Seconds}s\n");
    }

    // Parses user input into a command and coordinates.
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

    // Handles the game over scenario by revealing the board, displaying a message,
    private void GameOver()
    {
        board.RevealAll();
        board.Print();

        Console.WriteLine("Game Over!");

        scoreManager.SaveScore(score, DateTime.Now - startTime);
    }

    // Handles the win scenario by revealing the board, displaying a message,
    private void Win()
    {
        board.RevealAll();
        board.Print();

        Console.WriteLine("You Win!");

        scoreManager.SaveScore(score, DateTime.Now - startTime);
    }

    // Handles quitting the game by clearing the console, displaying final stats,
    private void QuitGame()
    {
        Console.Clear();
        Console.WriteLine("You quit the game.");

        TimeSpan elapsed = DateTime.Now - startTime;

        Console.WriteLine($"Final Score: {score}");
        Console.WriteLine($"Time Played: {elapsed.Seconds}s");

        scoreManager.SaveScore(score, elapsed);
    }
}
