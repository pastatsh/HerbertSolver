using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    class Solver12 : Solver
    {
        string first, second;

        public Solver12(Stage s, string first, string second)
            : base(s)
        {
            this.first = first;
            this.second = second;
        }

        public override string Solve(int length)
        {
            int[,] pattern = { { 1, -1, 1, 1 }, { -1, 1, 1, 1 }, { 1, -1, 1, -1 }, { -1, 1, 1, -1 }, { 1, -1, -1, 1 }, { -1, 1, -1, 1 } };

            length -= first.Length + second.Length + 8;

            //a(X):firsta(aX+b)seconda(cX+d) a(e)
            for (int e = 255; e > 0; e--)
                for (int a = 1; a < length; a++)
                    for (int c = length - a; c >= 1; c--)
                        for (int b = 1; b < 255; b++)
                            for (int d = 1; d < 255; d++)
                                for (int i = 0; i < 6; i++)
                                {
                                    NowCode = a + "," + b + "," + c + "," + d + "," + e;
                                    stage.Init();
                                    int p = a * pattern[i, 0];
                                    int q = b * pattern[i, 1];
                                    int r = c * pattern[i, 2];
                                    int s = d * pattern[i, 3];
                                    if (Judge(p, q, r, s, e))
                                    {
                                        string ret = "a(X):" + first + "a(";
                                        if (p > 0)
                                        {
                                            ret += "X";
                                            for (int j = 1; j < p; j++)
                                                ret += "+X";
                                            ret += q;
                                        }
                                        else
                                        {
                                            ret += q;
                                            for (int j = 0; j < -p; j++)
                                                ret += "-X";
                                        }
                                        ret += ")" + second + "a(";
                                        if (r > 0)
                                        {
                                            ret += "X";
                                            for (int j = 1; j < r; j++)
                                                ret += "+X";
                                            ret += (s > 0 ? "+" : "") + s;
                                        }
                                        else
                                        {
                                            ret += s;
                                            for (int j = 0; j < -r; j++)
                                                ret += "-X";
                                        }
                                        return ret + ")\r\na(" + e + ")";
                                    }
                                }
            return "見つかりませんでした。";
        }

        bool Judge(int a, int b, int c, int d, int e)
        {
            int n;
            for (; ; )
            {
                if (e > 255)
                    return false;

                for (; ; )
                {
                    foreach (var s in first)
                    {
                        ActionResult r = stage.Step(s);
                        if (r == ActionResult.Clear)
                            return true;
                        else if (r == ActionResult.LimitOver || r == ActionResult.GrayLimitOver)
                            return false;
                    }

                    n = a * e + b;
                    if (n <= 0)
                        break;
                    if (n > 255)
                        return false;
                    e = n;
                }

                foreach (var s in second)
                {
                    ActionResult r = stage.Step(s);
                    if (r == ActionResult.Clear)
                        return true;
                    else if (r == ActionResult.LimitOver || r == ActionResult.GrayLimitOver)
                        return false;
                }
                e = c * e + d;
            }
        }
    }
}