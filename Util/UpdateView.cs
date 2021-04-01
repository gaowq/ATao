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

                        var map = MapFactory.FindByVector(car.now);//.map.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y).FirstOrDefault();
                        map.dynamicType = 0;

                        //解冻
                        if (car.taoStack.Count() > 0)
                        {
                            var newmap2 = MapFactory.FindByVector(car.taoStack[0]);//.map.Where(q => q.vector.x == car.taoStack[0].x && q.vector.y == car.taoStack[0].y).FirstOrDefault();
                            if (newmap2.dynamicType == 2) newmap2.dynamicType = 0;
                        }

                        //前进
                        car.now = car.taoStack[0];
                        car.taoStack.RemoveAt(0);

                        //设置未来步骤为障碍物。
                        var newmap = MapFactory.FindByVector(car.now);//.map.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y).FirstOrDefault();
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
                            var newmap2 = MapFactory.FindByVector(car.taoStack[0]);//.map.Where(q => q.vector.x == car.taoStack[0].x && q.vector.y == car.taoStack[0].y).FirstOrDefault();
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
                            //var mapList = MapFactory.map.Where(q => q.dynamicType == 0 && q.type == 0).ToList();

                            var eastMap = MapFactory.FindByVector(car.now.x + 1, car.now.y);//mapList.Where(q => q.vector.x == car.now.x + 1 && q.vector.y == car.now.y).FirstOrDefault();
                            var westMap = MapFactory.FindByVector(car.now.x - 1, car.now.y);//mapList.Where(q => q.vector.x == car.now.x - 1 && q.vector.y == car.now.y).FirstOrDefault();
                            var northMap = MapFactory.FindByVector(car.now.x, car.now.y + 1);//mapList.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y + 1).FirstOrDefault();
                            var southMap = MapFactory.FindByVector(car.now.x, car.now.y - 1);//mapList.Where(q => q.vector.x == car.now.x && q.vector.y == car.now.y - 1).FirstOrDefault();

                            if (eastMap != null && eastMap.type==0 && eastMap.dynamicType==0)
                            {
                                car.realEnd = car.end;
                                car.end = eastMap.vector;
                            }
                            else if (westMap != null && westMap.type==0 && westMap.dynamicType==0)
                            {
                                car.realEnd = car.end;
                                car.end = westMap.vector;
                            }
                            else if (northMap != null && northMap.type==0 && northMap.dynamicType==0)
                            {
                                car.realEnd = car.end;
                                car.end = northMap.vector;
                            }
                            else if (southMap != null && southMap.type==0 && southMap.dynamicType==0)
                            {
                                car.realEnd = car.end;
                                car.end = southMap.vector;
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