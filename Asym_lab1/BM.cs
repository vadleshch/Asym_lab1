using System;
using System.Collections.Generic;
using System.Text;

namespace Asym_lab1
{
    using SpRzOM;
    using System;
    using System.Globalization;
    using System.Numerics;

    namespace Asym_lab1
    {
        internal class BM
        {
            static Random rnd = new Random();
            static Long p = new Long("CEA42B987C44FA642D80AD9F51F10457690DEF10C83D0BC1BCEE12FC3B6093E3");
            static Long a = new Long("5B88C41246790891C095E2878880342E88C79974303BD0400B090FE38A688356");
            static Long q = new Long("675215CC3E227D3216C056CFA8F8822BB486F788641E85E0DE77097E1DB049F1");
            static Long p1 = new Long("CEA42B987C44FA642D80AD9F51F10457690DEF10C83D0BC1BCEE12FC3B6093E2");
            static int len = p.BitLength();
            static Long mu = (new Long("1") << (2 * len)) / p;

            static Long Barret(Long A)
            {
                Long t = A >> (len - 1);
                t = t * mu;
                t = t >> (len + 1);
                Long res = A - (t * p);
                while (Long.LongCmp(res, p, false) >= 0)
                {
                    res = res - p;
                }
                return res;
            }

            static Long ModPow(Long b, Long e)
            {
                Long res = new Long("1");
                for (int i = e.BitLength() - 1; i >= 0; i--)
                {
                    res = Barret(res * res);
                    if (e.GetBit(i))
                    {
                        res = Barret(res * b);
                    }
                }
                return res;
            }

            static Long RandomLong(Long max)
            {
                string str = "";
                for (int i = 0; i < max.Number.Count * 8; i++)
                {
                    str += rnd.Next(16).ToString("X");
                }
                return Long.RemoveEmpty(new Long(str)) % max;
            }

            public static byte[] GetBM(int length)
            {
                Long T = RandomLong(p1) + new Long("1"); 
                byte[] bytes = new byte[length];
                int bit;
                for (int i = 0; i < length * 8; i++)
                {
                    T = ModPow(a, T);
                    bit = Long.LongCmp(T, q, false) == -1 ? 1 : 0; 
                    bytes[i / 8] = (byte)((bytes[i / 8] << 1) | bit);
                }
                return bytes;
            }

            public static byte[] GetBMBytes(int length)
            {
                Long T = RandomLong(p1) + new Long("1");
                byte[] bytes = new byte[length];
                Long k;
                for (int i = 0; i < length; i++)
                {
                    T = ModPow(a, T);
                    k = ((T << 8) - new Long("1")) / p1;
                    bytes[i] = (byte)k.Number[0];
                }
                return bytes;
            }
        }
    }
}
