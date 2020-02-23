using System;
namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.WelcomeScreen();
            var choice = Convert.ToInt32(Console.ReadLine());
            var Player1 = new HumanPlayer(Display.GetPlayersName());
            Player Player2 = new AIPlayer("Kompik");

            if (choice == 1)
            {
                Player2 = new HumanPlayer(Display.GetPlayersName());
            }

            Controller controller = new Controller(Player1, Player2);

            Player1.PlaceAllShips(Player1);
            Console.Clear();
            Player2.PlaceAllShips(Player2);
            
            var gameIsOn = true;
            while(gameIsOn)
            {
                controller.PlayTurn(Player1, Player2);
                if(Player2.HasLost)
                {
                    Console.WriteLine("Player1 Won!");
                    break;
                }
                controller.PlayTurn(Player2, Player1);
                if(Player1.HasLost)
                {
                    Console.WriteLine("Player2 Won!");
                    gameIsOn=false;
                }
            }
        }
    }
}
