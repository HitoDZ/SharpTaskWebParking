using System;
using System.Collections.Generic;
using System.Text;

namespace ParkClassLibrary
{
    public class Transaction
    {
        public DateTime TransactionDateTime { get; set; }
        public int CarId { get; set; }
        public float Pay { get; set; }

        public Transaction(int carId, float pay)
        {
            CarId = carId;
            Pay = pay;
            TransactionDateTime = DateTime.Now;
        }
    }
}
