using System.Collections.Generic;
using System.Linq;
using System;

namespace Battleships
{
    public class Player
    {
        public string Name { get; set; }
        public Ocean OwnBoard { get; set; }
        public Ocean FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public AbstractController Controller { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(ship => ship.IsSunk);
            }
        }
        public Player(string name)
        {
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
                var direction = Controller.GetDirection();
                var coords = Controller.GetShipCoordinates();
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
        public void PlaceAllShips()
        {
            foreach(KeyValuePair<string, int> property in Ship.ShipProperties)
            {
                PlaceShip(property.Value, property.Key);
            }
        }
    }
}
