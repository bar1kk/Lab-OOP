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

            for (int i = 0; i < 6; i++)
            {
                int temp = random.Next(0, 3);
                if (temp == 0)
                {
                    gameFactory.GetPracticeGame(player1, player2);
                   
                }
                else
                {
                    gameFactory.GetNormalGame(player1, player2, random.Next(1, 31));
                    
                }
            }
            
            Console.Write(player1.GetStats());
            Console.WriteLine();
            Console.Write(player2.GetStats());
            Console.WriteLine();
        }
    }
}