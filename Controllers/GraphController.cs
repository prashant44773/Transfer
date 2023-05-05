using GraphModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using SmartParkingBackend.Models;
using GraphDataModel.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        [HttpGet("InOut")]
        public String GetInOutGraphData(int Lotid, int Areaid, string fromdate, string todate)
        {
            Db Common = new Db();

            if (fromdate == null)
                fromdate = todate = DateTime.Now.ToString("MM-dd-yyyy");

            Graph graphModel = new Graph();
            DataTable dt = graphModel.GetInOutGraphData(Lotid, Areaid, fromdate, todate);
            /*return Json(dt);*/
            Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            return Newtonsoft.Json.JsonConvert.SerializeObject(dt).ToString();
        }

    }
}
