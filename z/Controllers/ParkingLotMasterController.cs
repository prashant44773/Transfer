using AreaMaster.Models;
using Microsoft.AspNetCore.Mvc;
using ParkingLotMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotMasterController : ControllerBase
    {

        // GET api/<ParkingLotMasterController>/5
        [HttpGet("ParkingLotGet")]
        public List<ParkingLot> ParkingLotGet()
        {
            ParkingLot lot = new ParkingLot();
            List<ParkingLot> parkingLotList = lot.ParkingLotShow();
            return parkingLotList;
        }

        // POST api/<ParkingLotMasterController>
        [HttpPost("ParkingLotAdd")]
        public int ParkingLotAdd([FromBody]ParkingLot user)
        {
            ParkingLot lot = new ParkingLot();
            int res = lot.AddParkingLot(user);
            return res;
        }

        // PUT api/<ParkingLotMasterController>/5
        [HttpPut("ParkingLotEdit")]
        public int ParkingLotEdit([FromBody]ParkingLot user)
        {
            ParkingLot lot = new ParkingLot();
            int res = lot.UpdateParkingLot(user);
            return res;
        }

        // DELETE api/<ParkingLotMasterController>/5
        [HttpPost("ParkingLotDel")]
        public int ParkingLotDel([FromBody]ParkingLot user)
        {
            ParkingLot lot = new ParkingLot();
            int res = lot.DeleteParkingLot(user);
            return res;
        }

        // PUT api/<ParkingLotMasterController>/5
        [HttpPut("ParkingLotActive")]
        public int ParkingLotActive([FromBody] ParkingLot user)
        {
            ParkingLot lot = new ParkingLot();
            int res = lot.InActivatePrkingLot(user);
            return res;
        }

        [HttpGet("GetAreaNameByCity")]
        public List<Area> GetAreaNameByCity()
        {
            ParkingLot lot = new ParkingLot();
            List<Area> parkingLotList = lot.GetAreaNameByCity();
            return parkingLotList;
        }
    }
}
