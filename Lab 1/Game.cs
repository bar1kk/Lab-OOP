using System;

namespace OOP_Lab1
{
    public class Game
    {
        private static Random _random = new Random();
        private static int _id = 1010;

        public int Index { get; }
        public GameAccount Winner { get; }
        public GameAccount Looser { get; }
        public int RatingValue { get; }

        private Game(GameAccount winner, GameAccount looser, int ratingValue)
        {
            CheckRating(ratingValue);
            Winner = winner;
            Looser = looser;
            RatingValue = ratingValue;
            Index = _id++;
        }

        private void CheckRating(int ratingValue)
        {
            if (ratingValue <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ratingValue), "Rating for the game must be positive");
            }
        }

        public static Game Playing(GameAccount firstPlayer, GameAccount secondPlayer, int ratingValue)
        {
            Game game;
            if (_random.Next(0, 2) == 0)
            {
                game = new Game(firstPlayer, secondPlayer, ratingValue);
            }
            else
            {
                game = new Game(secondPlayer, firstPlayer, ratingValue);
            }
            game.Winner.WinGame(game);
            game.Looser.LoseGame(game);
            
            return game;
        }
    }
}