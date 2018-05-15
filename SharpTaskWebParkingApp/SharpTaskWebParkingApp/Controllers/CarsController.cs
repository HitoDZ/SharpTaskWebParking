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
        public JsonResult Get()
        {
            List<Car> allCars = Db.parking.AllCarList();
            
            var json = JsonConvert.SerializeObject(new
            {
                allcars = allCars
            });
            return new JsonResult(json);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Car car = Db.parking.GetCar(id);
            if (car != null)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    car = Db.parking.GetCar(id)
                }); 
                return json;
            }
            else
            {
                var json = JsonConvert.SerializeObject(new
                {
                    Error = "404 Not Found"
                });
                return json;
            }
        }
        
        // POST: api/Cars
        [HttpPost]
        public IActionResult Post([FromBody]double value)
        {
            if (value <= 0){return BadRequest();}
            else
            {
                bool a = Db.parking.AddCar(new Car((float)value));
                if (a == true) { return Ok(); }
                else { return BadRequest(); }

            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           bool answer = Db.parking.DeleteCar(id);
            if (answer == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
