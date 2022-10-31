using System;

namespace OOP_Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var firstPlayer = new GameAccount("Саша", 100);
            var secondPlayer = new GameAccount("Денис", 50);
            var thirdPlayer = new GameAccount("Даня", 75);
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int temp = random.Next(0, 3);
                if (temp == 0)
                {
                    Game.Playing(firstPlayer, secondPlayer, random.Next(50, 101));
                }
                else if(temp == 1)
                {
                    Game.Playing(firstPlayer, thirdPlayer, random.Next(50, 101));
                }
                else
                {
                    Game.Playing(thirdPlayer, secondPlayer, random.Next(50, 101));
                }
            }

            Console.Write(firstPlayer.GetStats());
            Console.WriteLine();
            Console.Write(secondPlayer.GetStats());
            Console.WriteLine();
            Console.Write(thirdPlayer.GetStats());
            
        }
        
        
        
        
        
        
        
        
    }
}