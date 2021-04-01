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
            // Car car1 = new Car(1, 1, 1, 5);
            // Car car2 = new Car(1, 5, 1, 1);
            // Car car3 = new Car(1, 2, 7, 7);

            // cars = new List<Car>();
            // cars.Add(car1);
            // cars.Add(car2);
            // cars.Add(car3);


            Car car1 = new Car(1, 1, 15, 8);
            Car car2 = new Car(15, 8, 1, 1);
            Car car3 = new Car(1, 2, 15, 10);

            cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
        }
    }
}