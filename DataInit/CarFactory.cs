using System.Collections.Generic;
using ATao.Model;

namespace ATao.DataInit
{
    public class CarFactory
    {
        public static List<Car> cars;
        public static void InitCar()
        {
            Car car = new Car(1,1,1,5);

            cars = new List<Car>();
            cars.Add(car);
        }
    }
}