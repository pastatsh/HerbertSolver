using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    abstract class Solver
    {
        protected Stage stage;

        public string NowCode { get; protected set; }

        protected const int SRL = 3;
        protected const int SRLX = 4;
        protected const int SRLXY = 5;
        protected const int SRLXYZ = 6;

        protected int[,] cLen = new int[7, 30];

        public Solver(Stage s)
        {
            stage = s;

            for (int i = SRL; i <= SRLXYZ; i++)
                for (int j = 1; j < 15; j++)
                    cLen[i, j] = cLen[i, j - 1] * i + 1;
        }

        char[][] converter = { new char[] { }, new char[] { }, new char[] { }, 
            new char[]{ 'l', 's', 'r' }, 
            new char[]{ 'l', 'X', 's', 'r' }, 
            new char[]{ 'l', 'X', 'Y', 's', 'r' },
            new char[]{ 'l', 'X', 'Y', 'Z', 's', 'r' } };

        protected string Convert(int cCnt, int num)
        {
            string s = "";
            for (; num > 0; num = (num - 1) / cCnt)
                s += converter[cCnt][num % cCnt];
            return s;
        }

        protected bool Check(string code)
        {
            return !code.Contains("rr") && !code.Contains("rl") && !code.Contains("lr")
                && !code.Contains("rrr") && !code.Contains("lll");
        }

        public abstract string Solve(int length);
    }
}
