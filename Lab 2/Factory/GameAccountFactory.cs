using Lab_2.GameAccount;

namespace Lab_2
{
    public class GameAccountFactory
    {
        public BaseGameAccount GetNormalGameAccount(string userName, int initialRating)
        {
            return new NormalGameAccount(userName, initialRating);
        }
        
        public BaseGameAccount GetAddPointsGameAccount(string userName, int initialRating)
        {
            return new AddRatingGameAccount(userName, initialRating);
        }

        public BaseGameAccount GetHalfRatingGameAccount(string userName, int initialRating)
        {
            return new HalfRatingGameAccount(userName, initialRating);
        }
    }
}