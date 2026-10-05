using System;
using System.Collections.Generic;
using System.Text;

namespace Asym_lab1
{
    internal class Geffe
    {
        static Random r = new Random();

        static byte[] GetGeffe(int length)
        {
            byte[] x = new byte[length];
            byte[] y = new byte[length];
            byte[] s = new byte[length];
            byte[] z = new byte[length];
            for (int i = 0; i < 12; i++)
            {
                x[i] = (byte)r.Next(1, 256);
                y[i] = (byte)r.Next(1, 256);
                s[i] = (byte)r.Next(1, 256);
            }
            for (int i = 12; i < length; i++)
            {
                x[i] = (byte)(x[i - 11] ^ x[i - 9]);
                y[i] = (byte)(y[i - 9] ^ y[i - 8] ^ y[i - 6] ^ y[i - 5]);
                s[i] = (byte)(s[i - 10] ^ s[i - 7]);
                z[i] = (byte)((s[i] & x[i]) ^ (~s[i] & y[i]));
            }
            return z;
        }
    }
}
