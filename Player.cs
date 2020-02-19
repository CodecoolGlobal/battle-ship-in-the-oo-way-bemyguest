using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class Player
    {
        public string Name { get; set; }
        public Ocean OwnBoard { get; set; }
        public Ocean FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public Player(string name)
        {
            Random rand = new Random();

            var Battleship = new Ship(new Coordinates(3, 1), true, 4, "B");
            var Cruiser = new Ship(new Coordinates(rand.Next(1, 8), rand.Next(3,5)), true, 3, "R");
            var Submarine = new Ship(new Coordinates(rand.Next(1, 6), rand.Next(5,7)), true, 5, "S");
            var Carrier = new Ship(new Coordinates(rand.Next(6,10), 7), false, 3, "C");
            var Destroyer = new Ship(new Coordinates(2, 8), false, 2, "D");

            Name = name;
            Ships = new List<Ship>() {Battleship, Carrier, Cruiser, Destroyer, Submarine};
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
        public void PlaceShips()
        {
            foreach(var ship in Ships)
            {
                if(!IsCoordinateTaken(ship))
                {
                    foreach(var coordinate in ship.ShipCoordinates) 
                    {
                        OwnBoard.Board[coordinate.Row][coordinate.Column].Symbol = ship.Tag;
                    }
                }
            }
        }
        public void Shoot(Coordinates coordinate, Player Player1, Player Player2) 
        {
            // if (coordinate.Row < 1 || coordinate.Row > 10)
            //     throw new ArgumentException("x coordinate should be in range 0..9");
            // if (coordinate.Column < 1 || coordinate.Column > 10)
            //     throw new ArgumentException("y coordinate should be in range 0..9");

            foreach (Ship ship in Player2.Ships) 
            {
                foreach(var shipCoord in ship.ShipCoordinates)
                {   
                    if (coordinate.Column == shipCoord.Column 
                        && coordinate.Row == shipCoord.Row) 
                    {
                        Player1.FiringBoard.Board[coordinate.Row][coordinate.Column].Symbol = "X";
                        Player2.OwnBoard.Board[coordinate.Row][coordinate.Column].Symbol = "X";
                        Console.WriteLine("\nHit!\n");
                        ship.Size --;
                        if (ship.IsSunk)
                        {
                            Console.WriteLine("\nHit & Sunk!\n");
                        }
                        return;
                    }
                }
            }
            Player1.FiringBoard.Board[coordinate.Row][coordinate.Column].Symbol = "O";
            Player2.OwnBoard.Board[coordinate.Row][coordinate.Column].Symbol = "O";
            Console.WriteLine("\nMiss!\n");
        }
        public void PrintBoards()
        {
            int number = 0;
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                            Firing Board:");
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9                   0 1 2 3 4 5 6 7 8 9");
            for(int row = 0; row < 10; row++)
            {
                Console.Write(number + " ");
                for(int ownColumn = 0; ownColumn < 10; ownColumn++)
                {
                    Console.Write(OwnBoard.Board[row][ownColumn].Symbol + " ");
                }
                Console.Write("                " + number + " ");
                for (int firingColumn = 0; firingColumn < 10; firingColumn++)
                {
                    Console.Write(FiringBoard.Board[row][firingColumn].Symbol + " ");
                }
                Console.WriteLine();
                number++;
            }
            Console.WriteLine();
        }
        public bool CheckIfAllSunk(Player Player)
        {
            if(Ships.All(ship => ship.IsSunk))
            {
                return true;
            }
            return false;
        }
    }
}
