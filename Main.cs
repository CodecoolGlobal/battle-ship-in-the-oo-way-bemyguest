using System;
namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var Player1 = new Player("Kuba");
            var Player2 = new Player("Michał");
            Player1.PlaceShips();
            Player2.PlaceShips();
            while(true)
            {
                Player1.PrintBoards();
                Console.WriteLine("Enter x coordinate: ");
                var x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y coordinate: ");
                var y = Convert.ToInt32(Console.ReadLine());
                Player1.Shoot(new Coordinates(y,x), Player1, Player2);
                Console.ReadLine();

                Player2.PrintBoards();
                Console.WriteLine("Enter x coordinate: ");
                var i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y coordinate: ");
                var j = Convert.ToInt32(Console.ReadLine());
                Player2.Shoot(new Coordinates(j,i), Player2, Player1);
                Console.ReadLine();
            }
        }
    }
}
