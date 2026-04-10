namespace Minesweeper.Core;

public class Tile
{
    // Represents a single tile on the board, which can be a mine, a number, or empty.
    public bool IsMine { get; set; }
    public bool IsRevealed { get; set; }
    public bool IsFlagged { get; set; }
    public int AdjacentMines { get; set; }

    // Returns a character representation of the tile for display purposes.
    public char Display()
    {
        if (IsFlagged) return 'F';
        if (!IsRevealed) return '#';
        if (IsMine) return 'M';
        return AdjacentMines == 0 ? '.' : AdjacentMines.ToString()[0];
    }
}