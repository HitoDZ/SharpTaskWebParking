using System;
using System.Collections.Generic;
using System.Text;

namespace ParkClassLibrary
{
    public class Settings
    {

        public int ParkingSpace { get; set; }
        public int Fine { get; set; } // Налог
        public int Timeout { get; set; } // Time when we take a money
        public Dictionary<CarType.carTypes, float> Price;

        public Settings()
        {
            Fine = 5;
            Timeout = 10000000;
            Price = new Dictionary<CarType.carTypes, float>()
            {
                {CarType.carTypes.BUSS, 2},
                {CarType.carTypes.MOTOCYCLE, 1},
                {CarType.carTypes.PASSENGER, 3},
                {CarType.carTypes.TRUCK, 5}
            };
            ParkingSpace = 10;

        }
    }
}
