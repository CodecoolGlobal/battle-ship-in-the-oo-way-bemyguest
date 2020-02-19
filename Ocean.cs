using System.Collections.Generic;
namespace Battleships
{
    public class Ocean
    {
        public List<List<Square>> Board {get; set;}
        public Ocean()
        {
            Board = new List<List<Square>>();
            List<Square> row;

            for (int i = 0; i < 10; i++)
            {
                row = new List<Square>();
                for (int j = 0; j < 10; j++)
                {
                    row.Add(new Square(i, j));
                }
                Board.Add(row);
            }
        }
    }
}


