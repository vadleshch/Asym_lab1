using SpRzOM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace Asym_lab1
{
    internal class BBS
    {
        static Random rnd = new Random();
        static Long p = new Long("D5BBB96D30086EC484EBA3D7F9CAEB07");
        static Long q = new Long("425D2B9BFDB25B9CF6C416CC6E37B59C1F");
        static Long n = p * q;
        static int len = n.BitLength();
        static Long mu = (new Long("1") << (2 * len)) / n;

        static Long Barret(Long A)
        {
            Long t = A >> (len - 1);
            t = t * mu;
            t = t >> (len + 1);
            Long res = A - (t * n);
            while (Long.LongCmp(res, n, false) >= 0)
            {
                res = res - n;
            }
            return res;
        }

        static Long RandomR0()
        {
            Long two = new Long("2");
            Long r;
            do
            {
                string str = "";
                for (int i = 0; i < n.Number.Count * 8; i++)
                {
                    str += rnd.Next(16).ToString("X");
                }
                r = Long.RemoveEmpty(new Long(str)) % n;
            }
            while (Long.LongCmp(r, two, false) == -1);
            return r;
        }

        public static byte[] GetBBS(int length)
        {
            Long r = RandomR0();
            byte[] bytes = new byte[length];
            int bit;
            for (int i = 0; i < length * 8; i++)
            {
                r = Barret(r * r);
                bit = (int)(r.Number[0] & 1);
                bytes[i / 8] = (byte)((bytes[i / 8] << 1) | bit);
            }
            return bytes;
        }

        public static byte[] GetBBSBytes(int length)
        {
            Long r = RandomR0();
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                r = Barret(r * r);
                bytes[i] = (byte)(r.Number[0] & 0xFF);
            }
            return bytes;
        }
    }
}
