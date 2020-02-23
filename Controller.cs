using Console = Colorful.Console;
using System.Drawing;

namespace Battleships
{
    public class Controller
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Controller(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public void Shoot(Coordinates coordinate, Player Player1, Player Player2) 
        {
            var firstPlayerFiringSquare = Player1.FiringBoard.Board[coordinate.Row][coordinate.Column];
            var secondPlayerOwnSquare = Player2.OwnBoard.Board[coordinate.Row][coordinate.Column];
            if (!firstPlayerFiringSquare.IsHit)
            {
                foreach (Ship ship in Player2.Ships) 
                {
                    foreach(var shipCoord in ship.ShipCoordinates)
                    {
                        if (coordinate.Column == shipCoord.Column 
                        && coordinate.Row == shipCoord.Row) 
                        {
                            firstPlayerFiringSquare.Symbol = "X";
                            firstPlayerFiringSquare.IsHit = true;
                            secondPlayerOwnSquare.Symbol = "X";
                            secondPlayerOwnSquare.IsHit = true;
                            ship.Size --;
                            
                            if (ship.IsSunk)
                            {
                                Console.WriteLine("\nHit & Sunk!\n", Color.Gold);
                            }
                            else
                            {
                                Console.WriteLine("\nHit!\n", Color.Red);
                            }
                            return;
                        }
                    }
                }
                firstPlayerFiringSquare.Symbol = "O";
                firstPlayerFiringSquare.IsHit = true;
                secondPlayerOwnSquare.Symbol = "O";
                secondPlayerOwnSquare.IsHit = true;
                Console.WriteLine("\nMiss!\n", Color.Aqua);
            }
            else
            {
                Console.WriteLine("\n You've already shot here! Try again.", Color.Gold);
                Shoot(Player1.GetShootingCoordinates(), Player1, Player2);
            }
        }
        public void PlayTurn(Player Player1 , Player Player2)
        {
            if (Player2.GetType() == typeof(HumanPlayer))
            {
                Display.PrintBoards(Player2);
            }
            Shoot(Player1.GetShootingCoordinates(), Player1 , Player2);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
