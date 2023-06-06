namespace Battleship.Models
{
    public class Ship
    {
        public int Size { get; }
        public List<Coordinate> Coordinates { get; }

        public Ship(int size)
        {
            Size = size;
            Coordinates = new List<Coordinate>(size);
        
        }
        public void SetCoordinate(int index, Coordinate coordinate)
        {
            while (Coordinates.Count <= index)
            {
                Coordinates.Add(null);
            }

            Coordinates[index] = coordinate;
        }

        public bool IsAt(Coordinate coordinate)
        {
            return Coordinates.Contains(coordinate);
        }

        public bool IsSunk()
        {
            return Coordinates.All(coordinate => coordinate.Status == Grid.Hit);
        }
    }
}