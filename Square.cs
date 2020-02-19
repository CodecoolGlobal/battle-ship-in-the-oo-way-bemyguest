namespace Battleships
{
    public class Square
    {
        public Coordinates Coordinates { get; set; }
        public bool IsHit { get; set; }
        public string Symbol { get; set; }
        public bool IsOccupied
        { 
            get
            {
                if(Symbol == "*")
                {
                    return false;
                }
                return true;
            }
            set 
            {
                if(value.GetType() == typeof(bool))
                {
                    IsOccupied = value;
                }
            }
        }
        public Square(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            IsHit = false;
            Symbol = "*";
        }
    }
}
