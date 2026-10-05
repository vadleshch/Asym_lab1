using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Asym_lab1
{
    internal class Wolfram
    {
        static Random rnd = new Random();
        static byte[] GetRandom(int length)
        {
            byte[] bytes = new byte[length];

            int r = rnd.Next(1, Int32.MaxValue);
            int x;

            for (int i = 0; i < length; i++)
            {
                x = 0;
                for (int j = 0; j < 8; j++)
                {
                    x = x | ((r & 1) >> j);
                    r = ((r << 1) | (r >> 31)) ^ (r | (r >> 1) | (r << 31));
                }
            }
            return bytes;
        }
    }
}
