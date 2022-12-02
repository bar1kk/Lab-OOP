using Lab_2.Game;
using Lab_2.GameAccount;

namespace Lab_2
{
    public class GameFactory
    {
        public BaseGame GetNormalGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int ratingValue)
        {
            return new NormalGame(firstPlayer, secondPlayer, ratingValue);
        }
        
        public BaseGame GetPracticeGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer)
        {
            return new PracticeGame(firstPlayer, secondPlayer);
        }

        public BaseGame  GetMoreChanceGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int ratingValue)
        {
            return new  MoreChanceGame(firstPlayer, secondPlayer, ratingValue);
        }
    }
}