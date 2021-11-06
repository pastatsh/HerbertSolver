using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    class Solver3 : Solver
    {
        public Solver3(Stage s) : base(s) { }

        public override string Solve(int length)
        {
            //a(X,Y,Z):Aa(B,C,D) Ea(F,G,H)
            length -= 6;
            for (int e = 0; e <= length - 3; e++)
               for (int a = 1; a <= length - 3 - e; a++)
                    for (int f = 0; f <= length - 3 - e - a; f++)
                        for (int g = 0; g <= length - 3 - e - a - f; g++)
                            for (int h = 0; h <= length - 3 - e - a - f - g; h++)
                                for (int c = 1; c <= length - 2 - e - a - f - g - h; c++)
                                    for (int b = length - e - a - f - g - h - c; b > 1; b--)
                                    {
                                        string result = solve(a, b, c, length - a - b - c - e - f - g - h, e, f, g, h);
                                        if (result != null) return result;
                                    }
            return "見つかりませんでした。";
        }

        public string solve(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            //todo
            if (d == 0 && h == 0) return null;
            for (int x = cLen[SRLXYZ, a]; x < cLen[SRLXYZ, a + 1]; x++)
            {
                string i = Convert(SRLXYZ, x);
                if (!Check(i) || !i.Contains('X')) continue;
                for (int q = cLen[SRLXYZ, b]; q < cLen[SRLXYZ, b + 1]; q++)
                {
                    string j = Convert(SRLXYZ, q);
                    if (!Check(j) || j == "X") continue;
                    for (int r = cLen[SRLXYZ, c]; r < cLen[SRLXYZ, c + 1]; r++)
                    {
                        string k = Convert(SRLXYZ, r);
                        if (!Check(k) || k == "Y") continue;
                        for (int s = cLen[SRLXYZ, d]; s < cLen[SRLXYZ, d + 1]; s++)
                        {
                            string l = Convert(SRLXYZ, s);
                            if (!Check(l) || l == "Z") continue;
                            for (int t = cLen[SRL, e]; t < cLen[SRL, e + 1]; t++)
                            {
                                string m = Convert(SRL, t);
                                if (!Check(m)) continue;
                                for (int u = cLen[SRL, f]; u < cLen[SRL, f + 1]; u++)
                                {
                                    string n = Convert(SRL, u);
                                    if (!Check(n)) continue;
                                    for (int v = cLen[SRL, g]; v < cLen[SRL, g + 1]; v++)
                                    {
                                        string o = Convert(SRL, v);
                                        if (!Check(o)) continue;
                                        for (int w = cLen[SRL, h]; w < cLen[SRL, h + 1]; w++)
                                        {
                                            string p = Convert(SRL, w);
                                            if (!Check(p)) continue;
                                            string ck = i + j + k + l + n + o + p;
                                            if (!ck.Contains('s') || (!ck.Contains('r') && !ck.Contains('l'))) continue;

                                            NowCode = "a(X,Y,Z):" + i + "a(" + j + "," + k + "," + l + ") " + m + "a(" + n + "," + o + "," + p + ")";
                                            if (Judge(i, j, k, l, m, n,o,p))
                                                return "a(X,Y,Z):" + i + "a(" + j + "," + k + "," + l + ")\r\n" + m + "a(" + n + "," + o + "," + p + ")";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        bool Judge(string func, string funcX, string funcY, string funcZ,string code,string X, string Y,string Z)
        {
            /*
            if (func == "X" && funcX == "YXY" && funcY == "Xr" && Y == "s")
                X = "";
             */
            string tmpX, tmpY;
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

                code = func.Replace("X",X).Replace("Y",Y).Replace("Z",Z);
                tmpX = funcX.Replace("X", X).Replace("Y", Y).Replace("Z", Z);
                tmpY = funcY.Replace("X", X).Replace("Y", Y).Replace("Z", Z);
                Z = funcZ.Replace("X", X).Replace("Y", Y).Replace("Z", Z);
                X = tmpX;
                Y = tmpY;

                if (stack++ > 5 && code.Length == 0) return false;
                if (X.Length +Y.Length+Z.Length > 1000000) return false;
            }
        }
    }
}
