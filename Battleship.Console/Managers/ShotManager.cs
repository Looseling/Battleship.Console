using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Battleship.Constants;
using Battleship.Models;

namespace Battleship.Managers
{
    public class ShotManager
    {
        private readonly Grid grid;
        private readonly List<Ship> ships;

        public ShotManager(Grid grid, List<Ship> ships)
        {
            this.grid = grid;
            this.ships = ships;
        }

        public ShotResult TakeShot(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.X >= grid.Size || coordinate.Y < 0 || coordinate.Y >= grid.Size)
            {
                return ShotResult.Invalid; 
            }

            char cellStatus = grid.GetCellStatus(coordinate);

            if (cellStatus == Grid.Ship)
            {
                grid.SetCellStatus(coordinate, Grid.Hit);

                foreach (Ship ship in ships)
                {
                    if (ship.IsAt(coordinate) && ship.IsSunk())
                    {
                        return ShotResult.Sink;
                    }
                }

                return ShotResult.Hit;
            }
            else if (cellStatus == Grid.Empty)
            {
                grid.SetCellStatus(coordinate, Grid.Miss);
                return ShotResult.Miss;
            }
            else
            {
                return ShotResult.Invalid;
            }
        }
    }
}
