using Lab_2.GameAccount;

namespace Lab_2.Game
{
    public class  MoreChanceGame : BaseGame
    {
        public MoreChanceGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int ratingValue) : base(firstPlayer, secondPlayer, ratingValue)
        {
            TypeOfGame = Type.MoreChance;
        }

        protected override void Pick(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer)
        {
            bool ratingFirstMoreSecond = firstPlayer.CurrentRating > secondPlayer.CurrentRating;
            int temp = Rand.Next(0, 3);
            if (ratingFirstMoreSecond)
            {
                if (temp != 0)
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
            else
            {
                if (temp != 0)
                {
                    Winner = secondPlayer;
                    Loser = firstPlayer;
                }
                else
                {
                    Winner = firstPlayer;
                    Loser = secondPlayer;
                }
            }
        }
    }
}