using System;

namespace Lab_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameFactory gameFactory = new GameFactory();
            GameAccountFactory gameAccountFactory = new GameAccountFactory();
            Random random = new Random();
            
            var player1 = gameAccountFactory.GetNormalGameAccount("Саша", 90);
            var player2 = gameAccountFactory.GetAddPointsGameAccount("Денис", 100);
            var player3 = gameAccountFactory.GetHalfPointsGameAccount("Максим", 50);

            for (int i = 0; i < 12; i++)
            {
                int temp = random.Next(0, 3);
                if (temp == 0)
                {
                    gameFactory.GetPracticeGame(player1, player2);
                   
                }
                else if (temp == 1)
                {
                    gameFactory.GetNormalGame(player1, player3, random.Next(1, 31));
                    
                }
                else
                {
                    gameFactory.GetMoreChanceGame(player2, player3, random.Next(1,31));
                }
            }
            
            Console.WriteLine(player1.GetStats());
            Console.WriteLine(player2.GetStats());
            Console.WriteLine(player3.GetStats());
        }
    }
}