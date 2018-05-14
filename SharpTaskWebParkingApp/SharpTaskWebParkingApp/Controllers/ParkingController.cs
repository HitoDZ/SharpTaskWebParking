using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SharpTaskWebParkingApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class ParkingController : Controller
    {
        // GET: api/Parking
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Parking/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
