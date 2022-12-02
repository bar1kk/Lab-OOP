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
            return new AddPointsGameAccount(userName, initialRating);
        }

        public BaseGameAccount GetHalfPointsGameAccount(string userName, int initialRating)
        {
            return new HalfPointsGameAccount(userName, initialRating);
        }
    }
}