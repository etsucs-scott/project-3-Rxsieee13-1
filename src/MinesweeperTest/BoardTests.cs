using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core;
using Assert = Xunit.Assert;
namespace MinesweeperTest;

[TestClass]
public class BoardTests
{
        [TestMethod]
        public void Board_CreatesSuccessfully()
        {
            Board board = new Board(5, 5, 3, 1);
            Assert.NotNull(board);
        }

        [TestMethod]
        public void Reveal_RevealsTile()
        {
            Board board = new Board(5, 5, 0, 1);

            board.Reveal(2, 2);

            Assert.True(board.IsRevealed(2, 2));
        }

        [TestMethod]
        public void Reveal_OutOfBounds_DoesNothing()
        {
            Board board = new Board(5, 5, 0, 1);

            board.Reveal(-1, -1);

            Assert.False(board.IsRevealed(0, 0));
        }

        [TestMethod]
        public void ToggleFlag_SetsFlag()
        {
            Board board = new Board(5, 5, 0, 1);

            board.ToggleFlag(1, 1);

            Assert.True(board.IsFlagged(1, 1));
        }

        [TestMethod]
        public void ToggleFlag_Twice_RemovesFlag()
        {
            Board board = new Board(5, 5, 0, 1);

            board.ToggleFlag(1, 1);
            board.ToggleFlag(1, 1);

            Assert.False(board.IsFlagged(1, 1));
        }

        [TestMethod]
        public void CheckWin_True_WhenAllSafeTilesRevealed()
        {
            Board board = new Board(2, 2, 0, 1);

            board.Reveal(0, 0);
            board.Reveal(0, 1);
            board.Reveal(1, 0);
            board.Reveal(1, 1);

            Assert.True(board.CheckWin());
        }

        [TestMethod]
        public void CheckWin_False_WhenTilesHidden()
        {
            Board board = new Board(2, 2, 0, 1);

            board.Reveal(0, 0);

            Assert.False(board.CheckWin());
        }

        [TestMethod]
        public void RevealAll_RevealsEverything()
        {
            Board board = new Board(3, 3, 0, 1);

            board.RevealAll();

            Assert.True(board.IsRevealed(0, 0));
            Assert.True(board.IsRevealed(1, 1));
            Assert.True(board.IsRevealed(2, 2));
        }

        [TestMethod]
        public void MinePlacement_IsDeterministic_WithSeed()
        {
            Board board1 = new Board(5, 5, 5, 42);
            Board board2 = new Board(5, 5, 5, 42);

            Assert.Equal(board1.GetMineLayout(), board2.GetMineLayout());
        }

        [TestMethod]
        public void MinePlacement_DifferentSeeds_DifferentBoards()
        {
            Board board1 = new Board(5, 5, 5, 1);
            Board board2 = new Board(5, 5, 5, 2);

            Assert.NotEqual(board1.GetMineLayout(), board2.GetMineLayout());
        }

        [TestMethod]
        public void CannotRevealFlaggedTile()
        {
            Board board = new Board(5, 5, 0, 1);

            board.ToggleFlag(2, 2);
            board.Reveal(2, 2);

            Assert.False(board.IsRevealed(2, 2));
        }

        [TestMethod]
        public void RecursiveReveal_OpensAdjacentTiles()
        {
            Board board = new Board(3, 3, 0, 1);

            board.Reveal(1, 1);

            Assert.True(board.IsRevealed(0, 0));
            Assert.True(board.IsRevealed(2, 2));
        }
}
