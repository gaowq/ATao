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
            while (CarFactory.cars.Where(q => q.end.x != q.now.x || q.end.y != q.now.y || q.realEnd != null).Count() > 0)
            {
                foreach (var car in CarFactory.cars)
                {
                    if (car.taoStack.Count > 0)
                    {
                        car.age = 0;//有路径就清空路径

                        //当前步骤解锁

                        var map = MapFactory.FindByVector(car.now);
                        map.dynamicType = 0;

                        //解冻
                        if (car.taoStack.Count() > 0)
                        {
                            var newmap2 = MapFactory.FindByVector(car.taoStack[0]);
                            if (newmap2.dynamicType == 2) newmap2.dynamicType = 0;
                        }

                        //前进
                        car.now = car.taoStack[0];
                        car.taoStack.RemoveAt(0);

                        //设置未来步骤为障碍物。
                        var newmap = MapFactory.FindByVector(car.now);
                        newmap.dynamicType = 1;

                        //优化，路径有障碍才重新计算
                        foreach(var stack in car.taoStack)
                        {
                            var stackMap = MapFactory.FindByVector(stack);

                            if(stackMap.type != 0 || stackMap.dynamicType!=0)
                            {
                                //更新路径
                                car.GenerateTao();
                                break;
                            }
                        }

                        //冻结路径
                        if (car.taoStack.Count() > 0)
                        {
                            var newmap2 = MapFactory.FindByVector(car.taoStack[0]);
                            newmap2.dynamicType = 2;
                            Console.WriteLine("冻结：" + car.carId + "#" + newmap2.vector.x + "" + newmap2.vector.y);
                        }
                    }
                    else
                    {
                        car.age++;

                        //长时间锁死，暂时改变移动目标。
                        if (car.age % 5 == 4)
                        {
                            var nearMap = MapFactory.GetNearByVector(car.now,true).FirstOrDefault();

                            if(nearMap!=null)
                            {
                                car.realEnd = car.end;
                                car.end = nearMap.vector;
                            }
                        }

                        car.GenerateTao();

                    }
                }
                View.DisplayView();

                Thread.Sleep(1000);
            }
        }
    }
}