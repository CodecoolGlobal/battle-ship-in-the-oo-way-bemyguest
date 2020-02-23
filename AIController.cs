using System;
namespace Battleships
{
    public class AIController : AbstractController
    {
        public AIController(Player player1, Player player2) : base(player1, player2){}

        public override bool GetDirection()
        {
            string[] directions = {"V", "H"};
            Random rand = new Random();
            int index = rand.Next(directions.Length);
            var direction = directions[index];

            if (direction== "V")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Coordinates GetRandomCoordinates()
        {
            Random rand = new Random();
            var x = rand.Next(10);
            var y = rand.Next(10);

            return new Coordinates(y,x);   
        }
        public override Coordinates GetShipCoordinates()
        {
            return GetRandomCoordinates();
        }

        public override Coordinates GetShootingCoordinates()
        {
            return GetRandomCoordinates();
        }
    }
}
