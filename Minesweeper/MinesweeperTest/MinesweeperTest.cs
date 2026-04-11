using Minesweeper.Core;
namespace MinesweeperTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class BoardTests
{
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
