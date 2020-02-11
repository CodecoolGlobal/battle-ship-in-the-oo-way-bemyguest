namespace battle_ship_in_the_oo_way_bemyguest
{
    class Square
    {
        public Coordinates Coordinates {get; set;}
        public Square(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
        }
    }
}
