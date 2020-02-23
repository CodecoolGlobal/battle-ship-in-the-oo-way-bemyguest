using Console = Colorful.Console;
using System.Drawing;
using System;

namespace Battleships
{
    public class PlayerController : AbstractController
    {
        public PlayerController(Player player1, Player player2) : base(player1, player2){}
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
