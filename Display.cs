using Console = Colorful.Console;
using System.Drawing;
using System;
using System.Collections.Generic;
namespace Battleships
{
    public class Display
    {
        public Player Player { get; set; }
        public Ship Ship { get; set; }
        public static void PrintBoards(Player Player)
        {
            int number = 0;
            Console.WriteLine($"{Player.Name}'s turn\n", Color.Indigo);
            Console.WriteLine("       Own Board                            Firing Board", Color.Yellow);
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9                   0 1 2 3 4 5 6 7 8 9", Color.Green);
            for(int row = 0; row < 10; row++)
            {
                Console.Write(number + " ", Color.Green);
                for(int ownColumn = 0; ownColumn < 10; ownColumn++)
                {
                    Console.Write(Player.OwnBoard.Board[row][ownColumn].Symbol + " ");
                }
                Console.Write("                " + number + " ", Color.Green);
                for (int firingColumn = 0; firingColumn < 10; firingColumn++)
                {
                    Console.Write(Player.FiringBoard.Board[row][firingColumn].Symbol + " ");
                }
                Console.WriteLine();
                number++;
            }
            Console.WriteLine();
        }
        public static void WelcomeScreen()
        {
            Console.WriteLine("Welcome screen!");
        }
        public static string GetPlayersName()
        {
            Console.WriteLine("Enter players name: ");
            return Console.ReadLine();
        }
        public static Coordinates GetShootingCoordinates()
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
        public static Coordinates GetShipCoordinates()
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
        public static bool GetDirection()
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
        public static void PlaceAllShips(Player Player)
        {
            foreach(KeyValuePair<string, int> property in Ship.ShipProperties)
            {
                Player.PlaceShip(property.Value, property.Key);
                PrintBoards(Player);
            }
        }
    }
}
