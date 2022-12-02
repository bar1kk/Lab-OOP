using Lab_2.GameAccount;

namespace Lab_2.Game
{
    public class NormalGame : BaseGame
    {
        public NormalGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int ratingValue) : base(
            firstPlayer, secondPlayer, ratingValue)
        {
            TypeOfGame = "Normal   ";
        }
    }
}