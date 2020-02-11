using System;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_bemyguest
{
    class Ocean
    {
        public List<Square> Squares {get; set;}
        public Ocean()
        {
            Squares = new List<Square>();
            for(int i = 1; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    Squares.Add(new Square(i,j));
                }
            }
        }
    }
}
