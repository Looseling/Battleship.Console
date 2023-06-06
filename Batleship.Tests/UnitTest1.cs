using Battleship.Constants;
using Battleship.Models;
using NUnit.Framework;
using System;

namespace Battleship.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void AllShipsSunk_ShouldReturnTrue_WhenAllShipsAreSunk()
        {
            // Arrange
            var board = new Board();
            var coordinate = new Coordinate(0, 0);

            // Hit all the ships on the board
            foreach (var ship in  board.Ships)
            {
                foreach (var shipCoordinate in ship.Coordinates)
                {
                    board.TakeShot(shipCoordinate);
                }
            }

            // Act
            var allShipsSunk = board.AllShipsSunk();

            // Assert
            Assert.IsTrue(allShipsSunk);
        }

        [Test]
        public void TakeShot_ShouldReturnShotResultInvalid_WhenCoordinateIsOutOfRange()
        {
            // Arrange
            var board = new Board();
            var coordinate = new Coordinate(11, 0);

            // Act
            var shotResult = board.TakeShot(coordinate);

            // Assert
            Assert.AreEqual(ShotResult.Invalid, shotResult);
        }

        [Test]
        public void TakeShot_ShouldReturnShotResultSink_WhenShipIsSunk()
        {
            // Arrange
            var board = new Board();
            var ship =  board.Ships[0]; // Get the first ship on the board
            var coordinate = ship.Coordinates[0];

            // Hit all the ship's coordinates except one
            for (int i = 1; i < ship.Size; i++)
            {
                board.TakeShot(ship.Coordinates[i]);
            }

            // Act
            var shotResult = board.TakeShot(coordinate);

            // Assert
            Assert.AreEqual(ShotResult.Sink, shotResult);
        }

        [Test]
        public void TakeShot_ShouldReturnShotResultHit_WhenShipIsHit()
        {
            // Arrange
            var board = new Board();
            var ship =  board.Ships[0]; // Get the first ship on the board
            var coordinate = ship.Coordinates[0];

            // Act
            var shotResult = board.TakeShot(coordinate);

            // Assert
            Assert.AreEqual(ShotResult.Hit, shotResult);
        }

        [Test]
        public void TakeShot_ShouldReturnShotResultMiss_WhenShotMisses()
        {
            // Arrange
            var board = new Board();
            var coordinate = new Coordinate(0, 0);

            // Act
            var shotResult = board.TakeShot(coordinate);

            // Assert
            Assert.AreEqual(ShotResult.Miss, shotResult);
        }
    }
}
