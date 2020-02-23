using System;
namespace Battleships
{
    public class AIPlayer : Player
    {
        public AIPlayer(string name) : base(name){}

        public override void PlaceShip(int size, string tag)
        {
            var loop = true;
            while(loop)
            {
                var direction = GetDirection();
                var coords = GetShipCoordinates();
                var ship = new Ship(coords, direction, size, tag);
                if (ship.IsHorizontal && (ship.Size + coords.Row) > 10)
                {
                    continue;
                }
                else if ((!ship.IsHorizontal) && (ship.Size + coords.Column) > 10)
                {
                    continue;
                }
                else if (IsCoordinateTaken(ship))
                {
                    continue;   
                }
                else
                {
                    Ships.Add(ship);
                    foreach(var coordinate in ship.ShipCoordinates)
                    {
                        OwnBoard.Board[coordinate.Row][coordinate.Column].Symbol = tag;
                    }
                    loop = false;
                }
            }
        }
        public override bool GetDirection()
        {
            string[] directions = {"V", "H"};
            Random rand = new Random();
            int index = rand.Next(directions.Length);
            var direction = directions[index];

            if (direction== "V")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Coordinates GetRandomCoordinates()
        {
            Random rand = new Random();
            var x = rand.Next(10);
            var y = rand.Next(10);

            return new Coordinates(y,x);   
        }
        public override Coordinates GetShipCoordinates()
        {
            return GetRandomCoordinates();
        }

        public override Coordinates GetShootingCoordinates()
        {
            return GetRandomCoordinates();
        }
    }
}
