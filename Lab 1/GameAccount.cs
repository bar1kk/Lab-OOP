using System;
using System.Collections.Generic;

namespace OOP_Lab1
{
    public class GameAccount
    {
        private readonly int _initialRating;
        public string UserName { get; }

        public int CurrentRating
        {
            get
            {
                int currentRating = _initialRating;
                foreach (var item in _allGame)
                {
                    if (Equals(this, item.Looser))
                    {
                        if (currentRating - item.RatingValue < 1)
                        {
                            currentRating = 1;
                        }
                        else
                        {
                            currentRating -= item.RatingValue;
                        }
                    }
                    else
                    {
                        currentRating += item.RatingValue;
                    }
                }
                return currentRating;
            }
        }
        
        private int GamesCount => _allGame.Count;
        private readonly List<Game> _allGame = new List<Game>();

        public GameAccount(string userName, int initialRating)
        {
            UserName = userName;
            if (initialRating > 0){
                _initialRating = initialRating;
            }else
            {
                throw new ArgumentOutOfRangeException(nameof(initialRating), "The initial rating must be positive");
            }
        }

        public void WinGame(Game game)
        {
            _allGame.Add(game);
        }

        public void LoseGame(Game game)
        {
            _allGame.Add(game);
        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();

                report.AppendLine($"{UserName}'s initial rating: {_initialRating}\nGame ID\tName opponents\tResult\tRating value");
                foreach (var item in _allGame)
                {
                    if (Equals(this, item.Looser))
                    {
                        report.AppendLine($"{item.Index}\t{item.Winner.UserName}\t\tLose\t-{item.RatingValue}");
                    }
                    else
                    {
                        report.AppendLine($"{item.Index}\t{item.Looser.UserName}\t\tWin\t+{item.RatingValue}");
                    }
                }
                report.AppendLine($"Number of games: {GamesCount}\n{UserName}'s rating after gaming: {CurrentRating}");
                return report.ToString();
        }
    }
}