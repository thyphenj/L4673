using System;
using System.Collections.Generic;

namespace L4673
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prime = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53 };

            int[] all_square2 = { 16, 25, 36, 49, 64, 81 };
            int[] all_square3 = { 100, 121, 144, 169, 196, 225, 256, 289, 324, 361, 400, 441, 484, 529, 576, 625, 676, 729, 784, 841, 900, 961 };

            List<int> cubes = new List<int> { 125, 216, 343, 512, 729 };

            {
                // -- here are all the possible value for 'H'

                List<int> poss_H = new List<int> { 4181, 6765 };

                //-- Have a look at b, c & Y

                List<int> poss_b = new List<int>();
                List<int> poss_c = new List<int>();
                List<int> poss_Y = new List<int>();

                foreach (int c_ in cubes)
                {
                    if (IsValid(c_))
                    {
                        int Y_ = c_ + c_;
                        if (Y_ >= 1000 && IsValid(Y_))
                        {
                            poss_c.Add(c_);
                            poss_Y.Add(Y_);
                        }
                        else
                            poss_b.Add(c_);
                    }
                }

                int c = 0, Y = 0;
                if (poss_c.Count == 1)
                {
                    c = poss_c[0];
                    Y = poss_Y[0];
                    poss_b.Remove(c);
                }

                // -- Try for T, U, V and W

                List<int> poss_T = new List<int>();
                List<int> poss_U = new List<int>();
                List<int> poss_V = new List<int>();
                List<int> poss_W = new List<int>();

                int h_value = 0;
                foreach (int H_ in poss_H)
                    foreach (int T_ in Factorize(H_, 3))
                        foreach (int V_ in Factorize(Y, 2))
                            foreach (int prm in prime)
                            {
                                int U_ = V_ * prm;
                                if (U_ >= 100 && U_ < 1000)
                                {
                                    int W_ = (U_ - T_) * (U_ - T_);
                                    if (W_ >= 1000 && W_ < 10000 && IsValid(W_))
                                    {
                                        h_value = H_;
                                        poss_T.Add(T_);
                                        poss_U.Add(U_);
                                        poss_V.Add(V_);
                                        poss_W.Add(W_);

                                    }
                                }
                            }
                int H = 0, T = 0, U = 0, V = 0, W = 0;
                if (poss_T.Count == 1)
                {
                    H = h_value;
                    T = poss_T[0];
                    U = poss_U[0];
                    V = poss_V[0];
                    W = poss_W[0];
                }

                // -- we can also just calc C now
                int C = H + c;

                // -- Have a quick look at E
                List<int> poss_E = new List<int>();
                for (int ind = 10; T * ind * ind < 100000; ind++)
                {
                    int E_ = T * ind * ind;
                    if (E_ >= 10000 && IsValid(E_))
                        poss_E.Add(E_);
                }

                int E = 0;
                if (poss_E.Count == 1)
                {
                    E = poss_E[0];
                }

                // -- how are we doing for L and b
                List<int> poss_L = new List<int>();
                foreach (int b_ in poss_b)
                {
                    int L_ = E + b_;
                    if (IsValid(L_))
                    {
                        poss_L.Add(L_);
                    }
                }
                int L = 0;
                int b = 0;
                if (poss_L.Count == 1)
                {
                    L = poss_L[0];
                    b = L - E;
                    poss_b = new List<int> { b };
                }

                // -- let's try f and M
                List<int> poss_f = new List<int>();
                List<int> poss_M = new List<int>();

                for (int ind = 1; V + ind * ind < 100; ind++)
                {
                    int f_ = V + ind * ind;
                    int M_ = V * f_;
                    if (IsValid(f_) && IsValid(M_))
                    {
                        poss_f.Add(f_);
                        poss_M.Add(M_);
                    }
                }
                int f = 0, M = 0;
                if (poss_M.Count == 1)
                {
                    M = poss_M[0];
                    f = poss_f[0];
                }

                // -- we now know K and a
                int K = V + f;
                int a = T * f;

                // -- try for d
                List<int> poss_d = new List<int>();

                for (int ind = 2; K * ind * ind < 1000; ind++)
                {
                    int d_ = K * ind * ind;
                    if (d_ >= 100 && IsValid(d_))
                    {
                        poss_d.Add(d_);
                    }
                }
                int d = 0;
                if (poss_d.Count == 1)
                    d = poss_d[0];

                // -- Shall we try F
                List<int> poss_F = new List<int>();

                foreach (var F_ in Factorize(H, 2))
                {
                    poss_F.Add(F_);
                }
                int F = 0;
                if (poss_F.Count == 1)
                    F = poss_F[0];

                // -- Try for  & O
                List<int> poss_B = new List<int>();
                List<int> poss_O = new List<int>();

                foreach (int B_ in Factorize(T - F - F - F, 2))
                {
                    int O_ = B_ + B_ + f;
                    if (IsValid(O_) && O_.ToString().Length == 2)
                    {
                        poss_B.Add(B_);
                        poss_O.Add(O_);
                    }
                }
                int B = 0;
                int O = 0;
                if (poss_B.Count == 1)
                {
                    B = poss_B[0];
                    O = poss_O[0];
                }

                // -- We can just calc R & Z

                int R = c - B - b;
                int Z = O * d;

                // -- Let's try for e, Q, D
                List<int> poss_e = new List<int>();
                List<int> poss_Q = new List<int>();
                List<int> poss_D = new List<int>();
                List<int> poss_G = new List<int>();
                List<int> poss_S = new List<int>();

                for (int ind = 1; V + ind * ind < 100; ind++)
                {
                    int e_ = V + ind * ind;
                    int Q_ = B + e_ - F;
                    int D_ = M + Q_ - B;
                    int G_ = D_ + T - f;
                    int S_ = G_ * (B + F);
                    if (IsValid(e_) && IsValid(Q_) && IsValid(D_) && IsValid(G_) && IsValid(S_))
                    {
                        poss_e.Add(e_);
                        poss_Q.Add(Q_);
                        poss_D.Add(D_);
                        poss_G.Add(G_);
                        poss_S.Add(S_);
                    }
                }

                int e = 0, Q = 0, D = 0, G = 0, S = 0;
                if (poss_e.Count == 1)
                {
                    e = poss_e[0];
                    Q = poss_Q[0];
                    D = poss_D[0];
                    G = poss_G[0];
                    S = poss_S[0];
                }
                int X = T * (Q - V);
                int J = d - e;
                int I = F + J + d;

                // -- Let's try for N & P
                List<int> poss_N = new List<int>();
                List<int> poss_P = new List<int>();

                for ( int ind = 4; Q * ind * ind < 10000; ind++)
                {
                    int N_ = Q * ind * ind;
                    int P_ = N_ + V;
                    if ( N_.ToString().Length == 4 && IsValid(N_) && IsValid(P_) && P_.ToString().Length == 4)
                    {
                        poss_N.Add(N_);
                        poss_P.Add(P_);
                        Console.WriteLine($"N={N_} P={P_}");
                    }
                }

                // -- can't think of a sensible way to do A, so
                List<int> poss_A = new List<int>();

                for ( int A_  = 1000; A_ < 10000; A_++)
                {
                    if ( IsValid(A_) && A_% F == 0 && A_ % e == 0)
                    {
                        poss_A.Add(A_);
                        Console.WriteLine(A_);
                    }
                }

                Console.WriteLine("------");
                Console.WriteLine($"A       B {B,5}");
                Console.WriteLine($"C {C,5} D {D,5}");
                Console.WriteLine($"E {E,5} F {F,5}");
                Console.WriteLine($"G {G,5} H {H,5}");
                Console.WriteLine($"I {I,5} J {J,5}");
                Console.WriteLine($"K {K,5} L {L,5}");
                Console.WriteLine($"M {M,5} N       ");
                Console.WriteLine($"O {O,5} P       ");

                Console.WriteLine();

                Console.WriteLine($"Q {Q,5}");
                Console.WriteLine($"R {R,5}");
                Console.WriteLine($"S {S,5}");
                Console.WriteLine($"T {T,5}");
                Console.WriteLine($"U {U,5}");
                Console.WriteLine($"V {V,5}");
                Console.WriteLine($"W {W,5}");
                Console.WriteLine($"X {X,5}");
                Console.WriteLine($"Y {Y,5}");
                Console.WriteLine($"Z {Z,5}");
                Console.WriteLine($"a {a,5}");
                Console.WriteLine($"b {b,5}");
                Console.WriteLine($"c {c,5}");
                Console.WriteLine($"d {d,5}");
                Console.WriteLine($"e {e,5}");
                Console.WriteLine($"f {f,5}");
                Console.WriteLine("------");




                //// -------------------------------------------------------------
                //Console.WriteLine();
                //Console.WriteLine("----------- These are speculative");
                ////int B = 21;
                //for (int B_ = 10; B_ < 100; B_++)
                //{
                //    int R = c - B_ - b;
                //    if (IsValid(R) && R.ToString().Length == 3)
                //        Console.WriteLine($"b={b} R={R} B={B_}");
                //}
            }


            {
                //Console.WriteLine("-----------");
                //int V = 18;
                //int n = 2;
                //int e = V + n * n;
                //while (e < 100)
                //{
                //    if (IsValid(e) && e != 34)
                //    {
                //        int Q = 21 + e - 41;
                //        if (Q > 9 && IsValid(Q) && Q != 34)
                //        {
                //            int D = 612 + Q - 21;
                //            if (IsValid(D))
                //            {
                //                int p = 2;
                //                int N = Q * p * p;
                //                while (N < 10000)
                //                {
                //                    if (N > 1000 && IsValid(N))
                //                        Console.WriteLine($"e={e} Q={Q} D={D} N={N}");
                //                    p++;
                //                    N = Q * p * p;
                //                }
                //            }
                //        }
                //    }
                //    n++;
                //    e = V + n * n;
                //}
            }


        }

        private static List<int> Factorize(int y, int v)
        {
            List<int> retval = new List<int>();
            for (int i = 1; i <= y; i++)
            {
                if (i.ToString().Length == v && y % i == 0 && IsValid(i) && !retval.Contains(i))
                    retval.Add(i);
            }
            return (retval);
        }

        private static bool IsValid(int n)
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