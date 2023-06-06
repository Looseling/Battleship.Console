using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Grid
    {
        public const char Empty = '.';
        public const char Ship = 'S';
        public const char Hit = 'H';
        public const char Miss = 'M';

        public readonly int Size;
        private char[,] grid;

        public Grid(int size)
        {
            Size = size;
            grid = new char[size, size];
        }

        public void InitializeGrid()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    grid[i, j] = Empty;
                }
            }
        }

        public char GetCellStatus(Coordinate coordinate)
        {
            return grid[coordinate.X, coordinate.Y];
        }

        public void SetCellStatus(Coordinate coordinate, char status)
        {
            grid[coordinate.X, coordinate.Y] = status;
        }
    }
}
