using Console = Colorful.Console;
using System.Drawing;
using System;
namespace Battleships
{
    public class Display
    {
        public Player Player { get; set; }
        public void PrintBoards(Player Player)
        {
            int number = 0;
            Console.WriteLine($"{Player.Name}'s turn\n", Color.Indigo);
            Console.WriteLine("       Own Board                            Firing Board", Color.Yellow);
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9                   0 1 2 3 4 5 6 7 8 9", Color.Green);
            for(int row = 0; row < 10; row++)
            {
                Console.Write(number + " ", Color.Green);
                for(int ownColumn = 0; ownColumn < 10; ownColumn++)
                {
                    Console.Write(Player.OwnBoard.Board[row][ownColumn].Symbol + " ");
                }
                Console.Write("                " + number + " ", Color.Green);
                for (int firingColumn = 0; firingColumn < 10; firingColumn++)
                {
                    Console.Write(Player.FiringBoard.Board[row][firingColumn].Symbol + " ");
                }
                Console.WriteLine();
                number++;
            }
            Console.WriteLine();
        }
        public void WelcomeScreen()
        {
            Console.WriteLine("Welcome screen!");
        }
        public string GetPlayersName()
        {
            Console.WriteLine("Enter players name: ");
            return Console.ReadLine();
        }
        public Coordinates GetShootingCoordinates()
        {
                Console.WriteLine("Enter x coordinate: ");
                var x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y coordinate: ");
                var y = Convert.ToInt32(Console.ReadLine());
                return new Coordinates(y,x);
        }
    }
}
