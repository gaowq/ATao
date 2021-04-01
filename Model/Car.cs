using System;
using System.Collections.Generic;
using System.Linq;
using ATao.DataInit;
using ATao.Util;

namespace ATao.Model
{
    public class Car
    {
        public int carId;
        //0，未开始；1，进行中，2到达;
        public int status;

        //0,无路，1有路，2互卡
        //public int hasTao;

        public int age;

        public Vector2 realEnd;

        public Vector2 start;
        public Vector2 now;
        public Vector2 end;

        public Dictionary<string, Tao> open;
        public Dictionary<string, Tao> close;

        public static int autoCarId = 0;
        public Car(int x1, int y1, int x2, int y2)
        {
            this.carId = ++autoCarId;
            this.status = 0;
            this.age = 0;
            this.start = new Vector2();
            this.now = new Vector2();
            this.end = new Vector2();
            this.start.x = x1;
            this.start.y = y1;
            this.now.x = x1;
            this.now.y = y1;
            this.end.x = x2;
            this.end.y = y2;
            this.taoStack = new List<Vector2>();

            //锁定自己所在的点位
            var mapf1 = MapFactory.FindByVector(this.now);
            mapf1.dynamicType = 1;
        }

        //路径
        public List<Vector2> taoStack;

        public void GenerateTao()
        {
            this.open = new Dictionary<string, Tao>();
            this.close = new Dictionary<string, Tao>();
            this.taoStack = new List<Vector2>();

            Tao start = new Tao(this.now.x, this.now.y);
            start.Refresh(this.end);
            open.Add(CommonUtil.CombineKeyByVector2(start.vector2), start);

            while (open.Count > 0)
            {
                var nowDic = open.OrderBy(q => q.Value.f).FirstOrDefault();
                var now = nowDic.Value;
                open.Remove(nowDic.Key);
                close.Add(nowDic.Key, nowDic.Value);

                if (now.vector2.x == end.x && now.vector2.y == end.y)
                {
                    //找到路径
                    taoStack = new List<Vector2>();

                    while (now.previous != null)
                    {
                        taoStack.Add(now.vector2);
                        now = now.previous;
                    }

                    taoStack.Reverse();

                    Console.Write("car:" + this.carId + "#");

                    foreach (var item in taoStack)
                    {
                        Console.Write(item.x + "" + item.y + "->");
                    }
                    Console.WriteLine();


                    if (this.realEnd != null)
                    {
                        this.end = realEnd;
                        this.realEnd = null;
                    }
                    break;
                }

                List<Tao> nextList = now.getNextList();

                foreach (var next in nextList)
                {
                    string nextKey = CommonUtil.CombineKeyByVector2(next.vector2);

                    if (close.ContainsKey(nextKey)) continue;

                    if (open.ContainsKey(nextKey))
                    {
                        var openSame = open[nextKey];
                        next.Refresh(end);

                        if (openSame.g > next.g)
                        {
                            openSame.previous = now;
                            openSame.Refresh(end);
                        }
                    }
                    else
                    {
                        next.previous = now;
                        next.Refresh(end);
                        open.Add(nextKey, next);
                    }
                }
            }
        }

    }
}