using System;
using Lab_2.GameAccount;

namespace Lab_2.Game
{
    public class PracticeGame : BaseGame
    {
        public PracticeGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer) : base(
            firstPlayer, secondPlayer, 0)
        {
            TypeOfGame = Type.Practice;
        }

        protected override void CheckRating(int ratingValue)
        {
            if (ratingValue != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ratingValue), "Rating for practice game must be 0!");
            }
        }
        
    }
}