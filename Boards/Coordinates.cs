using System;

namespace battle_ship_in_the_oo_way_bemyguest
{
    class Coordinates
    {
        public int Row {get; set;}
        public int Column {get; set;}
        public Coordinates(int row, int column)
        {
            Row=row;
            Column=column;
        }
    }

}
