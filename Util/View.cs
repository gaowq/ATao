using System;
using System.Linq;
using ATao.DataInit;

namespace ATao.Util
{
    public class View
    {

        //刷新页面显示
        public static void DisplayView()
        {
            for (var y = 1; y <= MapFactory.yl; y++)
            {
                for (var x = 1; x <= MapFactory.xl; x++)
                {
                    var map = MapFactory.map.Where(q => q.vector.x == x && q.vector.y == y).FirstOrDefault();

                    if (map != null)
                    {
                        var cars = CarFactory.cars.Where(q => q.now.x == x && q.now.y == y);
                        if (cars.Count() == 1)
                        {
                            Console.Write("+");

                        }
                        else
                        {
                            switch (map.type)
                            {
                                case 0:
                                    Console.Write(".");
                                    break;
                                case 1:
                                    Console.Write("*");
                                    break;
                            }
                        }
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}