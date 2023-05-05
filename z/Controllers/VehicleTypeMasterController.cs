using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTypeMaster.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeMasterController : ControllerBase
    {

        // GET api/<VehicleTypeMasterController>/5
        [HttpGet("VehicleTypeGet")]
        public List<VehicleType> VehicleTypeGet()
        {
            VehicleType vehicle = new VehicleType();
            List<VehicleType> vehicleTypelist = vehicle.VehicleTypeShow();
            return vehicleTypelist;
        }

        // POST api/<VehicleTypeMasterController>
        [HttpPost("VehicleTypeAdd")]
        public int VehicleTypeAdd([FromBody]VehicleType user)
        {
            VehicleType vehicle = new VehicleType();
            int res = vehicle.AddVehicleType(user);
            return res;
        }

        // PUT api/<VehicleTypeMasterController>/5
        [HttpPut("VehicleTypeEdit")]
        public int VehicleTypeEdit([FromBody]VehicleType user)
        {
            VehicleType vehicle = new VehicleType();
            int res = vehicle.UpdateVehicleType(user);
            return res;
        }

        // DELETE api/<VehicleTypeMasterController>/5
        [HttpPost("VehicleTypeDel")]
        public int VehicleTypeDel([FromBody]VehicleType user)
        {
            VehicleType vehicle = new VehicleType();
            int res = vehicle.DeleteVehicleType(user);
            return res;
        }

        // PUT api/<VehicleTypeMasterController>/5
        [HttpPut("VehicleTypeActive")]
        public int VehicleTypeActive([FromBody] VehicleType user)
        {
            VehicleType vehicle = new VehicleType();
            int res = vehicle.InActivateVehicleType(user);
            return res;
        }
    }
}
