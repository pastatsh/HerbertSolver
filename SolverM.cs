using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    partial class SolverM : Solver
    {
        string code;

        public SolverM(Stage s, string _code)
            : base(s)
        {
            if (_code == "")
                _code = getCode();
            code = _code.Replace("l", "rrr").Replace("rrrr", "");
        }

        string getCode()
        {
            //初期位置を決める
            for (int sx = 0; sx < 25; sx++)
                for (int sy = 0; sy < 25; sy++)
                {
                    if (stage.CellData[sx, sy] != 'o' && stage.CellData[sx, sy] != 'u')
                        continue;
                    int[,] map = new int[25, 25];
                    Queue<Pos> queue = new Queue<Pos>();
                    map[sx, sy] = 1;
                    queue.Enqueue(new Pos(sx, sy, 2, null));
                    Pos pos = null;
                    while (queue.Count > 0)
                    {
                        pos = queue.Dequeue();
                        for (int i = 0; i < 4; i++)
                        {
                            int nx = pos.x + dx[i];
                            int ny = pos.y + dy[i];
                            if (nx >= 0 && nx < 25 && ny >= 0 && ny < 25 && map[nx, ny] == 0
                                && (stage.CellData[nx, ny] == 'o' || stage.CellData[nx, ny] == 'u'))
                            {
                                map[nx, ny] = pos.dist;
                                queue.Enqueue(new Pos(nx, ny, pos.dist + 1, pos));
                            }
                        }
                    }
                    int point = Math.Abs(sx - stage.StartX) + Math.Abs(sy - stage.StartY) - pos.dist;
                    if (point < best)
                    {
                        best = point;
                        bestMap = map;
                        bestPos = pos;
                    }
                }

            //クリティカルパスを求める
            while (bestPos.prev != null)
            {
                bestMap[bestPos.x, bestPos.y] = 999;
                bestPos = bestPos.prev;
            }

            //保存
            string str = "";
            for (int j = 0; j < 25; j++)
            {
                for (int i = 0; i < 25; i++)
                    str += bestMap[i, j] + "\t";
                str += "\r\n";
            }
            System.IO.File.WriteAllText("test.txt", str);

            //コード作成
            code = "";
            int x = stage.StartX, y = stage.StartY;
            for (; x > bestPos.x; x--)
                code += move[0];
            for (; y > bestPos.y; y--)
                code += move[1];
            for (; x < bestPos.x; x++)
                code += move[2];
            for (; y < bestPos.y; y++)
                code += move[3];
            return code + getCode(x, y);
        }

        int[,] bestMap = null;
        int best = int.MaxValue;
        Pos bestPos = null;
        int[] dx = { -1, 0, 1, 0 }, dy = { 0, -1, 0, 1 };
        string[] move = { "lsr", "s", "rsl", "rrsrr" };
        string getCode(int x, int y)
        {
            string code = "", last = "";
            bestMap[x, y] = 0;
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx >= 0 && nx < 25 && ny >= 0 && ny < 25 && bestMap[nx, ny] != 0)
                {
                    if (bestMap[nx, ny] == 999)
                        last = move[i] + getCode(nx, ny);
                    else
                        code += move[i] + getCode(nx, ny) + move[(i + 2) % 4];
                }
            }
            return code + last;
        }

        class Pos
        {
            public int x, y, dist;
            public Pos prev;
            public Pos(int x, int y, int dist, Pos prev)
            {
                this.x = x;
                this.y = y;
                this.dist = dist;
                this.prev = prev;
            }
        }

        public override string Solve(int length)
        {
            Generator list;
            try { list = s4_2(); }
            catch { list = s4(); }
            //list = ssrsl();

            //最適な圧縮関数を求める
            int t, k = 2;
            int prev = list.Count * 2;
            for (; k <= 23; k++)
            {
                //(関数定義)+(実行部)+(あまり)
                t = (k * 3 + 1) + (list.Count / k * (k + 1)) + Math.Min((list.Count % k) * 2, k + 1);
                if (t > prev)
                    break;
                prev = t;
            }
            k--;

            //出力
            string s = list.Func + "\r\n";
            if (k == 1)
            {
                foreach (var i in list)
                    s += "a(" + i + ")";
            }
            else
            {
                char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'M', 'N', 'O', 'P', 'Q', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                string s2 = "";
                char[] b = new char[k];
                for (t = 0; t < k; t++)
                {
                    b[t] = alpha[t];
                    s2 += "a(" + alpha[t] + ")";
                }
                s += "b(" + string.Join(",", b) + "):" + s2 + "\r\n";
                for (t = 0; t + k <= list.Count; t += k)
                    s += "b(" + string.Join(",", list.GetRange(t, k)) + ")";
                if ((list.Count % k) * 2 < k + 1)
                {
                    for (; t < list.Count; t++)
                        s += "a(" + list[t] + ")";
                }
                else
                {
                    int[] mod = new int[k];
                    for (int i = 0; i < k; i++)
                        mod[i] = (i + t < list.Count) ? list[i + t] : 1;
                    s += "b(" + string.Join(",", mod) + ")";
                }
            }
            return s;
        }
    }
}