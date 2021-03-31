using System.Collections.Generic;
using System.Linq;
using ATao.Model;

namespace ATao.DataInit
{
    public class CarFactory
    {
        public static List<Car> cars;
        public static void InitCar()
        {
            var mapf1 = MapFactory.map.Where(q => q.vector.x == 1 && q.vector.y == 1).FirstOrDefault();

            if (mapf1 != null)
            {
                mapf1.dynamicType = 1;
            }

            var mapf2 = MapFactory.map.Where(q => q.vector.x == 1 && q.vector.y == 5).FirstOrDefault();

            if (mapf2 != null)
            {
                mapf2.dynamicType = 1;
            }

            //todo 互相锁死
            Car car1 = new Car(1, 1, 1, 1, 5);
            Car car2 = new Car(2, 1, 5, 1, 1);

            cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);


        }
    }
}