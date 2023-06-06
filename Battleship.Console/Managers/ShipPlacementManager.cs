using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Models;

namespace Battleship.Managers
{
    public class ShipPlacementManager
    {

        private readonly Grid grid;
        private readonly List<Ship> ships;
        private Random random;

        public ShipPlacementManager(Grid grid, List<Ship> ships)
        {
            this.grid = grid;
            this.ships = ships;
            random = new Random();
        }

        public void PlaceShips(int battleshipSize, int destroyerSize, int numberOfDestroyers)
        {
            PlaceShipRandomly(new Ship(battleshipSize));
            for (int i = 0; i < numberOfDestroyers; i++)
            {
                PlaceShipRandomly(new Ship(destroyerSize));
            }
        }
        private void PlaceShipRandomly(Ship ship)
        {
            bool isPlaced = false;

            while (!isPlaced)
            {
                int startX = random.Next(grid.Size);
                int startY = random.Next(grid.Size);
                bool isHorizontal = random.Next(2) == 0;

                if (CanShipBePlaced(ship, startX, startY, isHorizontal))
                {
                    PlaceShip(ship, startX, startY, isHorizontal);
                    isPlaced = true;
                }
            }
        }

        private bool CanShipBePlaced(Ship ship, int startX, int startY, bool isHorizontal)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                int x = startX + (isHorizontal ? i : 0);
                int y = startY + (isHorizontal ? 0 : i);

                if (IsInvalidCoordinate(x, y) || IsOccupied(x, y))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsInvalidCoordinate(int x, int y)
        {
            return x >= grid.Size || y >= grid.Size || grid.GetCellStatus(new Coordinate(x, y)) == Grid.Ship || grid.GetCellStatus(new Coordinate(x, y)) == Grid.Hit;
        }

        private bool IsOccupied(int x, int y)
        {
            return grid.GetCellStatus(new Coordinate(x, y)) != Grid.Empty;
        }
        private void PlaceShip(Ship ship, int startX, int startY, bool isHorizontal)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                int x = startX + (isHorizontal ? i : 0);
                int y = startY + (isHorizontal ? 0 : i);
                grid.SetCellStatus(new Coordinate(x, y), Grid.Ship);
                ship.SetCoordinate(i, new Coordinate(x, y));
            }
            ships.Add(ship);
        }
    }
}