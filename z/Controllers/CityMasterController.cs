using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityMaster.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMasterController : ControllerBase
    {

        // GET api/<CityMasterController>
        [HttpGet("CityMasterGet")]
        public List<City> CityMasterGet()
        {
            City cityMaster = new City();
            List<City> GetData = cityMaster.CityShow();
            return GetData;
        }

        // POST api/<CityMasterController>
        [HttpPost("CityMasterAdd")]
        public int CityMasterAdd([FromBody]City user)
        {
            City cityMaster = new City();
            int res = cityMaster.AddCity(user);
            return res;
        }

        // PUT api/<CityMasterController>/5
        [HttpPut("CityMasterEdit")]
        public int CityMasterEdit([FromBody]City user)
        {
            City cityMaster = new City();
            int res = cityMaster.UpdateCity(user);
            return res;
        }

        // DELETE api/<CityMasterController>/5
        [HttpPost("CityMasterDel")]
        public int CityMasterDel([FromBody]City user)
        {
            City cityMaster = new City();
            int res = cityMaster.DeleteCity(user);
            return res;
        }

        // PUT api/<CityMasterController>/5
        [HttpPut("CityMasterActive")]
        public int CityMasterActive([FromBody] City user)
        {
            City cityMaster = new City();
            int res = cityMaster.InActivateCity(user);
            return res;
        }
    }
}
