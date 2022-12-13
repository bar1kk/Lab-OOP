using System;
using Lab_2.GameAccount;

namespace Lab_2.Game
{
    public abstract class BaseGame
    { 
        protected static readonly Random Rand = new Random();

        public enum Type
        {
            NormalGame,
            MoreChance, 
            Practice
        }
        private static int _id = 1000;
        public int Index { get; }
        public Type TypeOfGame{ get; protected set; }
        public int RatingValue { get; }
        public BaseGameAccount Winner;
        public BaseGameAccount Loser;

        protected BaseGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int ratingValue)
        {
            CheckRating(ratingValue);
            RatingValue = ratingValue;
            Index = _id++;
            Pick(firstPlayer, secondPlayer);
            Playing(this);
        }

        protected virtual void Pick(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer)
        {
            if (Rand.Next(0, 2) == 0)
            {
                Winner = firstPlayer;
                Loser = secondPlayer;
            }
            else
            {
                Winner = secondPlayer;
                Loser = firstPlayer;
            }
        }

        protected virtual void CheckRating(int ratingValue)
        {
            if (ratingValue <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ratingValue), "Rating for the game must be positive!");
            }
        }

        private void Playing(BaseGame game)
        {
            game.Winner.WinGame(game);
            game.Loser.LoseGame(game);
        }
    }
}