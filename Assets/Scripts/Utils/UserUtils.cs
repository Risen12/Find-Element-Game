using System;

namespace Game.Utils
{
    public static class UserUtils
    {
        private static Random _random = new Random();

        public static int GetRandomNumber(int minNumber, int maxNumber)
        {
            return _random.Next(minNumber, maxNumber + 1);
        }
    }
}