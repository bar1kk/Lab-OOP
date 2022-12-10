using Lab_2.Game;

namespace Lab_2.GameAccount
{
    public class AddPointsGameAccount : BaseGameAccount
    {
        public AddPointsGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
            TypeOfGameAccount = "With additional points for winning streaks";
        }

        private int TotalBonusPoints
        {
            get
            {
                int bonusPoints = 10;
                int totalBonusPoints = 0;
                bool streak = false;
                foreach (var item in AllGames)
                {
                    if (item is PracticeGame)
                    {
                        continue;
                    }

                    if (Equals(this, item.Loser))
                    {
                        streak = false;
                    }
                    else
                    {
                        if (streak)
                        {
                            totalBonusPoints += bonusPoints;
                        }

                        streak = true;
                    }
                }
                return totalBonusPoints;
            }
        }

        public override int CurrentRating
        {
            get
            {
                int currentRating = InitialRating;
                int bonusPoints = 10;
                bool streak = false;

                foreach (var item in AllGames)
                {
                    if (item is PracticeGame)
                    {
                        continue;
                    }

                    if (Equals(this, item.Loser))
                    {
                        if (currentRating - item.RatingValue < 1)
                        {
                            currentRating = 1;
                        }
                        else
                        {
                            currentRating -= item.RatingValue;
                        }

                        streak = false;
                    }
                    else
                    {
                        if (streak)
                        {
                            currentRating += (item.RatingValue + bonusPoints);
                        }
                        else
                        {
                            currentRating += item.RatingValue;
                        }

                        streak = true;
                    }
                }
                return currentRating;
            }
        }

        public override string GetStats()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine(
                $"Type of game account: {TypeOfGameAccount}\n{UserName}'s initial rating: {InitialRating}\nGame ID\tType of Game\tName opponents\tResult\tRating value");
            foreach (var item in AllGames)
            {
                if (Equals(this, item.Loser))
                {
                    report.Append($"{item.Index}\t{item.TypeOfGame}\t{item.Winner.UserName}\t\tLose\t");
                    if (item is PracticeGame)
                    {
                        report.AppendLine($"{item.RatingValue}");
                    }
                    else
                    {
                        report.AppendLine($"-{item.RatingValue}");
                    }
                }
                else
                {
                    report.Append($"{item.Index}\t{item.TypeOfGame}\t{item.Loser.UserName}\t\tWin\t");
                    if (item is PracticeGame)
                    {
                        report.AppendLine($"{item.RatingValue}");
                    }
                    else
                    {
                        report.AppendLine($"+{item.RatingValue}");
                    }
                }
            }

            report.AppendLine(
                $"Total bonus points: {TotalBonusPoints}\nNumber of games: {GamesCount}\n{UserName}'s rating after gaming: {CurrentRating}");

            return report.ToString();
        }
    }
}