using System;
using System.Collections.Generic;
using System.Text;

namespace ParkClassLibrary
{
    class Car
    {
        private static Random rnd = new Random();
        public Car(int carId, float ballanse, CarType.carTypes carType)
        {
            this.CarId = carId;
            this.Ballanse = ballanse;
            this.TypeOfCar = carType;
        }
        public Car(float ballanse, CarType.carTypes carType)
        {
            //Random rand = new Random();
            this.CarId = rnd.Next(0, 2000);
            this.Ballanse = ballanse;
            this.TypeOfCar = carType;
        }
        public Car(float ballanse)
        {

            // Random rand = new Random();
            this.CarId = rnd.Next(0, 2000);
            this.Ballanse = ballanse;
            this.TypeOfCar = CarType.carTypes.PASSENGER;
        }
        private float _ballanse;
        public float Ballanse
        {
            get => _ballanse;
            set
            {
                if (value >= 0)
                    _ballanse = value;
            }
        }
        public readonly CarType.carTypes TypeOfCar;
        public readonly int CarId;

        public void AddBalance(float bal)
        {
            try
            {
                Ballanse += bal;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid sum");
            }

        }
    }
}
