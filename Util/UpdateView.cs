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
                        car.now = car.taoStack[0];
                        car.taoStack.RemoveAt(0);
                    }
                }
                View.DisplayView();

                Thread.Sleep(1000);
            }
        }
    }
}