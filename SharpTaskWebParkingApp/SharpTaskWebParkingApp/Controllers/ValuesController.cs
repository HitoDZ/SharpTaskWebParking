using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SharpTaskWebParkingApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public ContentResult Get()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content =
                "<html>" +
                 "<body><b>Welcome</b> " +
                "</br></br></br><hr><a href='Transactions'>api/Transactions - Transaction.log </a>" +
                "</br><a href='Transactions/GetMinTransactions'>api/Transactions/GetMinTransactions - transactions (1 min) </a>" +
                "</br><a >api/Transactions/GetMinTransactions/[id] - transaction of cur car (1 min) </a><hr>" +

                "</br><hr><a href='Parking/occupiedplaces'>api/Transactions/occupiedplaces - Free places </a>" +
                "</br><a href='Parking/freeplaces'>api/Transactions/freeplaces - num of occupied places </a>" +
                "</br><a href='Parking/balance'>api/Transactions/balance - balance of Parking </a><hr>" +

                "</br><hr><a href='Cars'>api/Cars - all Cars </a>" +
                "</br><a > POST: api/Cars ([FromBody]double value) - Set Balance of car. (Add only TRACKS cause project without UI)</a>" +
                "</br><a >api//Cars/[id] - get cur car </a>" +
                "</br><a >DELETE: api/ApiWithActions/[id] - delete cur car </a><hr>" +

                    "</body>" +
                "</html>"
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
