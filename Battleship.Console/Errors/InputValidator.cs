using Battleship.Constants;
using Battleship.Models;

namespace Battleship.Erros
{ 
    public class InputValidator
    {
        public Coordinate GetCoordinate(string input)
        {
          

            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                throw new ArgumentException("Invalid input. Expected format is 'A5'.");
            }

            int x = input[0] - 'A';
            if (!int.TryParse(input.Substring(1), out int y))
            {
                throw new ArgumentException("Invalid input. Expected format is 'A5'.");
            }

            return new Coordinate(x, y - 1);
        }
    }

}