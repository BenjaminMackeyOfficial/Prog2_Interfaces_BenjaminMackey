using System;


namespace Prog2_Interfaces_BenjaminMackey
{
    static class Extensions
    {
        static Random random = new Random();
        public static int Clamp(this int num, int minNum, int maxNum)
        { 
            if (num < minNum) return minNum; 
            if (num > maxNum) return maxNum; 
            return num;
        }
        public static int AddRandom(this int startNum, int min, int max)
        {
            return startNum + random.Next(min, max + 1);
        }
    }
}
