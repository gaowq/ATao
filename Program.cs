using System;
using System.Collections.Generic;
using System.Linq;
using ATao.Model;
using ATao.Test;

namespace ATao
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Tao(1, 1);
            var end = new Tao(3, 19);
            Block.createBlock();


            var openList = new List<Tao>();
            var closeList = new List<Tao>();

            start.Refresh(end);
            openList.Add(start);

            while (openList.Count > 0)
            {
                var now = openList.OrderBy(q => q.f).FirstOrDefault();
                openList.Remove(now);
                closeList.Add(now);

                if (now.x == end.x && now.y == end.y)
                {
                    Console.WriteLine("找到路径");

                    List<Point> pointList = new List<Point>();

                    while (now.previous != null)
                    {
                        Point point = new Point(now.x, now.y);
                        pointList.Add(point);
                        //Console.Write(String.Format("x:{0},y:{1} <- ", now.x, now.y));
                        now = now.previous;
                    }

                    for (int y = 1; y < 20; y++)
                    {
                        for (int x = 1; x < 20; x++)
                        {
                            if (pointList.Where(q => q.x == x && q.y == y).Count() > 0)
                                Console.Write("*");
                            else if (Block.blockList.Where(q => q.x == x && q.y == y).Count() > 0)
                                Console.Write("-");
                            else
                                Console.Write(".");
                        }
                        Console.WriteLine("");
                    }

                    break;
                }

                List<Tao> nextList = now.getNextList();

                foreach (var next in nextList)
                {
                    if (closeList.Where(q => q.x == next.x && q.y == next.y).Count() > 0) continue;

                    if (openList.Where(q => q.x == next.x && q.y == next.y).Count() > 0)
                    {
                        var openSame = openList.Where(q => q.x == next.x && q.y == next.y).FirstOrDefault();
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
                        openList.Add(next);
                    }
                }
            }

            //Console.WriteLine("Hello World!" + start.x);
        }
    }
}
