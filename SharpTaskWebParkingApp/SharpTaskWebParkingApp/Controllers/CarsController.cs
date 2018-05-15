using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkClassLibrary;
using SharpTaskWebParkingApp;
using Newtonsoft.Json;

namespace SharpTaskWebParkingApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class CarsController : Controller
    {
        // GET: api/Cars
        [HttpGet]
        public string Get()
        {
            List<Car> allCars = Db.parking.AllCarList();
            
            var json = JsonConvert.SerializeObject(new
            {
                operations = allCars
            });
            return json;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var json = JsonConvert.SerializeObject(new
            {
                operations = Db.parking.GetCar(id)
            });
            return json;
        }
        
        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
