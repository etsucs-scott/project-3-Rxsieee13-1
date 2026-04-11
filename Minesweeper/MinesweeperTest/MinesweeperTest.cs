using Minesweeper.Core;
namespace MinesweeperTest;

public class BoardTests
{
    // Test that the board initializes with the correct dimensions and mine count
    [Fact]
    public void Reveal_RevealsTile()
    {
        // Arrange
        Board board = new Board(5, 5, 0, 1);

        // Act
        board.Reveal(2, 2);

        // Assert
        Assert.IsTrue(board.IsRevealed(2, 2));
    }

    // Test that revealing a flagged tile does not reveal it
    [Fact]
    public void Reveal_DoesNotRevealFlaggedTile()
    {
        // Arrange
        Board board = new Board(5, 5, 0, 1);
        board.ToggleFlag(1, 1);

        // Act
        board.Reveal(1, 1);

        // Assert
        Assert.IsFalse(board.IsRevealed(1, 1));
    }

    // Test that toggling a flag on a tile sets the flag, and toggling it again removes the flag
    [Fact]
    public void ToggleFlag_SetsFlag()
    {
        // Arrange
        Board board = new Board(5, 5, 0, 1);

        // Act
        board.ToggleFlag(2, 2);

        // Assert
        Assert.IsTrue(board.IsFlagged(2, 2));
    }

    // Test that toggling a flag on a tile that is already flagged removes the flag
    [Fact]
    public void ToggleFlag_RemovesFlag_WhenCalledTwice()
    {
        // Arrange
        Board board = new Board(5, 5, 0, 1);
        board.ToggleFlag(2, 2);

        // Act
        board.ToggleFlag(2, 2);

        // Assert
        Assert.IsFalse(board.IsFlagged(2, 2));
    }

    // Test that CheckWin returns true when all non-mine tiles are revealed, and false otherwise
    [Fact]
    public void CheckWin_ReturnsTrue_WhenAllSafeTilesRevealed()
    {
        // Arrange
        Board board = new Board(2, 2, 0, 1);

        // Act
        board.Reveal(0, 0);
        board.Reveal(0, 1);
        board.Reveal(1, 0);
        board.Reveal(1, 1);

        // Assert
        Assert.IsTrue(board.CheckWin());
    }

    // Test that CheckWin returns false if there are still hidden tiles,
    // even if all revealed tiles are safe
    [Fact]
    public void CheckWin_ReturnsFalse_WhenTilesRemainHidden()
    {
        // Arrange
        Board board = new Board(2, 2, 0, 1);

        // Act
        board.Reveal(0, 0);

        // Assert
        Assert.IsFalse(board.CheckWin());
    }

    // Test that RevealAll reveals all tiles on the board
    [Fact]
    public void RevealAll_RevealsAllTiles()
    {
        // Arrange
        Board board = new Board(3, 3, 0, 1);

        // Act
        board.RevealAll();

        // Assert
        Assert.IsTrue(board.IsRevealed(0, 0));
        Assert.IsTrue(board.IsRevealed(1, 1));
        Assert.IsTrue(board.IsRevealed(2, 2));
    }

    // Test that revealing a tile outside the bounds of the board does not throw an exception
    // and does not change the state of the board
    [Fact]
    public void Reveal_OutOfBounds_DoesNothing()
    {
        // Arrange
        Board board = new Board(3, 3, 0, 1);

        // Act
        board.Reveal(-1, -1);

        // Assert
        Assert.IsFalse(board.IsRevealed(0, 0));
    }

    // Test that the mine placement is deterministic when using the same seed,
    // and differs when using different seeds
    [Fact]
    public void MinePlacement_IsDeterministic_WithSameSeed()
    {
        // Arrange
        Board board1 = new Board(5, 5, 5, 42);
        Board board2 = new Board(5, 5, 5, 42);

        // Act
        string layout1 = board1.GetMineLayout();
        string layout2 = board2.GetMineLayout();

        // Assert
        Assert.AreEqual(layout1, layout2);
    }

    // Test that the mine placement differs when using different seeds
    [Fact]
    public void MinePlacement_Differs_WithDifferentSeeds()
    {
        // Arrange
        Board board1 = new Board(5, 5, 5, 1);
        Board board2 = new Board(5, 5, 5, 2);

        // Act
        string layout1 = board1.GetMineLayout();
        string layout2 = board2.GetMineLayout();

        // Assert
        Assert.AreNotEqual(layout1, layout2);
    }
}
