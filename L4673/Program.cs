using System;
using System.Collections.Generic;

namespace L4673
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("-----------");
                int T = 165;

                int[] V = { 18, 27, 54, 81 };

                int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53 };
                int[] squares = { 1296, 4761, 5476, 6561, 7056, 9216 };

                foreach (int v in V)
                    foreach (int p in primes)
                    {
                        int U = v * p;
                        if (U > 100 && U < 1000)
                        {
                            int W = (U - T) * (U - T);
                            if (W > 1000 && W < 10000 && valid(W))
                                Console.WriteLine($"V={v} U={U} W={W} (prime={p})");
                        }
                    }
            }
            {
                Console.WriteLine("-----------");
                int c = 729;
                int B = 21;

                int[] bList = { 125, 216, 343 };
                foreach (int b in bList)
                {
                    int R = c - B - b;
                    if (valid(R))
                        Console.WriteLine($"b={b} R={R}");
                }

            }
            {
                Console.WriteLine("-----------");
                int T = 165;
                int n = 2;
                int E = n * n * T;
                while (E < 100000)
                {
                    if (E > 10000 && valid(E))
                        Console.WriteLine($"E={E} (n={n})");
                    n++;
                    E = n * n * T;
                }
            }

            {
                Console.WriteLine("-----------");
                int V = 18;
                int n = 2;
                int e = V + n * n;
                while (e < 100)
                {
                    if (valid(e) && e != 34)
                    {
                        int Q = 21 + e - 41;
                        if (Q > 9 && valid(Q) && Q != 34)
                        {
                            int D = 612 + Q - 21;
                            if (valid(D))
                            {
                                int p = 2;
                                int N = Q * p * p;
                                while (N < 10000)
                                {
                                    if (N > 1000 && valid(N))
                                        Console.WriteLine($"e={e} Q={Q} D={D} N={N}");
                                    p++;
                                    N = Q * p * p;
                                }
                            }
                        }
                    }
                    n++;
                    e = V + n * n;
                }
            }
            {
                Console.WriteLine("-----------");
                int[] cubes = { 125, 216, 343 };
                int E = 72765;

                foreach (int b in cubes)
                {
                    int L = E + b;
                    if (valid(L))
                    {
                        Console.WriteLine($"b={b} L={L}");
                    }
                }
            }

        }
        private static bool valid(int n)
        {
            string str = n.ToString();
            bool nextIsOdd = "2468".Contains(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                if ("02468".Contains(str[i]) && nextIsOdd)
                    return false;
                else if ("13579".Contains(str[i]) && !nextIsOdd)
                    return false;
                nextIsOdd = !nextIsOdd;
            }
            return true;
        }
    }
}