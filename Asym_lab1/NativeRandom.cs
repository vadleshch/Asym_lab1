using System;
using System.Collections.Generic;
using System.Text;

namespace Asym_lab1
{
    internal class NativeRandom
    {
        static byte[] GetRandomBytes(int length)
        {
            byte[] bytes = new byte[length];
            Random random = new Random();
            random.NextBytes(bytes);
            return bytes;
        }
    }
}
