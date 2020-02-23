using System;
namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var Player1 = new Player(Display.GetPlayersName());
            var Player2 = new Player(Display.GetPlayersName());
            AbstractController PlayerController = new PlayerController(Player1, Player2);
            AbstractController AIController = new AIController(Player1, Player2);

            Display.WelcomeScreen();
            Player1.PlaceAllShips();
            Console.Clear();
            Player2.PlaceAllShips();
            
            var gameIsOn = true;

            while(gameIsOn)
            {
                PlayerController.PlayTurn(Player1);
                if(Player2.HasLost)
                {
                    Console.WriteLine("Player1 Won!");
                    break;
                }
                AIController.PlayTurn(Player2);
                if(Player1.HasLost)
                {
                    Console.WriteLine("Player2 Won!");
                    gameIsOn=false;
                }
            }
        }
    }
}
