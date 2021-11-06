using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerbertSolver2
{
    partial class SolverM : Solver
    {
        class Generator : List<int>
        {
            public string Func;

            public Generator(string func)
                : base()
            {
                Func = func;
            }

            public new void Add(int num)
            {
                if (num <= 0 || num > 255)
                    throw new Exception("NLE");
                base.Add(num);
            }
        }

        Generator s4()
        {
            Generator gen = new Generator("f(X,Y,Z):Zf(X-Y,Y,r)\r\na(X):f(X,64,)sf(X,16,)sf(X,4,)sf(X,1,)s");
            int k = 0, t = 0;
            foreach (char c in code)
            {
                if (c == 'r')
                    t++;
                else
                {
                    k++;
                    if (k == 4)
                    {
                        gen.Add(t + 1);
                        k = 0;
                        t = 0;
                        continue;
                    }
                    t *= 4;
                }
            }
            if (t != 0)
            {
                for (k++; k < 4; k++)
                    t *= 4;
                gen.Add(t + 1);
            }
            return gen;
        }

        Generator s4_2()
        {
            Generator gen = new Generator("f(X,Y):rf(X-Y,Y)\r\na(X):f(X,64)sf(X,16)sf(X,4)sf(X,1)s");
            int k = 0, t = 0, n = 3;
            foreach (char c in code)
            {
                if (c == 'r')
                    n++;
                else
                {
                    k++;
                    if (k == 4)
                    {
                        gen.Add(t + 1 + n % 4);
                        k = 0;
                        t = 0;
                        n = 3;
                        continue;
                    }
                    t = (t + n % 4) * 4;
                    n = 3;
                }
            }
            if (t != 0)
            {
                t += n % 4;
                for (k++; k < 4; k++)
                    t *= 4;
                gen.Add(t + 1);
            }
            return gen;
        }

        Generator sr()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("rrrrrrrs", 1);
            dic.Add("rrrrrrsr", 2);
            dic.Add("rrrrrrss", 3);
            dic.Add("rrrrrsrr", 4);
            dic.Add("rrrrrsrs", 5);
            dic.Add("rrrrrssr", 6);
            dic.Add("rrrrrsss", 7);
            dic.Add("rrrrsrrr", 8);
            dic.Add("rrrrsrrs", 9);
            dic.Add("rrrrsrsr", 10);
            dic.Add("rrrrsrss", 11);
            dic.Add("rrrrssrr", 12);
            dic.Add("rrrrssrs", 13);
            dic.Add("rrrrsssr", 14);
            dic.Add("rrrrssss", 15);
            dic.Add("rrrsrrrr", 16);
            dic.Add("rrrsrrrs", 17);
            dic.Add("rrrsrrsr", 18);
            dic.Add("rrrsrrss", 19);
            dic.Add("rrrsrsrr", 20);
            dic.Add("rrrsrsrs", 21);
            dic.Add("rrrsrssr", 22);
            dic.Add("rrrsrsss", 23);
            dic.Add("rrrssrrr", 24);
            dic.Add("rrrssrrs", 25);
            dic.Add("rrrssrsr", 26);
            dic.Add("rrrssrss", 27);
            dic.Add("rrrsssrr", 28);
            dic.Add("rrrsssrs", 29);
            dic.Add("rrrssssr", 30);
            dic.Add("rrrsssss", 31);
            dic.Add("rrsrrrrr", 32);
            dic.Add("rrsrrrrs", 33);
            dic.Add("rrsrrrsr", 34);
            dic.Add("rrsrrrss", 35);
            dic.Add("rrsrrsrr", 36);
            dic.Add("rrsrrsrs", 37);
            dic.Add("rrsrrssr", 38);
            dic.Add("rrsrrsss", 39);
            dic.Add("rrsrsrrr", 40);
            dic.Add("rrsrsrrs", 41);
            dic.Add("rrsrsrsr", 42);
            dic.Add("rrsrsrss", 43);
            dic.Add("rrsrssrr", 44);
            dic.Add("rrsrssrs", 45);
            dic.Add("rrsrsssr", 46);
            dic.Add("rrsrssss", 47);
            dic.Add("rrssrrrr", 48);
            dic.Add("rrssrrrs", 49);
            dic.Add("rrssrrsr", 50);
            dic.Add("rrssrrss", 51);
            dic.Add("rrssrsrr", 52);
            dic.Add("rrssrsrs", 53);
            dic.Add("rrssrssr", 54);
            dic.Add("rrssrsss", 55);
            dic.Add("rrsssrrr", 56);
            dic.Add("rrsssrrs", 57);
            dic.Add("rrsssrsr", 58);
            dic.Add("rrsssrss", 59);
            dic.Add("rrssssrr", 60);
            dic.Add("rrssssrs", 61);
            dic.Add("rrsssssr", 62);
            dic.Add("rrssssss", 63);
            dic.Add("rsrrrrrr", 64);
            dic.Add("rsrrrrrs", 65);
            dic.Add("rsrrrrsr", 66);
            dic.Add("rsrrrrss", 67);
            dic.Add("rsrrrsrr", 68);
            dic.Add("rsrrrsrs", 69);
            dic.Add("rsrrrssr", 70);
            dic.Add("rsrrrsss", 71);
            dic.Add("rsrrsrrr", 72);
            dic.Add("rsrrsrrs", 73);
            dic.Add("rsrrsrsr", 74);
            dic.Add("rsrrsrss", 75);
            dic.Add("rsrrssrr", 76);
            dic.Add("rsrrssrs", 77);
            dic.Add("rsrrsssr", 78);
            dic.Add("rsrrssss", 79);
            dic.Add("rsrsrrrr", 80);
            dic.Add("rsrsrrrs", 81);
            dic.Add("rsrsrrsr", 82);
            dic.Add("rsrsrrss", 83);
            dic.Add("rsrsrsrr", 84);
            dic.Add("rsrsrsrs", 85);
            dic.Add("rsrsrssr", 86);
            dic.Add("rsrsrsss", 87);
            dic.Add("rsrssrrr", 88);
            dic.Add("rsrssrrs", 89);
            dic.Add("rsrssrsr", 90);
            dic.Add("rsrssrss", 91);
            dic.Add("rsrsssrr", 92);
            dic.Add("rsrsssrs", 93);
            dic.Add("rsrssssr", 94);
            dic.Add("rsrsssss", 95);
            dic.Add("rssrrrrr", 96);
            dic.Add("rssrrrrs", 97);
            dic.Add("rssrrrsr", 98);
            dic.Add("rssrrrss", 99);
            dic.Add("rssrrsrr", 100);
            dic.Add("rssrrsrs", 101);
            dic.Add("rssrrssr", 102);
            dic.Add("rssrrsss", 103);
            dic.Add("rssrsrrr", 104);
            dic.Add("rssrsrrs", 105);
            dic.Add("rssrsrsr", 106);
            dic.Add("rssrsrss", 107);
            dic.Add("rssrssrr", 108);
            dic.Add("rssrssrs", 109);
            dic.Add("rssrsssr", 110);
            dic.Add("rssrssss", 111);
            dic.Add("rsssrrrr", 112);
            dic.Add("rsssrrrs", 113);
            dic.Add("rsssrrsr", 114);
            dic.Add("rsssrrss", 115);
            dic.Add("rsssrsrr", 116);
            dic.Add("rsssrsrs", 117);
            dic.Add("rsssrssr", 118);
            dic.Add("rsssrsss", 119);
            dic.Add("rssssrrr", 120);
            dic.Add("rssssrrs", 121);
            dic.Add("rssssrsr", 122);
            dic.Add("rssssrss", 123);
            dic.Add("rsssssrr", 124);
            dic.Add("rsssssrs", 125);
            dic.Add("rssssssr", 126);
            dic.Add("rsssssss", 127);
            dic.Add("srrrrrrs", 128);
            dic.Add("srrrrrsr", 129);
            dic.Add("srrrrrss", 130);
            dic.Add("srrrrsrr", 131);
            dic.Add("srrrrsrs", 132);
            dic.Add("srrrrssr", 133);
            dic.Add("srrrrsss", 134);
            dic.Add("srrrsrrr", 135);
            dic.Add("srrrsrrs", 136);
            dic.Add("srrrsrsr", 137);
            dic.Add("srrrsrss", 138);
            dic.Add("srrrssrr", 139);
            dic.Add("srrrssrs", 140);
            dic.Add("srrrsssr", 141);
            dic.Add("srrrssss", 142);
            dic.Add("srrsrrrr", 143);
            dic.Add("srrsrrrs", 144);
            dic.Add("srrsrrsr", 145);
            dic.Add("srrsrrss", 146);
            dic.Add("srrsrsrr", 147);
            dic.Add("srrsrsrs", 148);
            dic.Add("srrsrssr", 149);
            dic.Add("srrsrsss", 150);
            dic.Add("srrssrrr", 151);
            dic.Add("srrssrrs", 152);
            dic.Add("srrssrsr", 153);
            dic.Add("srrssrss", 154);
            dic.Add("srrsssrr", 155);
            dic.Add("srrsssrs", 156);
            dic.Add("srrssssr", 157);
            dic.Add("srrsssss", 158);
            dic.Add("srsrrrrr", 159);
            dic.Add("srsrrrrs", 160);
            dic.Add("srsrrrsr", 161);
            dic.Add("srsrrrss", 162);
            dic.Add("srsrrsrr", 163);
            dic.Add("srsrrsrs", 164);
            dic.Add("srsrrssr", 165);
            dic.Add("srsrrsss", 166);
            dic.Add("srsrsrrr", 167);
            dic.Add("srsrsrrs", 168);
            dic.Add("srsrsrsr", 169);
            dic.Add("srsrsrss", 170);
            dic.Add("srsrssrr", 171);
            dic.Add("srsrssrs", 172);
            dic.Add("srsrsssr", 173);
            dic.Add("srsrssss", 174);
            dic.Add("srssrrrr", 175);
            dic.Add("srssrrrs", 176);
            dic.Add("srssrrsr", 177);
            dic.Add("srssrrss", 178);
            dic.Add("srssrsrr", 179);
            dic.Add("srssrsrs", 180);
            dic.Add("srssrssr", 181);
            dic.Add("srssrsss", 182);
            dic.Add("srsssrrr", 183);
            dic.Add("srsssrrs", 184);
            dic.Add("srsssrsr", 185);
            dic.Add("srsssrss", 186);
            dic.Add("srssssrr", 187);
            dic.Add("srssssrs", 188);
            dic.Add("srsssssr", 189);
            dic.Add("srssssss", 190);
            dic.Add("ssrrrrrr", 191);
            dic.Add("ssrrrrrs", 192);
            dic.Add("ssrrrrsr", 193);
            dic.Add("ssrrrrss", 194);
            dic.Add("ssrrrsrr", 195);
            dic.Add("ssrrrsrs", 196);
            dic.Add("ssrrrssr", 197);
            dic.Add("ssrrrsss", 198);
            dic.Add("ssrrsrrr", 199);
            dic.Add("ssrrsrrs", 200);
            dic.Add("ssrrsrsr", 201);
            dic.Add("ssrrsrss", 202);
            dic.Add("ssrrssrr", 203);
            dic.Add("ssrrssrs", 204);
            dic.Add("ssrrsssr", 205);
            dic.Add("ssrrssss", 206);
            dic.Add("ssrsrrrr", 207);
            dic.Add("ssrsrrrs", 208);
            dic.Add("ssrsrrsr", 209);
            dic.Add("ssrsrrss", 210);
            dic.Add("ssrsrsrr", 211);
            dic.Add("ssrsrsrs", 212);
            dic.Add("ssrsrssr", 213);
            dic.Add("ssrsrsss", 214);
            dic.Add("ssrssrrr", 215);
            dic.Add("ssrssrrs", 216);
            dic.Add("ssrssrsr", 217);
            dic.Add("ssrssrss", 218);
            dic.Add("ssrsssrr", 219);
            dic.Add("ssrsssrs", 220);
            dic.Add("ssrssssr", 221);
            dic.Add("ssrsssss", 222);
            dic.Add("sssrrrrr", 223);
            dic.Add("sssrrrrs", 224);
            dic.Add("sssrrrsr", 225);
            dic.Add("sssrrrss", 226);
            dic.Add("sssrrsrr", 227);
            dic.Add("sssrrsrs", 228);
            dic.Add("sssrrssr", 229);
            dic.Add("sssrrsss", 230);
            dic.Add("sssrsrrr", 231);
            dic.Add("sssrsrrs", 232);
            dic.Add("sssrsrsr", 233);
            dic.Add("sssrsrss", 234);
            dic.Add("sssrssrr", 235);
            dic.Add("sssrssrs", 236);
            dic.Add("sssrsssr", 237);
            dic.Add("sssrssss", 238);
            dic.Add("ssssrrrr", 239);
            dic.Add("ssssrrrs", 240);
            dic.Add("ssssrrsr", 241);
            dic.Add("ssssrrss", 242);
            dic.Add("ssssrsrr", 243);
            dic.Add("ssssrsrs", 244);
            dic.Add("ssssrssr", 245);
            dic.Add("ssssrsss", 246);
            dic.Add("sssssrrr", 247);
            dic.Add("sssssrrs", 248);
            dic.Add("sssssrsr", 249);
            dic.Add("sssssrss", 250);
            dic.Add("ssssssrr", 251);
            dic.Add("ssssssrs", 252);
            dic.Add("sssssssr", 253);
            dic.Add("ssssssss", 254);

            Generator gen = new Generator("f(X,Y):Y\r\ng(X,Y,Z):g(X-127,Y,s)f(128-X,Zg(X+X,Y-1,r))\r\na(X):g(X,8,r)");
            string code = this.code;
            for (int i = (code.Length + 7) % 8; i < 7; i++)
                code += "s";
            for (int i = 0; i < code.Length; i += 8)
                gen.Add(dic[code.Substring(i,8)]);
            return gen;
        }

        Generator ssrsl()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("sssss", 1);
            dic.Add("ssssrs", 2);
            dic.Add("ssssrrrs", 3);
            dic.Add("sssrss", 4);
            dic.Add("sssrsrs", 5);
            dic.Add("sssrsrrrs", 6);
            dic.Add("sssrrrss", 7);
            dic.Add("sssrrrsrs", 8);
            dic.Add("sssrrrsrrrs", 9);
            dic.Add("ssrsss", 10);
            dic.Add("ssrssrs", 11);
            dic.Add("ssrssrrrs", 12);
            dic.Add("ssrsrss", 13);
            dic.Add("ssrsrsrs", 14);
            dic.Add("ssrsrsrrrs", 15);
            dic.Add("ssrsrrrss", 16);
            dic.Add("ssrsrrrsrs", 17);
            dic.Add("ssrsrrrsrrrs", 18);
            dic.Add("ssrrrsss", 19);
            dic.Add("ssrrrssrs", 20);
            dic.Add("ssrrrssrrrs", 21);
            dic.Add("ssrrrsrss", 22);
            dic.Add("ssrrrsrsrs", 23);
            dic.Add("ssrrrsrsrrrs", 24);
            dic.Add("ssrrrsrrrss", 25);
            dic.Add("ssrrrsrrrsrs", 26);
            dic.Add("ssrrrsrrrsrrrs", 27);
            dic.Add("srssss", 28);
            dic.Add("srsssrs", 29);
            dic.Add("srsssrrrs", 30);
            dic.Add("srssrss", 31);
            dic.Add("srssrsrs", 32);
            dic.Add("srssrsrrrs", 33);
            dic.Add("srssrrrss", 34);
            dic.Add("srssrrrsrs", 35);
            dic.Add("srssrrrsrrrs", 36);
            dic.Add("srsrsss", 37);
            dic.Add("srsrssrs", 38);
            dic.Add("srsrssrrrs", 39);
            dic.Add("srsrsrss", 40);
            dic.Add("srsrsrsrs", 41);
            dic.Add("srsrsrsrrrs", 42);
            dic.Add("srsrsrrrss", 43);
            dic.Add("srsrsrrrsrs", 44);
            dic.Add("srsrsrrrsrrrs", 45);
            dic.Add("srsrrrsss", 46);
            dic.Add("srsrrrssrs", 47);
            dic.Add("srsrrrssrrrs", 48);
            dic.Add("srsrrrsrss", 49);
            dic.Add("srsrrrsrsrs", 50);
            dic.Add("srsrrrsrsrrrs", 51);
            dic.Add("srsrrrsrrrss", 52);
            dic.Add("srsrrrsrrrsrs", 53);
            dic.Add("srsrrrsrrrsrrrs", 54);
            dic.Add("srrrssss", 55);
            dic.Add("srrrsssrs", 56);
            dic.Add("srrrsssrrrs", 57);
            dic.Add("srrrssrss", 58);
            dic.Add("srrrssrsrs", 59);
            dic.Add("srrrssrsrrrs", 60);
            dic.Add("srrrssrrrss", 61);
            dic.Add("srrrssrrrsrs", 62);
            dic.Add("srrrssrrrsrrrs", 63);
            dic.Add("srrrsrsss", 64);
            dic.Add("srrrsrssrs", 65);
            dic.Add("srrrsrssrrrs", 66);
            dic.Add("srrrsrsrss", 67);
            dic.Add("srrrsrsrsrs", 68);
            dic.Add("srrrsrsrsrrrs", 69);
            dic.Add("srrrsrsrrrss", 70);
            dic.Add("srrrsrsrrrsrs", 71);
            dic.Add("srrrsrsrrrsrrrs", 72);
            dic.Add("srrrsrrrsss", 73);
            dic.Add("srrrsrrrssrs", 74);
            dic.Add("srrrsrrrssrrrs", 75);
            dic.Add("srrrsrrrsrss", 76);
            dic.Add("srrrsrrrsrsrs", 77);
            dic.Add("srrrsrrrsrsrrrs", 78);
            dic.Add("srrrsrrrsrrrss", 79);
            dic.Add("srrrsrrrsrrrsrs", 80);
            dic.Add("srrrsrrrsrrrsrrrs", 81);
            dic.Add("rsssss", 82);
            dic.Add("rssssrs", 83);
            dic.Add("rssssrrrs", 84);
            dic.Add("rsssrss", 85);
            dic.Add("rsssrsrs", 86);
            dic.Add("rsssrsrrrs", 87);
            dic.Add("rsssrrrss", 88);
            dic.Add("rsssrrrsrs", 89);
            dic.Add("rsssrrrsrrrs", 90);
            dic.Add("rssrsss", 91);
            dic.Add("rssrssrs", 92);
            dic.Add("rssrssrrrs", 93);
            dic.Add("rssrsrss", 94);
            dic.Add("rssrsrsrs", 95);
            dic.Add("rssrsrsrrrs", 96);
            dic.Add("rssrsrrrss", 97);
            dic.Add("rssrsrrrsrs", 98);
            dic.Add("rssrsrrrsrrrs", 99);
            dic.Add("rssrrrsss", 100);
            dic.Add("rssrrrssrs", 101);
            dic.Add("rssrrrssrrrs", 102);
            dic.Add("rssrrrsrss", 103);
            dic.Add("rssrrrsrsrs", 104);
            dic.Add("rssrrrsrsrrrs", 105);
            dic.Add("rssrrrsrrrss", 106);
            dic.Add("rssrrrsrrrsrs", 107);
            dic.Add("rssrrrsrrrsrrrs", 108);
            dic.Add("rsrssss", 109);
            dic.Add("rsrsssrs", 110);
            dic.Add("rsrsssrrrs", 111);
            dic.Add("rsrssrss", 112);
            dic.Add("rsrssrsrs", 113);
            dic.Add("rsrssrsrrrs", 114);
            dic.Add("rsrssrrrss", 115);
            dic.Add("rsrssrrrsrs", 116);
            dic.Add("rsrssrrrsrrrs", 117);
            dic.Add("rsrsrsss", 118);
            dic.Add("rsrsrssrs", 119);
            dic.Add("rsrsrssrrrs", 120);
            dic.Add("rsrsrsrss", 121);
            dic.Add("rsrsrsrsrs", 122);
            dic.Add("rsrsrsrsrrrs", 123);
            dic.Add("rsrsrsrrrss", 124);
            dic.Add("rsrsrsrrrsrs", 125);
            dic.Add("rsrsrsrrrsrrrs", 126);
            dic.Add("rsrsrrrsss", 127);
            dic.Add("rsrsrrrssrs", 128);
            dic.Add("rsrsrrrssrrrs", 129);
            dic.Add("rsrsrrrsrss", 130);
            dic.Add("rsrsrrrsrsrs", 131);
            dic.Add("rsrsrrrsrsrrrs", 132);
            dic.Add("rsrsrrrsrrrss", 133);
            dic.Add("rsrsrrrsrrrsrs", 134);
            dic.Add("rsrsrrrsrrrsrrrs", 135);
            dic.Add("rsrrrssss", 136);
            dic.Add("rsrrrsssrs", 137);
            dic.Add("rsrrrsssrrrs", 138);
            dic.Add("rsrrrssrss", 139);
            dic.Add("rsrrrssrsrs", 140);
            dic.Add("rsrrrssrsrrrs", 141);
            dic.Add("rsrrrssrrrss", 142);
            dic.Add("rsrrrssrrrsrs", 143);
            dic.Add("rsrrrssrrrsrrrs", 144);
            dic.Add("rsrrrsrsss", 145);
            dic.Add("rsrrrsrssrs", 146);
            dic.Add("rsrrrsrssrrrs", 147);
            dic.Add("rsrrrsrsrss", 148);
            dic.Add("rsrrrsrsrsrs", 149);
            dic.Add("rsrrrsrsrsrrrs", 150);
            dic.Add("rsrrrsrsrrrss", 151);
            dic.Add("rsrrrsrsrrrsrs", 152);
            dic.Add("rsrrrsrsrrrsrrrs", 153);
            dic.Add("rsrrrsrrrsss", 154);
            dic.Add("rsrrrsrrrssrs", 155);
            dic.Add("rsrrrsrrrssrrrs", 156);
            dic.Add("rsrrrsrrrsrss", 157);
            dic.Add("rsrrrsrrrsrsrs", 158);
            dic.Add("rsrrrsrrrsrsrrrs", 159);
            dic.Add("rsrrrsrrrsrrrss", 160);
            dic.Add("rsrrrsrrrsrrrsrs", 161);
            dic.Add("rsrrrsrrrsrrrsrrrs", 162);
            dic.Add("rrrsssss", 163);
            dic.Add("rrrssssrs", 164);
            dic.Add("rrrssssrrrs", 165);
            dic.Add("rrrsssrss", 166);
            dic.Add("rrrsssrsrs", 167);
            dic.Add("rrrsssrsrrrs", 168);
            dic.Add("rrrsssrrrss", 169);
            dic.Add("rrrsssrrrsrs", 170);
            dic.Add("rrrsssrrrsrrrs", 171);
            dic.Add("rrrssrsss", 172);
            dic.Add("rrrssrssrs", 173);
            dic.Add("rrrssrssrrrs", 174);
            dic.Add("rrrssrsrss", 175);
            dic.Add("rrrssrsrsrs", 176);
            dic.Add("rrrssrsrsrrrs", 177);
            dic.Add("rrrssrsrrrss", 178);
            dic.Add("rrrssrsrrrsrs", 179);
            dic.Add("rrrssrsrrrsrrrs", 180);
            dic.Add("rrrssrrrsss", 181);
            dic.Add("rrrssrrrssrs", 182);
            dic.Add("rrrssrrrssrrrs", 183);
            dic.Add("rrrssrrrsrss", 184);
            dic.Add("rrrssrrrsrsrs", 185);
            dic.Add("rrrssrrrsrsrrrs", 186);
            dic.Add("rrrssrrrsrrrss", 187);
            dic.Add("rrrssrrrsrrrsrs", 188);
            dic.Add("rrrssrrrsrrrsrrrs", 189);
            dic.Add("rrrsrssss", 190);
            dic.Add("rrrsrsssrs", 191);
            dic.Add("rrrsrsssrrrs", 192);
            dic.Add("rrrsrssrss", 193);
            dic.Add("rrrsrssrsrs", 194);
            dic.Add("rrrsrssrsrrrs", 195);
            dic.Add("rrrsrssrrrss", 196);
            dic.Add("rrrsrssrrrsrs", 197);
            dic.Add("rrrsrssrrrsrrrs", 198);
            dic.Add("rrrsrsrsss", 199);
            dic.Add("rrrsrsrssrs", 200);
            dic.Add("rrrsrsrssrrrs", 201);
            dic.Add("rrrsrsrsrss", 202);
            dic.Add("rrrsrsrsrsrs", 203);
            dic.Add("rrrsrsrsrsrrrs", 204);
            dic.Add("rrrsrsrsrrrss", 205);
            dic.Add("rrrsrsrsrrrsrs", 206);
            dic.Add("rrrsrsrsrrrsrrrs", 207);
            dic.Add("rrrsrsrrrsss", 208);
            dic.Add("rrrsrsrrrssrs", 209);
            dic.Add("rrrsrsrrrssrrrs", 210);
            dic.Add("rrrsrsrrrsrss", 211);
            dic.Add("rrrsrsrrrsrsrs", 212);
            dic.Add("rrrsrsrrrsrsrrrs", 213);
            dic.Add("rrrsrsrrrsrrrss", 214);
            dic.Add("rrrsrsrrrsrrrsrs", 215);
            dic.Add("rrrsrsrrrsrrrsrrrs", 216);
            dic.Add("rrrsrrrssss", 217);
            dic.Add("rrrsrrrsssrs", 218);
            dic.Add("rrrsrrrsssrrrs", 219);
            dic.Add("rrrsrrrssrss", 220);
            dic.Add("rrrsrrrssrsrs", 221);
            dic.Add("rrrsrrrssrsrrrs", 222);
            dic.Add("rrrsrrrssrrrss", 223);
            dic.Add("rrrsrrrssrrrsrs", 224);
            dic.Add("rrrsrrrssrrrsrrrs", 225);
            dic.Add("rrrsrrrsrsss", 226);
            dic.Add("rrrsrrrsrssrs", 227);
            dic.Add("rrrsrrrsrssrrrs", 228);
            dic.Add("rrrsrrrsrsrss", 229);
            dic.Add("rrrsrrrsrsrsrs", 230);
            dic.Add("rrrsrrrsrsrsrrrs", 231);
            dic.Add("rrrsrrrsrsrrrss", 232);
            dic.Add("rrrsrrrsrsrrrsrs", 233);
            dic.Add("rrrsrrrsrsrrrsrrrs", 234);
            dic.Add("rrrsrrrsrrrsss", 235);
            dic.Add("rrrsrrrsrrrssrs", 236);
            dic.Add("rrrsrrrsrrrssrrrs", 237);
            dic.Add("rrrsrrrsrrrsrss", 238);
            dic.Add("rrrsrrrsrrrsrsrs", 239);
            dic.Add("rrrsrrrsrrrsrsrrrs", 240);
            dic.Add("rrrsrrrsrrrsrrrss", 241);
            dic.Add("rrrsrrrsrrrsrrrsrs", 242);
            dic.Add("rrrsrrrsrrrsrrrsrrrs", 243);

            Generator gen = new Generator("f(X,Y):Y\r\ng(X,Y,Z):g(X-81,Y,ZZr)f(82-X,Zsg(X+X+X,Y-1,))\r\na(X):g(X,5,)");
            string code = this.code;
            int sc=0;
            string tmp="";
            foreach (char c in code)
            {
                tmp += c;
                if (c == 's')
                {
                    sc++;
                    if (sc == 5)
                    {
                        gen.Add(dic[tmp]);
                        sc = 0;
                        tmp = "";
                    }
                }
            }
            if (sc != 0)
            {
                for (; sc < 5; sc++)
                    tmp += "s";
                gen.Add(dic[tmp]);
            }
            return gen;
        }
    }
}
