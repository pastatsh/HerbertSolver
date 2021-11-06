//#define KOTEI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    class Solver1 : Solver
    {
        public Solver1(Stage s) : base(s) { }

        public override string Solve(int length)
        {
#if KOTEI
            string kotei = "Xs";
#endif

            //a(X):Aa(B) Ca(D)
            length -= 4;
            for (int c = 0; c < length - 3; c++)
                for (int a = 1; a < length - 1 - c; a++)
                    for (int b = length - a - c; b >= 2; b--)
                    {
#if KOTEI
                        if (b != kotei.Length) continue;
#endif
                        int d = length - a - b - c;
                        for (int e = cLen[SRLX, a]; e < cLen[SRLX, a + 1]; e++)
                        {
                            string i = Convert(SRLX, e);
                            if (!Check(i) || !i.Contains('X') ||
                                (i[0] == 'l' && (i[a-1] == 'r' ||
                                (i[a-1] == 'l' && (i[1] == 'l' || i[a-2] == 'l'))))
                                || (i[0] == 'r' && i[a-1] == 'l')) continue;
                            for (int f = cLen[SRLX, b]; f < cLen[SRLX, b + 1]; f++)
                            {
                                string j = Convert(SRLX, f);
#if KOTEI
                                if (j != kotei) continue;
#endif
                                string ck = i + j;
                                if (!Check(j) || !j.Contains('X') || 
                                    (!ck.Contains('s') && !ck.Contains('r') && !ck.Contains('l'))) continue;
                                for (int g = cLen[SRL, c]; g < cLen[SRL, c + 1]; g++)
                                {
                                    string k = Convert(SRL, g);
                                    if (!Check(k)) continue;
                                    for (int h = cLen[SRL, d]; h < cLen[SRL, d + 1]; h++)
                                    {
                                        string l = Convert(SRL, h);
                                        string ck2 = ck+ l;
                                        if (!Check(l) || !ck2.Contains('s') || j.Replace("X", l).Length == 0
                                            || (!ck2.Contains('r') && !ck2.Contains('l'))) continue;

                                        NowCode = "a(X):" + i + "a(" + j + ") " + k + "a(" + l + ")";
                                        if (Judge(i, j, k, l))
                                            return "a(X):" + i + "a(" + j + ")\r\n" + k + "a(" + l + ")";
                                    }
                                }
                            }
                        }
                    }
            return "見つかりませんでした。";
        }

        bool Judge(string func, string reFunc, string code, string reCode)
        {
            stage.Init();
            while (true)
            {
                foreach (var c in code)
                {
                    //for (int i = 0; i < (c == 's' ? 3 : 1); i++)
                    //{
                        ActionResult r = stage.Step(c);
                        if (r == ActionResult.Clear)
                            return true;
                        else if (r == ActionResult.LimitOver || r == ActionResult.GrayLimitOver)
                            return false;
                    //}
                }

                code = func.Replace("X", reCode);
                reCode = reFunc.Replace("X", reCode);
            }
        }
    }
}
