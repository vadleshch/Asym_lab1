using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Asym_lab1
{
    internal class Lamer
    {
        static Random r = new Random();
        static int m = (int)Math.Pow(2, 32);
        static int a = (int)Math.Pow(2, 16) + 1;
        static int c = 119;

        static int function(int x)
        {
            return (a * x + c) % m;
        }
        static byte[] GetLow(int length)
        {
            int x = (int)r.Next(1, 256);
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                x = function(x);
                bytes[i] = (byte)(x & 0xFF);
            }
            return bytes;
        }

        static byte[] GetHigh(int length)
        {
            int x = (int)r.Next(1, 256);
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                x = function(x);
                bytes[i] = (byte)((x >> 24) & 0xFF);
            }
            return bytes;
        }
    }
}
