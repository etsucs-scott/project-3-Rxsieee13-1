namespace Minesweeper.Core;


public class Board
{
    private Tile[,] grid;
    private int rows;
    private int cols;
    private int mineCount;

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

    private void Initialize()
    {
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                grid[r, c] = new Tile();
    }

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

    public void ToggleFlag(int r, int c)
    {
        if (InBounds(r, c))
            grid[r, c].IsFlagged = !grid[r, c].IsFlagged;
    }

    public bool IsMine(int r, int c) => grid[r, c].IsMine;

    public bool CheckWin()
    {
        foreach (var tile in grid)
            if (!tile.IsMine && !tile.IsRevealed)
                return false;

        return true;
    }

    public void RevealAll()
    {
        foreach (var tile in grid)
            tile.IsRevealed = true;
    }

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

    private bool InBounds(int r, int c)
    {
        return r >= 0 && r < rows && c >= 0 && c < cols;
    }

    public bool IsRevealed(int r, int c)
    {
        return grid[r, c].IsRevealed;
    }

    public bool IsFlagged(int r, int c)
    {
        return grid[r, c].IsFlagged;
    }

    public string GetMineLayout()
    {
        string layout = "";

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                layout += grid[r, c].IsMine ? "1" : "0";

        return layout;
    }
}