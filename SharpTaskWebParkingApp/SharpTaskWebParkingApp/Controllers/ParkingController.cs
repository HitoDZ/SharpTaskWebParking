using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace SharpTaskWebParkingApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class ParkingController : Controller
    {
        // GET: api/Parking
        [HttpGet("freeplaces")]
        public string Getfp()
        {
            string text = Db.parking.GetFreePlaces().ToString();
            return JsonConvert.DeserializeObject(text).ToString();
        }
        [HttpGet("occupiedplaces")]
        public string Getop()
        {
            string text = Db.parking.GetOccupiedPlaces().ToString();
            return JsonConvert.DeserializeObject(text).ToString();
        }
        [HttpGet("balance")]
        public string Getbal()
        {
            string text = Db.parking.Balance.ToString();
            return JsonConvert.DeserializeObject(text).ToString();
        }
    }
}
