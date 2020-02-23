using System;
namespace Battleships
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name){}
        public override void PlaceShip(int size, string tag)
        {
            var loop = true;
            while(loop)
            {
                Console.WriteLine($"You're now placing ship {tag}, which is {size} long");
                var direction = GetDirection();
                var coords = GetShipCoordinates();
                var ship = new Ship(coords, direction, size, tag);
                if (ship.IsHorizontal && (ship.Size + coords.Row) > 10)
                {
                    Console.WriteLine("Cannot place your ship there, try again!\n");
                    continue;
                }
                else if ((!ship.IsHorizontal) && (ship.Size + coords.Column) > 10)
                {
                    Console.WriteLine("Cannot place your ship there, try again!\n");
                    continue;
                }
                else if (IsCoordinateTaken(ship))
                {
                    Console.WriteLine("Cannot place your ship there, try again!\n");
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
        public override Coordinates GetShootingCoordinates()
        {
            try
            {
                Console.WriteLine("Enter x coordinate: ");
                var x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter  y coordinate: ");
                var y = Convert.ToInt32(Console.ReadLine());
                if ((x>=0 && x<10) && (y>=0 && y<10))
                {
                    return new Coordinates(y,x);
                }
                else
                {
                    Console.WriteLine($"Cannot shoot at [{x},{y}], try again.");
                    return GetShipCoordinates();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect input, try again.");
                return GetShootingCoordinates();
            }
        }
        public override Coordinates GetShipCoordinates()
        {
            try
            {
                Console.WriteLine("Enter initial x coordinate: ");
                var x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter initial y coordinate: ");
                var y = Convert.ToInt32(Console.ReadLine());
                if ((x>=0 && x<10) && (y>=0 && y<10))
                {
                    return new Coordinates(y,x);
                }
                else
                {
                    Console.WriteLine($"Cannot place ship at [{x},{y}], try again.");
                    return GetShipCoordinates();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect input, try again.");
                return GetShipCoordinates();
            }
        }
        public override bool GetDirection()
        {
            Console.WriteLine("Enter ship's desired direction (H for horizontal, V for vertical): ");
            var direction = Console.ReadLine();
            if (direction.ToUpper() == "V")
            {
                return true;
            }
            else if (direction.ToUpper() == "H")
            {
                return false;
            }
            else 
            {
                Console.WriteLine("You can only enter H or V !");
                return GetDirection();
            }
        }
    }
}
