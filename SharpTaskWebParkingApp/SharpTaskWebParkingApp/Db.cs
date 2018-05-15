using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkClassLibrary;

namespace SharpTaskWebParkingApp
{
    public class Db
    {
        public static Parking parking = Parking.Instance;
        static Db()
        {
            parking.AddCar(new Car(1000));
            parking.AddCar(new Car(2000));
            parking.AddCar(new Car(3000));
            parking.AddCar(new Car(4000));
            parking.AddCar(new Car(1000));
            parking.AddCar(new Car(1000));
            parking.PeriodicPayAsync(TimeSpan.FromTicks(parking._settings.Timeout));
            parking.PeriodicLogAsync(TimeSpan.FromTicks(parking._settings.Timeout * 1000));
        }
    }
}
