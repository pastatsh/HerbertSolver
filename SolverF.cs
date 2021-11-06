using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    class SolverF : Solver
    {
        public SolverF(Stage s) : base(s) { }

        public override string Solve(int length)
        {
            length -= 2;

            List<string>[] list = new List<string>[length + 1];
            list[0] = new List<string>();
            list[0].Add(" ");
            list[1] = new List<string>();
            list[1].AddRange(new[] { "s", "r", "l", " f" });
            for (int i = 2; i < Math.Min(length - 1, 10); i++)
            {
                NowCode = i.ToString();
                list[i] = new List<string>();
                foreach (var prev in list[i - 1])
                    list[i].Add("s" + prev + "+");
                foreach (var prev in list[i - 2])
                {
                    list[i].Add("rs" + prev + "++");
                    list[i].Add("ls" + prev + "++");
                }
                if (i == 2)
                    list[i].Add("ll+");
                else
                    foreach (var prev in list[i - 3])
                        list[i].Add("lls" + prev + "+++");

                for (int a = 0; a < i; a++)
                    foreach (var left in list[a])
                        foreach (var right in list[i - a - 1])
                            list[i].Add(left + "f" + right + "+");

                for (int a = 0; a < i - 1; a++)
                    foreach (var left in list[a])
                        foreach (var right in list[i - a - 2])
                        {
                            list[i].Add("r" + left + "f" + right + "++");
                            list[i].Add("l" + left + "f" + right + "++");
                        }

                for (int a = 0; a < i - 2; a++)
                    foreach (var left in list[a])
                        foreach (var right in list[i - a - 3])
                            list[i].Add("ll" + left + "f" + right + "+++");

                //for (int k = cLen[SRLX, length - i]; k < cLen[SRLX, length - i + 1]; k++)
                for (int k = 1; k < cLen[SRLX, length - i + 1]; k++)
                {
                    string func = Convert(SRLX, k);
                    if (Check(func) && func.Contains("X"))
                        foreach (var code in list[i])
                            if (code.Contains("f") && Judge(func, code))
                            {
                                Stack<string> stack = new Stack<string>();
                                foreach (var c in code)
                                {
                                    if (c == ' ')
                                        stack.Push("");
                                    else if (c == 'f')
                                        stack.Push("f(" + stack.Pop() + ")");
                                    else if (c == '+')
                                    {
                                        string right = stack.Pop();
                                        stack.Push(stack.Pop() + right);
                                    }
                                    else
                                        stack.Push(c.ToString());
                                }
                                return "f(X):" + func + "\r\n" + stack.Pop();
                            }
                }
            }
            return "見つかりませんでした。";
        }

        bool Judge(string func, string code)
        {
            Stack<string> stack = new Stack<string>();
            foreach (var c in code)
            {
                if (c == ' ')
                    stack.Push("");
                else if (c == 'f')
                    stack.Push(func.Replace("X", stack.Pop()));
                else if (c == '+')
                {
                    string right = stack.Pop();
                    stack.Push(stack.Pop() + right);
                }
                else
                    stack.Push(c.ToString());
            }

            stage.Init();
            code = stack.Pop();
            foreach (var c in code)
                if (stage.Step(c) == ActionResult.Clear)
                    return true;
            return false;
        }
    }
}