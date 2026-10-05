using System;
using System.Collections.Generic;
using System.Text;

namespace Asym_lab1
{
    internal class LN
    {
        static Random r = new Random();
        static byte[] L20 (int length)
        {
            byte[] bytes = new byte[length];
            for (int i = 0; i < 20; i++)
            {
                bytes[i] = (byte)r.Next(1, 256);
            }
            for (int i = 20; i < length; i++)
            {
                bytes[i] = (byte)(bytes[i - 20] ^ bytes[i - 9] ^ bytes[i - 5] ^ bytes[i - 3]);
            }
            return bytes;
        }

        static byte[] L89(int length)
        {
            byte[] bytes = new byte[length];
            for (int i = 0; i < 89; i++)
            {
                bytes[i] = (byte)r.Next(1, 256);
            }
            for (int i = 89; i < length; i++)
            {
                bytes[i] = (byte)(bytes[i - 89] ^ bytes[i - 38]);
            }
            return bytes;
        }
    }
}
