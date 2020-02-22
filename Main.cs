﻿using System;
namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.WelcomeScreen();
            var Player1 = new Player(Display.GetPlayersName());
            Display.PlaceAllShips(Player1);
            Console.Clear();
            var Player2 = new Player(Display.GetPlayersName());
            Display.PlaceAllShips(Player2);
            
            var gameIsOn = true;

            while(gameIsOn)
            {
                Player1.PlayTurn(Player1, Player2);
                if(Player2.HasLost)
                {
                    Console.WriteLine("Player1 Won!");
                    break;
                }
                Player2.PlayTurn(Player2,Player1);
                if(Player1.HasLost)
                {
                    Console.WriteLine("Player2 Won!");
                    gameIsOn=false;
                }
            }
        }
    }
}
