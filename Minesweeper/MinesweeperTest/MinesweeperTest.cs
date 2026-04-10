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
    [Fact]
    public void BoardTesting2()
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
        Assert.Equal(0, CountAdjacentMines(board, 0, 0));
    }
    [Fact]
    public void BoardTesting3()
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
        Assert.Equal(1, CountAdjacentMines(board, 1, 1));
    }
    [Fact]
    public void BoardTesting4()
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
        Assert.Equal(1, CountAdjacentMines(board, 2, 2));
    }
    [Fact]
    public void BoardTesting5()
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
        Assert.Equal(1, CountAdjacentMines(board, 3, 3));
    }
    [Fact]
    public void BoardTesting6()
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
        Assert.Equal(1, CountAdjacentMines(board, 4, 4));
    }
    [Fact]
    public void BoardTesting7()
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
        Assert.Equal(0, CountAdjacentMines(board, 0, 4));
    }
    private int CountMines(Board board)
    {
        int count = 0;
        for (int r = 0; r < board.Rows; r++)
            for (int c = 0; c < board.Cols; c++)
                if (board.Cells[r, c].IsMine)
                    count++;
        return count;
    }
    [Fact]
    public void BoardTesting8()
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
        Assert.Equal(0, CountAdjacentMines(board, 4, 0));
    }
    [Fact]
    public void BoardTesting9()
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
        Assert.Equal(0, CountAdjacentMines(board, 2, 0));
    }
    [Fact]
    public void BoardTesting10()
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
        Assert.Equal(0, CountAdjacentMines(board, 0, 2));
    }
}

