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
                    if (car.taoStack.Count > 0)
                    {
                        //当前步骤解锁
                        var map = MapFactory.map.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y).FirstOrDefault();
                        map.dynamicType = 0;

                        //解冻
                        if (car.taoStack.Count() > 0)
                        {
                            var newmap2 = MapFactory.map.Where(q => q.vector.x == car.taoStack[0].x && q.vector.y == car.taoStack[0].y).FirstOrDefault();
                            if(newmap2.dynamicType==2)newmap2.dynamicType = 0;
                        }

                        //前进
                        car.now = car.taoStack[0];
                        car.taoStack.RemoveAt(0);

                        //设置未来步骤为障碍物。
                        var newmap = MapFactory.map.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y).FirstOrDefault();
                        newmap.dynamicType = 1;

                        

                        //更新路径
                        car.GenerateTao();

                        //冻结路径
                        //todo 已经被冻结
                        if (car.taoStack.Count() > 0)
                        {
                            var newmap2 = MapFactory.map.Where(q => q.vector.x == car.taoStack[0].x && q.vector.y == car.taoStack[0].y).FirstOrDefault();
                            newmap2.dynamicType = 2;
                            Console.WriteLine("冻结："+car.carId+"#"+newmap2.vector.x+""+newmap2.vector.y);
                        }
                    }
                    else
                    {
                        car.GenerateTao();
                    }
                }
                View.DisplayView();

                Thread.Sleep(1000);
            }
        }
    }
}