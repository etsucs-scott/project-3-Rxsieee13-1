using Minesweeper.Core;
namespace MinesweeperTest;

public class BoardTest
{
    [Fact]
    public void BoardTesting()
    {
        // Arrange
        Board board = new Board();
        int rows = 5;
        int cols = 5;
        int mines = 5;
        int seed = 42;
        // Act
        var board = new Board(rows, cols, mines, seed);
        // Assert
        Assert.Equal(mines, CountMines(board));
    }
}
