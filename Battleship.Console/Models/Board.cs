using Battleship.Constants;
using Battleship.Managers;

namespace Battleship.Models
{
    public class Board
    {
        private const int BoardSize = 10;
        private const int BattleshipSize = 5;
        private const int NumberOfBattleships = 1;

        private const int DestroyerSize = 4;
        private const int NumberOfDestroyers = 2;

        private Grid grid;
        private List<Ship> ships;
        private ShipPlacementManager placementManager;
        private ShotManager shotManager;
        private PrintManager printManager;

        public List<Ship> Ships => ships;

        public Board()
        {
            grid = new Grid(BoardSize);
            ships = new List<Ship>(NumberOfBattleships + NumberOfDestroyers);
            placementManager = new ShipPlacementManager(grid, ships);
            shotManager = new ShotManager(grid, ships);
            printManager = new PrintManager(grid);
            Initialize();
        }

        private void Initialize()
        {
            grid.InitializeGrid();
            placementManager.PlaceShips(BattleshipSize, DestroyerSize, NumberOfDestroyers);
        }

        public bool AllShipsSunk()
        {
            return ships.All(ship => ship.IsSunk());
        }

        public ShotResult TakeShot(Coordinate coordinate)
        {
            return shotManager.TakeShot(coordinate);
        }

        public void PrintBoard()
        {
            printManager.PrintBoard();
        }
    }
}

