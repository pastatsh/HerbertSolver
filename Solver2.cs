using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    class Solver2 : Solver
    {
        public Solver2(Stage s) : base(s) { }

        public override string Solve(int length){
            //a(X,Y):Aa(B,C) Da(E,F)
            int cnt = 0;
            length -= 5;
            for (int d = 0; d < length - 4; d++)
            {
                for (int e = 0; e < length - 4 - d; e++)
                {
                    for (int f = 0; f < length - 4 - d - e; f++)
                    {
                        for (int a = 1; a < length - 2 - d - e - f; a++)
                        {
                            //if (a != 1) continue;//kotei
                            for (int b = length - e - d - f - a; b >= 1; b--)
                            {
                                int c = length - a - b - d - e - f;
                                //if (c != 2) continue;//kotei2
                                if (c == 0 && f == 0) continue;
                                for (int p = cLen[SRLXY, a]; p < cLen[SRLXY, a + 1]; p++)
                                {
                                    string i = Convert(SRLXY, p);
                                    //if (i != "X") continue;//kotei
                                    if (!Check(i) || !i.Contains('X')) continue;
                                    for (int q = cLen[SRLXY, b]; q < cLen[SRLXY, b + 1]; q++)
                                    {
                                        string j = Convert(SRLXY, q);
                                        //if (!j.Contains('X') || !j.Contains('Y')) continue;//kotei
                                        //if (j.Count((ch) => ch == 'X') != 1 || !j.Contains('Y')) continue;//kotei
                                        if (!Check(j) || j == "X" || (!j.Contains('X') && !j.Contains('Y'))) continue;
                                        if (!i.Contains('Y') && !j.Contains('Y')) continue;
                                        for (int r = cLen[SRLXY, c]; r < cLen[SRLXY, c + 1]; r++)
                                        {
                                            string k = Convert(SRLXY, r);
                                            //if (k.Contains('X') || k.Count((ch) => ch == 'Y') != 1) continue;//kotei
                                            //if (k.Contains('X') || k.Contains('Y')) continue;//kotei
                                            //if (k != "sY" && k != "Ys") continue;//kotei2
                                            if (!Check(k) || k == "Y") continue;
                                            for (int s = cLen[SRL, d]; s < cLen[SRL, d + 1]; s++)
                                            {
                                                string l = Convert(SRL, s);
                                                if (!Check(l)) continue;
                                                for (int t = cLen[SRL, e]; t < cLen[SRL, e + 1]; t++)
                                                {
                                                    string m = Convert(SRL, t);
                                                    if (!Check(m)) continue;
                                                    for (int u = cLen[SRL, f]; u < cLen[SRL, f + 1]; u++)
                                                    {
                                                        string n = Convert(SRL, u);
                                                        string ck = i + j + k + m + n;
                                                        if (!Check(n) || !ck.Contains('s') || (!ck.Contains('r') && !ck.Contains('l'))) continue;

                                                        //if (ck.Count((cc) => cc == 's') != 1) continue;

                                                        NowCode = "a(X,Y):" + i + "a(" + j + "," + k + ") " + l + "a(" + m + "," + n + ")";
                                                        if (Judge(i, j, k, l, m, n))
                                                            return "a(X,Y):" + i + "a(" + j + "," + k + ")\r\n" + l + "a(" + m + "," + n + ")";
                                                        cnt++;// ss += NowCode + "\r\n";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return "見つかりませんでした。"+cnt;
        }

        bool Judge(string func, string funcX, string funcY, string code,string X, string Y)
        {
            string tmp;
            stage.Init();
            int stack = 0;
            while (true)
            {
                foreach (var c in code)
                {
                    ActionResult r = stage.Step(c);
                    if (r == ActionResult.Clear)
                        return true;
                    else if (r == ActionResult.LimitOver || r == ActionResult.GrayLimitOver)
                        return false;
                }

                code = func.Replace("X",X).Replace("Y",Y);
                tmp = funcX.Replace("X",X).Replace("Y",Y);
                Y = funcY.Replace("X", X).Replace("Y", Y);
                X = tmp;

                if (stack++ > 5 && code.Length == 0) return false;
                if (X.Length +Y.Length > 1000000) return false;
            }
        }
    }
}
