namespace Battleship.Models
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        public char Status { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Status = Grid.Empty;
        }
    }
}