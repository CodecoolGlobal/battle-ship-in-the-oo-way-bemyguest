namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var Player1 = new Player("Kuba");
            var Player2 = new Player("Michał");
            Player1.PlaceShips();
            Player1.Shoot(new Coordinates(4,1));
            Player1.PrintBoards();
            Player2.PlaceShips();
            Player2.PrintBoards();
        }
    }
}
