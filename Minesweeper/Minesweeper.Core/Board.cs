namespace Minesweeper.Core;

public class Board
{
    // Represents the game board with tiles, mines, and numbers.
    private Tile[,] grid;
    private int rows;
    private int cols;
    private int mineCount;

    // Initializes the board with the specified dimensions and mine count,
    // using a seed for reproducibility.
    public Board(int rows, int cols, int mines, int seed)
    {
        this.rows = rows;
        this.cols = cols;
        this.mineCount = mines;

        grid = new Tile[rows, cols];

        Initialize();
        PlaceMines(seed);
        CalculateNumbers();
    }

    // Initializes the grid with empty tiles.
    private void Initialize()
    {
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                grid[r, c] = new Tile();
    }

    // Places mines randomly on the board based on the provided seed.
    private void PlaceMines(int seed)
    {
        Random rand = new Random(seed);
        int placed = 0;

        while (placed < mineCount)
        {
            int r = rand.Next(rows);
            int c = rand.Next(cols);

            if (!grid[r, c].IsMine)
            {
                grid[r, c].IsMine = true;
                placed++;
            }
        }
    }

    // Calculates the number of adjacent mines for each tile on the board.
    private void CalculateNumbers()
    {
        int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r, c].IsMine) continue;

                int count = 0;

                for (int i = 0; i < 8; i++)
                {
                    int nr = r + dr[i];
                    int nc = c + dc[i];

                    if (InBounds(nr, nc) && grid[nr, nc].IsMine)
                        count++;
                }

                grid[r, c].AdjacentMines = count;
            }
        }
    }

    // Reveals a tile at the specified coordinates.
    // If the tile has no adjacent mines, it recursively reveals neighboring tiles.
    public void Reveal(int r, int c)
    {
        if (!InBounds(r, c)) return;

        Tile tile = grid[r, c];

        if (tile.IsRevealed || tile.IsFlagged)
            return;

        tile.IsRevealed = true;

        if (tile.AdjacentMines == 0 && !tile.IsMine)
        {
            for (int dr = -1; dr <= 1; dr++)
                for (int dc = -1; dc <= 1; dc++)
                    Reveal(r + dr, c + dc);
        }
    }

    // Toggles a flag on the tile at the specified coordinates.
    public void ToggleFlag(int r, int c)
    {
        if (InBounds(r, c))
            grid[r, c].IsFlagged = !grid[r, c].IsFlagged;
    }

    // Checks if the tile at the specified coordinates contains a mine.
    public bool IsMine(int r, int c) => grid[r, c].IsMine;

    // Checks if all non-mine tiles have been revealed, indicating a win.
    public bool CheckWin()
    {
        foreach (var tile in grid)
            if (!tile.IsMine && !tile.IsRevealed)
                return false;

        return true;
    }

    // Reveals all tiles on the board, typically used when the game is over.
    public void RevealAll()
    {
        foreach (var tile in grid)
            tile.IsRevealed = true;
    }

    // Prints the current state of the board to the console.
    public void Print()
    {
        Console.Clear();

        Console.Write("  ");
        for (int c = 0; c < cols; c++)
            Console.Write(c + " ");
        Console.WriteLine();

        for (int r = 0; r < rows; r++)
        {
            Console.Write(r + " ");
            for (int c = 0; c < cols; c++)
                Console.Write(grid[r, c].Display() + " ");

            Console.WriteLine();
        }
    }

    // Helper method to check if the given coordinates are within the bounds of the board.
    private bool InBounds(int r, int c)
    {
        return r >= 0 && r < rows && c >= 0 && c < cols;
    }

    // Helper methods to check the state of a tile at the specified coordinates.
    public bool IsRevealed(int r, int c) => grid[r, c].IsRevealed;
    public bool IsFlagged(int r, int c) => grid[r, c].IsFlagged;

    // For testing purposes: returns a string representation
    // of the mine layout (1 for mine, 0 for empty).
    public string GetMineLayout()
    {
        string layout = "";

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                layout += grid[r, c].IsMine ? "1" : "0";

        return layout;
    }
}