using Lab_2.Game;

namespace Lab_2.GameAccount
{
    public class HalfRatingGameAccount:BaseGameAccount
    {
        public HalfRatingGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
            TypeOfGameAccount = Type.OnlyHalfRatingIsDeducted;
        }

        
        public override int CurrentRating
        {
            get
            {
                int currentRating = InitialRating;
                foreach (var item in AllGames)
                {
                    if (Equals(this, item.Loser))
                    {
                        if (currentRating - item.RatingValue/2 < 1)
                        {
                            currentRating = 1;
                        }
                        else
                        {
                            currentRating -= item.RatingValue / 2;
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

        public override string GetStats()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine($"Type of game account: {TypeOfGameAccount}\n{UserName}'s initial rating: {InitialRating}\nGame ID\tType of Game\tName opponents\tResult\tRating value");
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
                        report.AppendLine($"-{item.RatingValue/2}");
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
            report.AppendLine($"Number of games: {GamesCount}\n{UserName}'s rating after gaming: {CurrentRating}");
            
            return report.ToString();
        }
    }
}