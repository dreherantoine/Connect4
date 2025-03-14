﻿using FluentAssertions;
using Connect4.Models;
using Connect4.Models.Boards;
using System.Collections.ObjectModel;

namespace Connect4Test
{
    public class BoardTest
    {
        [Fact]
        public void Initialize_ReturnGrid()
        {
            // Arrange
            Board board = new Board();

            // Act
            ObservableCollection<Slot> grid = board.Grid;

            // Assert
            grid
                .Should()
                .NotBeEmpty()
                .And.HaveCount(42)
                .And.ContainItemsAssignableTo<Slot>();

            grid
                .Where(Slot => Slot.Row == 0)
                .Should()
                .NotBeEmpty()
                .And.HaveCount(7);

            grid
                .Where(Slot => Slot.Column == 0)
                .Should()
                .NotBeEmpty()
                .And.HaveCount(6);
        }

        [Fact]
        public void PlayerMove_Valid_ReturnTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player("Red");
            int column = 1;

            // Act
            bool expectedPlayerMove = board.PlayerMove(column, player.Color);

            // Assert
            expectedPlayerMove
                .Should()
                .BeTrue();
        }

        [Fact]
        public void PlayerMove_Invalid_ReturnFalse()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player("Red");
            int column = -1;

            // Act
            bool expectedPlayerMove = board.PlayerMove(column, player.Color);

            // Assert
            expectedPlayerMove
                .Should()
                .BeFalse();
        }

        [Fact]
        public void IsGameWin_Valid_ReturnTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player("Red");

            for (int column = 0; column < 4; column++)
            {
                board.PlayerMove(column, player.Color);
            }

            // Act
            bool expectedIsGameWin = board.IsGameWin();

            // Assert
            expectedIsGameWin
                .Should()
                .BeTrue();
        }
    }
}
