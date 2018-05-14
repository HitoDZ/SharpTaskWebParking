using System.Collections.Generic;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Xml.Schema;
using System.Threading;
using System.Threading.Tasks;


namespace ParkClassLibrary
{
    class Parking
    {

        // Fields
        Object locker = new Object();
        static string path = System.IO.Directory.GetCurrentDirectory() + "\\Transaction.log";
        public int freePlaces;
        public Settings _settings = new Settings();
        protected List<Transaction> listTransactions = new List<Transaction>();

        protected Dictionary<int, Car> CarList = new Dictionary<int, Car>();
        public float Balance { get; set; }
        protected Dictionary<int, float> debts = new Dictionary<int, float>();

        // Singltone
        private static readonly Parking instance = new Parking();

        static Parking()
        {

        }

        public int GetFreePlaces()
        {
            // ...
            //var a = "There " + freePlaces.ToString() + " places";
            return freePlaces;
        }

        public int GetOccupiedPlaces()
        {
            return _settings.ParkingSpace - freePlaces;
        }


        public string GetBalance()
        {
            var a = "Current balance of Parking " + Balance.ToString();
            return a;

        }

        private Parking()
        {
            freePlaces = _settings.ParkingSpace;
        }

        public static Parking Instance
        {
            get { return instance; }
        }




        public void AddCar(Car car)
        {
            if (freePlaces <= 0)
            {
                Console.WriteLine("There no free place");
            }
            else
            {

                try
                {
                    if (car != null)
                    {

                        CarList.Add(car.CarId, car);
                        freePlaces -= 1;

                    }
                    else
                    {
                        Console.WriteLine("Car is not valid");
                    }
                }
                catch (Exception e)
                {
                    // Console.WriteLine(car.CarId);
                    Console.WriteLine("Car is not valid");
                }
            }

        }


        public void DeleteCar(Car car)
        {
            try
            {
                if ((car != null) && (!debts.ContainsKey(car.CarId)))
                {

                    CarList.Remove(car.CarId);
                    freePlaces += 1;

                }
                else
                {
                    Console.WriteLine("Car cant be deleted. Chack your balance.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There no such car");
            }

        }

        public void Log()
        {
            float sum = 0;
            var timeNow = DateTime.Now;
            var transactions = (from x in listTransactions
                                where (timeNow - x.TransactionDateTime).TotalMinutes > 1
                                select x).ToList<Transaction>();

            foreach (var i in transactions)
            {
                sum += i.Pay;

            }
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                string text = DateTime.Now.ToString() + " - " + sum;
                sw.WriteLine(text);

            }

            foreach (var x in transactions)
            {
                listTransactions.Remove(x);
            }

            //listTransactions.Clear();
        }
        public string TransactionLog()
        {
            try
            {
                string log;
                using (StreamReader sr = new StreamReader(path))
                {
                    log = sr.ReadToEnd();
                }

                return log;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return "Reading file failed, try again";
            }

        }

        public List<Transaction> GetMinTransactions()
        {
            var timeNow = DateTime.Now;
            var transactions = (from x in listTransactions
                                where (timeNow - x.TransactionDateTime).TotalMinutes <= 1
                                select x).ToList<Transaction>();
            return transactions;
        }
        public List<Transaction> GetMinTransactions(int id)
        {
            var timeNow = DateTime.Now;
            var transactions = (from x in listTransactions
                                where (timeNow - x.TransactionDateTime).TotalMinutes <= 1
                                && (x.CarId == id)
                                select x).ToList<Transaction>();
            return transactions;
        }

        public void GetPay()
        {
            foreach (var i in CarList)
            {
                var price = _settings.Price[i.Value.TypeOfCar];
                if (debts.ContainsKey(i.Value.CarId) && i.Value.Ballanse >= debts[i.Value.CarId])
                {
                    i.Value.Ballanse -= debts[i.Value.CarId];
                    Balance += debts[i.Value.CarId];
                    Transaction t = new Transaction(i.Value.CarId, debts[i.Value.CarId]);
                    listTransactions.Add(t);
                    debts.Remove(i.Value.CarId);
                }

                if (i.Value.Ballanse >= price)
                {
                    i.Value.Ballanse -= price;
                    Balance += price;
                    Transaction t = new Transaction(i.Value.CarId, price);
                    listTransactions.Add(t);
                }
                else
                {
                    if (!debts.ContainsKey(i.Value.CarId))
                        debts.Add(i.Value.CarId, price * _settings.Fine);
                    debts[i.Value.CarId] += price * _settings.Fine;

                }
            }
        }

        public List<Car> AllCarList()
        {
            List<Car> Cars = new List<Car>();
            foreach (var x in CarList)
            {
                Cars.Add(x.Value);
            }
            return Cars;
        }
        public Car GetCar(int id)
        {
            Car car = CarList[id];
            return car;
        }

        public void DeleteCar(int carid)
        {
            try
            {
                if (!debts.ContainsKey(carid))
                {

                    CarList.Remove(carid);
                    freePlaces += 1;

                }
                else
                {
                    Console.WriteLine("Car cant be deleted. Chack your balance.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There no such car");
            }

        }
        public async Task PeriodicPayAsync(TimeSpan interval)
        {
            while (true)
            {
                GetPay();
                Console.WriteLine(Balance);
                await Task.Delay(TimeSpan.FromTicks(_settings.Timeout));
            }
        }
        public async Task PeriodicLogAsync(TimeSpan interval)
        {
            while (true)
            {
                Log();
                Console.WriteLine(TransactionLog());
                await Task.Delay(TimeSpan.FromTicks(_settings.Timeout * 100));
            }
        }
    }
}
