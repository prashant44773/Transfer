using AreaMaster.Models;
using CityMaster.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaMasterController : ControllerBase
    {
        // GET: api/<AreaMaster>
        [HttpGet("AreaMasterGet")]
        public List<Area> AreaMasterGet()
        {
            Area area = new Area();
            List<Area> areaList = area.AreaShow();
            return areaList;
        }


        // POST api/<AreaMaster>
        [HttpPost("AreaMasterAdd")]
        public int AreaMasterAdd([FromBody]Area user)
        {
            Area area = new Area();
            int res = area.AddArea(user);
            return res;
        }

        // PUT api/<AreaMaster>/5
        [HttpPut("AreaMasterEdit")]
        public int AreaMasterEdit([FromBody]Area user)
        {
            Area area = new Area();
            int res = area.UpdateArea(user);
            return res;
        }

        // DELETE api/<AreaMaster>/5
        [HttpPost("AreaMasterDel")]
        public int AreaMasterDel([FromBody]Area user)
        {
            Area area = new Area();
            int res = area.DeleteArea(user);
            return res;
        }

        // PUT api/<AreaMaster>/5
        [HttpPut("AreaMasterActive")]
        public int AreaMasterActive([FromBody] Area user)
        {
            Area area = new Area();
            int res = area.InActivateArea(user);
            return res;
        }


        [HttpGet("AreaMasterGetCityNames")]
        public List<City> AreaMasterCityNames()
        {
            Area city = new Area();
            List<City> areaList = city.GetCityNames();
            return areaList;
        }

        [HttpGet("AreaMasterCollectorNames")]
        public List<Area> AreaMasterCollectorNames()
        {
            Area city = new Area();
            List<Area> areaList = city.GetCollectorName();
            return areaList;
        }
    }
}
