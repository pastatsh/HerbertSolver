using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HerbertSolver2
{
    class Stage
    {

        char[,] cellData;
        bool[,] isGot;
        int startX, startY, pointCount;
        int x, y, point, t, step;

        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { -1, 0, 1, 0 };

        public static int MaxStep { get; set; }
        public static int GrayStepLimit { get; set; }

        public char[,] CellData { get { return cellData; } }
        public int StartX { get { return startX; } }
        public int StartY { get { return startY; } }

        private Stage()
        {
            cellData = new char[25, 25];
            pointCount = 0;
        }

        public static Stage Create(int id)
        {
            byte[] postData = Encoding.ASCII.GetBytes("action=problem");
            WebRequest req = WebRequest.Create("http://herbert.tealang.info/problem.php?id=" + id);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postData.Length;

            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();
            Stream resStream = req.GetResponse().GetResponseStream();

            StreamReader sr = new StreamReader(resStream, Encoding.ASCII);
            string tmp = sr.ReadToEnd();
            sr.Close();
            return Create(tmp);
        }

        public static Stage Create(string data)
        {
            Stage stage = new Stage();
            for (int j = 0; j < 25; j++)
                for (int i = 0; i < 25; i++)
                {
                    char c = data[i + j * 25];
                    stage.cellData[i, j] = c;
                    if (c == 'o')
                        stage.pointCount++;
                    else if (c == 'u')
                    {
                        stage.startX = i;
                        stage.startY = j;
                    }
                }
            return stage;
        }

        public void Init()
        {
            x = startX; y = startY; point = t = step = 0;
            isGot = new bool[25, 25];
        }

        public ActionResult Step(char c)
        {
            step++;
            if (c == 's')
            {
                int nx = x + dx[t];
                int ny = y + dy[t];
                if (nx >= 0 && nx < 25 && ny >= 0 && ny < 25 && cellData[nx, ny] != 'x')
                {
                    x = nx;
                    y = ny;

                    if (cellData[x, y] == 'o' && !isGot[x, y])
                    {
                        isGot[x, y] = true;
                        point++;
                        if (point == pointCount)
                            return ActionResult.Clear;
                    }
                    else if (cellData[x, y] == '*')
                    {
                        isGot = new bool[25, 25];
                        point = 0;
                        if (step >= GrayStepLimit)
                            return ActionResult.GrayLimitOver;
                    }
                }
            }
            else if (c == 'r')
                t = (t + 1) % 4;
            else
                t = (t + 3) % 4;

            if (step >= MaxStep)
                return ActionResult.LimitOver;
            return ActionResult.Done;
        }
    }

    enum ActionResult
    {
        /// <summary>
        /// クリア
        /// </summary>
        Clear,
        /// <summary>
        /// ステップ数オーバー
        /// </summary>
        LimitOver,
        /// <summary>
        /// 灰色マスステップ数オーバー
        /// </summary>
        GrayLimitOver,
        /// <summary>
        /// 何事も無く
        /// </summary>
        Done
    }
}