using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkClassLibrary;


namespace SharpTaskWebParkingApp.Controllers
{
    [Produces("application/json")]
        [Route("api/[controller]")]

    public class TransactionsController : Controller
    {
        // GET: api/Transactions
        [HttpGet]
        public JsonResult Get()
        {
            JsonResult a = new JsonResult(Db.parking.TransactionLog());
            return a;
        }
        [HttpGet("GetMinTransactions")]
        public string GetMinTransactions()
        {
            List<Transaction> allCars = Db.parking.GetMinTransactions();

            var json = JsonConvert.SerializeObject(new
            {
                operations = allCars
            });
            return json;
        }
        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
           
            List<Transaction> allCars = Db.parking.GetMinTransactions(id);

            var json = JsonConvert.SerializeObject(new
            {
                operations = allCars
            });
            return json;
        }
        

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]double value)
        {
            if(id > 0)
            {
                var car = Db.parking.GetCar(id);
                if(car != null) {  car.AddBalance((float)value); }
              
            }
        }

    }
}
