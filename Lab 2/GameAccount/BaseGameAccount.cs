using System;
using System.Collections.Generic;
using Lab_2.Game;

namespace Lab_2.GameAccount
{
    public abstract class BaseGameAccount
    {
        public string UserName { get; }
        protected readonly int InitialRating;
        protected String TypeOfGameAccount{ get; set; }
        public abstract int CurrentRating { get; }
        protected BaseGameAccount(string userName, int initialRating)
        {
            CheckInitialRating(initialRating);
            UserName = userName;
            InitialRating = initialRating;
        }


        private void CheckInitialRating(int initialRating)
        {
            if (initialRating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialRating), "The initial rating must be positive");
            }
        }

        protected int GamesCount => AllGames.Count;
        protected  readonly List<BaseGame> AllGames = new List<BaseGame>();
        public void WinGame(BaseGame game)
        {
            AllGames.Add(game);
        }
        

        public void LoseGame(BaseGame game)
        {
            AllGames.Add(game);
        }

        public abstract string GetStats();
    }
}