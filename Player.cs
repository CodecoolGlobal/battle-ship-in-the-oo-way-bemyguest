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
            var firstPlayerFiringSquare = Player1.FiringBoard.Board[coordinate.Row][coordinate.Column];
            var secondPlayerOwnSquare = Player2.OwnBoard.Board[coordinate.Row][coordinate.Column]; // Czy jest sens?
            // Czy wrzucać tu jakiś warunek, że if is hit, to jeszcze raz? Da się to rozbić na mniejsze?
            foreach (Ship ship in Player2.Ships) 
            {
                foreach(var shipCoord in ship.ShipCoordinates)
                {   
                    if (coordinate.Column == shipCoord.Column 
                     && coordinate.Row == shipCoord.Row) 
                    {
                        firstPlayerFiringSquare.Symbol = "X";
                        firstPlayerFiringSquare.IsHit = true; //DUŻO RZECZY
                        secondPlayerOwnSquare.Symbol = "X";
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
            Console.WriteLine("\nMiss!\n", Color.Aqua);
        }
        public void PlayTurn(Player Player1, Player Player2) //Czy jest sens i czy tutaj?
        {
            var Display = new Display();
            Display.PrintBoards(Player1);
            Player1.Shoot(Display.GetShootingCoordinates(), Player1, Player2);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
