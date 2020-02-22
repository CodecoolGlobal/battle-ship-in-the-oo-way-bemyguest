using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Console = Colorful.Console;

namespace Battleships
{
    public class Player
    {
        public string Name { get; set; }
        public Ocean OwnBoard { get; set; }
        public Ocean FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(ship => ship.IsSunk);
            }
        }
        public Player(string name)
        {
            Random rand = new Random();
            Name = name;
            Ships = new List<Ship>();
            OwnBoard = new Ocean();
            FiringBoard = new Ocean();
        }
        public bool IsCoordinateTaken(Ship ship)
        {
            foreach(var coordinate in ship.ShipCoordinates)
            {
                if(OwnBoard.Board[coordinate.Row][coordinate.Column].IsOccupied)
                {
                    return true;
                }
            }
            return false;
        }
        public void PlaceShip(int size, string tag)
        {
            var loop = true;
            while(loop)
            {
                Console.WriteLine($"You're now placing ship {tag}, which is {size} long");
                var direction = Display.GetDirection();
                var coords = Display.GetShipCoordinates();
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
        public void Shoot(Coordinates coordinate, Player Player1, Player Player2) 
        {
            var firstPlayerFiringSquare = Player1.FiringBoard.Board[coordinate.Row][coordinate.Column];
            var secondPlayerOwnSquare = Player2.OwnBoard.Board[coordinate.Row][coordinate.Column];
            if (!firstPlayerFiringSquare.IsHit)
            {
                foreach (Ship ship in Player2.Ships) 
                {
                    foreach(var shipCoord in ship.ShipCoordinates)
                    {
                        if (coordinate.Column == shipCoord.Column 
                        && coordinate.Row == shipCoord.Row) 
                        {
                            firstPlayerFiringSquare.Symbol = "X";
                            firstPlayerFiringSquare.IsHit = true;
                            secondPlayerOwnSquare.Symbol = "X";
                            secondPlayerOwnSquare.IsHit = true;
                            ship.Size --;
                            
                            if (ship.IsSunk)
                            {
                                Console.WriteLine("\nHit & Sunk!\n", Color.Gold);
                            }
                            else
                            {
                                Console.WriteLine("\nHit!\n", Color.Red);
                            }
                            return;
                        }
                    }
                }
                firstPlayerFiringSquare.Symbol = "O";
                firstPlayerFiringSquare.IsHit = true;
                secondPlayerOwnSquare.Symbol = "O";
                secondPlayerOwnSquare.IsHit = true;
                Console.WriteLine("\nMiss!\n", Color.Aqua);
            }
            else
            {
                Console.WriteLine("\n You've already shot here! Try again.", Color.Gold);
                Shoot(Display.GetShootingCoordinates(), Player1, Player2);
            }
        }
        public void PlayTurn(Player Player1, Player Player2)
        {
            Display.PrintBoards(Player1);
            Player1.Shoot(Display.GetShootingCoordinates(), Player1, Player2);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
