using System.Collections.Generic;
using System.Linq;
using System;

namespace Battleships
{
    public abstract class Player
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
            Name = name;
            Ships = new List<Ship>();
            OwnBoard = new Ocean();
            FiringBoard = new Ocean();

        }
        public abstract void PlaceShip(int size, string tag);
        public abstract Coordinates GetShootingCoordinates();
        public abstract Coordinates GetShipCoordinates();
        public abstract bool GetDirection();
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
        public void PlaceAllShips(Player Player)
        {
            foreach(KeyValuePair<string, int> property in Ship.ShipProperties)
            {
                PlaceShip(property.Value, property.Key);
                if (Player.GetType() == typeof(HumanPlayer))
                {
                    Display.PrintBoards(Player);
                }
            }
        }
    }
}
