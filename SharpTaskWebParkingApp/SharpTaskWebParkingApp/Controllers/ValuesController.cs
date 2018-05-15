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
                "</br><a> PUT: api/Transactions/[id] -(int id, [FromBody]double value) - set id and money wich you add to cur balance</a>" +
                "</br><a >api/Transactions/GetMinTransactions/[id] - transaction of cur car (1 min) </a><hr>" +

                "</br><hr><a href='Parking/occupiedplaces'>api/Parking/occupiedplaces - Free places </a>" +
                "</br><a href='Parking/freeplaces'>api/Parking/freeplaces - num of occupied places </a>" +
                "</br><a href='Parking/balance'>api/Parking/balance - balance of Parking </a><hr>" +

                "</br><hr><a href='Cars'>api/Cars - all Cars </a>" +
                "</br><a > POST: api/Cars ([FromBody]double value) - Set Balance of car. (Add only TRACKS cause project without UI)</a>" +
                "</br><a >api//Cars/[id] - get cur car </a>" +
                "</br><a >DELETE: api/ApiWithActions/[id] - delete cur car </a><hr>" +

                    "</body>" +
                "</html>"
            };
        }
   
    }
}
