using System;
using System.Text;

namespace Utilities
{
    public static class RandomUtilites
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public static string RandomString(bool lowerCase)
        {
            return RandomString(RandomNumber(5, 15), lowerCase);
        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            string ret = builder.ToString();

            if (lowerCase)
                return ret.ToLower();
            return ret;
        }

        public static string RandomName()
        {
            string ret = RandomString(true);
            return Char.ToUpper(ret[0]) + ret.Substring(1);
        }

        public static string RandomName(int size)
        {
            string ret = RandomString(size, true);
            return Char.ToUpper(ret[0]) + ret.Substring(1);
        }
    }
}