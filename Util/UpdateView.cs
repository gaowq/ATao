using System;
using System.Linq;
using System.Threading;
using ATao.DataInit;

namespace ATao.Util
{
    public class UpdateView
    {
        public static void UpdateMain()
        {
            while (CarFactory.cars.Where(q => q.end.x != q.now.x || q.end.y != q.now.y).Count() > 0)
            {
                foreach (var car in CarFactory.cars)
                {
                    //car.GenerateTao();

                    if (car.taoStack.Count > 0)
                    {
                        Console.WriteLine(car.carId+"hasTao"+car.hasTao);
                        var map = MapFactory.map.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y).FirstOrDefault();
                        map.dynamicType = 0;

                        //car.GenerateTao();

                        //var map = MapFactory.map.Where(q=>q.vector.x == car.now.x && q.vector.y==car.now.y).FirstOrDefault();
                        //前进
                        // if (car.taoStack.Count() > 1)
                        // {

                        //     var map2 = MapFactory.map.Where(q => q.vector.x == car.taoStack[1].x && q.vector.y == car.taoStack[1].y).FirstOrDefault();
                        //     if (map2.dynamicType != 0)//下个节点有车或者
                        //     {
                        //         Console.WriteLine("遇到阻碍" + car.carId);
                        //         //car.GenerateTao();
                        //         continue;
                        //     }
                        // }

                        car.now = car.taoStack[0];
                        car.taoStack.RemoveAt(0);

                        

                        var newmap = MapFactory.map.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y).FirstOrDefault();
                        newmap.dynamicType = 1;

                        car.GenerateTao();

                        // car.nowMap = newmap;

                        // if (car.preMap != null)
                        // {
                        //     car.preMap.dynamicType = 1;
                        //     car.nowMap = car.preMap;
                        // }

                        // if (car.taoStack.Count() > 0)
                        // {
                        //     car.preMap = MapFactory.map.Where(q => q.vector.x == car.taoStack[0].x && q.vector.y == car.taoStack[0].y).FirstOrDefault();
                        //     if (car.preMap != null)
                        //     {
                        //         car.preMap.dynamicType = 2;
                        //     }
                        // }

                        //car.GenerateTao();
                    }else{
                        car.GenerateTao();
                    }
                }
                View.DisplayView();

                Thread.Sleep(1000);
            }
        }
    }
}