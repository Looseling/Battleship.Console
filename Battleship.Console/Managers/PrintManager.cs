using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Models;

namespace Battleship.Managers
{
    public class PrintManager
    {
        private readonly Grid grid;

        public PrintManager(Grid grid)
        {
            this.grid = grid;
        }

        public void PrintBoard()
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < grid.Size; i++)
            {
                Console.Write(i + 1 < 10 ? " " : "");
                Console.Write(i + 1);
                for (int j = 0; j < grid.Size; j++)
                {
                    char cellStatus = grid.GetCellStatus(new Coordinate(j, i));
                    Console.Write(" " + (cellStatus == Grid.Empty ? '.' : cellStatus));
                }
                Console.WriteLine();
            }
        }
    }
}
