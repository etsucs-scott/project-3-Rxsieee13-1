namespace Minesweeper.Core;

public class Tile
{
    public bool IsMine { get; set; }
    public bool IsRevealed { get; set; }
    public bool IsFlagged { get; set; }
    public int AdjacentMines { get; set; }

    public char Display()
    {
        if (IsFlagged) return 'F';
        if (!IsRevealed) return '#';
        if (IsMine) return 'M';
        return AdjacentMines == 0 ? '.' : AdjacentMines.ToString()[0];
    }
}