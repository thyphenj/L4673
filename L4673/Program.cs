using System;
using System.Collections.Generic;

namespace L4673
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- Have a look at c & Y - and create valid possibilities for b
            // -- c has to be a three digit cube

            List<int> poss_b = new List<int>();

            int c = 0;
            int Y = 0;
            foreach (int c_guess in new int[] { 125, 216, 343, 729 })
            {
                poss_b.Add(c_guess);

                int Y_guess = c_guess + c_guess;
                if (Y_guess >= 1000 && IsValid(Y_guess))
                {
                    c = c_guess;
                    Y = Y_guess;
                }
            }
            poss_b.Remove(c);

            // -- Try for T, U, V and W

            int H = 0;
            int T = 0;
            int U = 0;
            int V = 0;
            int W = 0;
            foreach (int V_guess in Factorize(Y, 2))
            {
                foreach (int prm in new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53 })
                {
                    int U_guess = V_guess * prm;
                    if (U_guess >= 100 && U_guess < 1000)
                    {
                        foreach (int H_guess in new int[] { 4181, 6765 })//-- These are the only valid 4 digit fibonacci numbers
                        {
                            foreach (int T_guess in Factorize(H_guess, 3))
                            {
                                int W_guess = (U_guess - T_guess) * (U_guess - T_guess);
                                if (W_guess >= 1000 && W_guess < 10000 && IsValid(W_guess))
                                {
                                    H = H_guess;
                                    T = T_guess;
                                    U = U_guess;
                                    V = V_guess;
                                    W = W_guess;

                                }
                            }
                        }
                    }
                }
            }

            // -- we can also just calc C now

            int C = H + c;

            // -- Have a quick look at E

            int E = 0;
            for (int ind = 10; T * ind * ind < 100000; ind++)
            {
                int E_guess = T * ind * ind;
                if (E_guess >= 10000 && IsValid(E_guess))
                    E = E_guess;
            }

            // -- how are we doing for L and b

            int L = 0;
            int b = 0;
            foreach (int b_guess in poss_b)
            {
                int L_guess = E + b_guess;
                if (IsValid(L_guess))
                {
                    L = L_guess;
                    b = b_guess;
                }
            }

            // -- let's try f and M
            int M = 0;
            int f = 0;
            for (int ind = 1; V + ind * ind < 100; ind++)
            {
                int f_guess = V + ind * ind;
                int M_guess = V * f_guess;
                if (IsValid(f_guess) && IsValid(M_guess))
                {
                    f = f_guess;
                    M = M_guess;
                }
            }

            // -- we now know K and a

            int K = V + f;
            int a = T * f;

            // -- try for d

            int d = 0;
            for (int ind = 2; K * ind * ind < 1000; ind++)
            {
                int d_guess = K * ind * ind;
                if (d_guess >= 100 && IsValid(d_guess))
                {
                    d = d_guess;
                }
            }

            // -- Shall we try F

            int F = 0;
            foreach (var F_guess in Factorize(H, 2))
            {
                F = F_guess;
            }

            // -- Try for B & O

            int B = 0;
            int O = 0;
            foreach (int B_guess in Factorize(T - F - F - F, 2))
            {
                int O_guess = B_guess + B_guess + f;
                if (IsValid(O_guess) && O_guess.ToString().Length == 2)
                {
                    B = B_guess;
                    O = O_guess;
                }
            }

            // -- We can just calc R & Z

            int R = c - B - b;
            int Z = O * d;

            // -- Let's try for e, Q, D, G and S

            int e = 0;
            int Q = 0;
            int D = 0;
            int G = 0;
            int S = 0;
            for (int ind = 1; V + ind * ind < 100; ind++)
            {
                int e_guess = V + ind * ind;
                int Q_guess = B + e_guess - F;
                int D_guess = M + Q_guess - B;
                int G_guess = D_guess + T - f;
                int S_guess = G_guess * (B + F);
                if (IsValid(e_guess) && IsValid(Q_guess) && IsValid(D_guess) && IsValid(G_guess) && IsValid(S_guess))
                {
                    e = e_guess;
                    Q = Q_guess;
                    D = D_guess;
                    G = G_guess;
                    S = S_guess;
                }
            }

            int X = T * (Q - V);
            int J = d - e;
            int I = F + J + d;

            // -- Let's try for A, N & P

            Console.WriteLine("-----------------------These can't actually be determined");

            int A = 0;
            int N = 0;
            int P = 0;

            for (int A_guess = 1000; A_guess < 10000; A_guess++)
            {
                if (IsValid(A_guess) && A_guess % F == 0 && A_guess % e == 0)
                {
                    Console.WriteLine($"A={A_guess}");
                }
            }
            for (int ind = 4; Q * ind * ind < 10000; ind++)
            {
                int N_guess = Q * ind * ind;
                int P_guess = N_guess + V;
                if (N_guess.ToString().Length == 4 && IsValid(N_guess) && IsValid(P_guess) && P_guess.ToString().Length == 4)
                {
                    Console.WriteLine($"N={N_guess} P={P_guess}");
                }
            }

            Console.WriteLine("-----------------------What we do have");

            Console.WriteLine($"A {A,5} B {B,5}");
            Console.WriteLine($"C {C,5} D {D,5}");
            Console.WriteLine($"E {E,5} F {F,5}");
            Console.WriteLine($"G {G,5} H {H,5}");
            Console.WriteLine($"I {I,5} J {J,5}");
            Console.WriteLine($"K {K,5} L {L,5}");
            Console.WriteLine($"M {M,5} N {N,5}");
            Console.WriteLine($"O {O,5} P {P,5}");

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