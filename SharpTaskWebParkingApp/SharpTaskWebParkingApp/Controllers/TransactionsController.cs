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
            if ((allCars != null)&&(allCars.Count >0))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    MinTransactions = allCars
                });
                return json;
            }
            else
            {
                var json = JsonConvert.SerializeObject(new
                {
                    Error = "404 Not Found"//new List<string>() {"status","404" }
                });
                return json;
            }
        }
        

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]double value)
        {

            var car = Db.parking.GetCar(id);
            if (car != null)
            {
                car.AddBalance((float)value);
                return Ok();
            }
            
            else { return NotFound(); }

        }

    }
}
