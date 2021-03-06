using System.Collections.Generic;
using System;
namespace Battleships
{
    public class Ship
    {
        public Coordinates InitialCoordinates { get; set; }
        public List<Coordinates> ShipCoordinates { get; set; }
        public int Size { get; set; }
        public bool IsHorizontal { get; set; }
        public string Tag { get; set; }
        public static Dictionary<string, int> ShipProperties = new Dictionary<string, int>() 
        {
            {"D", 2}, {"R", 3}, {"S", 3}, {"B", 4}, {"C", 5}
        };
        public bool IsSunk
        {
            get{return Size<1;}
            set{value = IsSunk;}
        }
        public Ship(Coordinates initialCoordinates, bool isHorizontal, int size, string tag)
        {   
            Tag=tag;
            Size = size;
            IsHorizontal=isHorizontal;
            InitialCoordinates=initialCoordinates;
            ShipCoordinates = GenerateShipCoordinates();
            IsSunk = false;
        }
        public List<Coordinates> GenerateShipCoordinates()
        {
            var resultCoordinates = new List<Coordinates>();
            var x = InitialCoordinates.Row;
            var y = InitialCoordinates.Column;
            var currentShipPart = 0;

            if(IsHorizontal)
            {
                while(currentShipPart<Size)
                {   
                    resultCoordinates.Add(new Coordinates(x, y));
                    currentShipPart++;
                    x++;
                }
            }
            else
            {
                while(currentShipPart<Size)
                {
                    resultCoordinates.Add(new Coordinates(x, y));
                    currentShipPart++;
                    y++;
                }
            }
            return resultCoordinates;
        }
    }
}
