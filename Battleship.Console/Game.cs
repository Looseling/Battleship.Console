using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Battleship.Constants;
using Battleship.Erros;
using Battleship.Models;

namespace Battleship
{
    public class Game
    {
        private Board board;
        private InputValidator validator;

        public Game()
        {
            board = new Board();
            validator = new InputValidator();
        }

        public void Start()
        {
            board.PrintBoard();
            while (!board.AllShipsSunk())
            {
                ShotResult result;
                do
                {
                    Console.Write("Enter coordinates (e.g., A5): ");
                    string input = Console.ReadLine();
                    try
                    {
                        Coordinate coordinate = validator.GetCoordinate(input);
                        result = board.TakeShot(coordinate);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid input format. Expected format is 'A5'. Please try again.");
                        result = ShotResult.Invalid;
                    }
                }
                while (result == ShotResult.Invalid);
                Console.Clear();
                board.PrintBoard();
                Console.WriteLine(result.ToString());
            }
            Console.WriteLine("All ships sunk! You win!");
        }
    }
}
