using System;
using System.Collections.Generic;
using System.Linq;

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

        public Vector2 start = new Vector2();
        public Vector2 now = new Vector2();
        public Vector2 end = new Vector2();

        public List<Tao> open;
        public List<Tao> close;

        public Car(int carId, int x1, int y1, int x2, int y2)
        {
            this.carId = carId;
            this.status = 0;
            //this.hasTao = 0;
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
            this.open = new List<Tao>();
            this.close = new List<Tao>();
            this.taoStack = new List<Vector2>();

            GenerateTao();
        }

        //路径
        public List<Vector2> taoStack;

        public void GenerateTao()
        {
            //this.hasTao = 0;
            this.open = new List<Tao>();
            this.close = new List<Tao>();
            this.taoStack = new List<Vector2>();

            Tao start = new Tao(this.now.x, this.now.y);
            start.Refresh(this.end);
            open.Add(start);

            while (open.Count > 0)
            {
                var now = open.OrderBy(q => q.f).FirstOrDefault();
                open.Remove(now);
                close.Add(now);

                if (now.vector2.x == end.x && now.vector2.y == end.y)
                {
                    //Console.WriteLine("找到路径");
                    //this.hasTao = 1;

                    taoStack = new List<Vector2>();

                    while (now.previous != null)
                    {
                        taoStack.Add(now.vector2);
                        now = now.previous;
                    }

                    taoStack.Reverse();
                    //Console.WriteLine(taoStack.Count());

                    Console.Write("car:" + this.carId + "#");

                    foreach (var item in taoStack)
                    {
                        Console.Write(item.x +""+ item.y + "->");
                    }
                    Console.WriteLine();


                    if(this.realEnd!=null)
                    {
                        this.end = realEnd;
                        this.realEnd = null;
                    }
                    break;
                }

                List<Tao> nextList = now.getNextList();

                foreach (var next in nextList)
                {
                    if (close.Where(q => q.vector2.x == next.vector2.x && q.vector2.y == next.vector2.y).Count() > 0) continue;

                    if (open.Where(q => q.vector2.x == next.vector2.x && q.vector2.y == next.vector2.y).Count() > 0)
                    {
                        var openSame = open.Where(q => q.vector2.x == next.vector2.x && q.vector2.y == next.vector2.y).FirstOrDefault();
                        //int nextG = g(next);
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
                        open.Add(next);
                    }
                }
            }
        }

    }
}