using Microsoft.AspNetCore.Mvc;
using ParkingSlotMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSlotMasterController : ControllerBase
    {

        // GET api/<ParkingSlotMasterController>/5
        [HttpGet("ParkingSlotGet")]
        public List<ParkingSlot> ParkingSlotGet()
        {
            ParkingSlot parking = new ParkingSlot();
            List<ParkingSlot> parkingSlotList = parking.ParkingSlotShow();
            return parkingSlotList;
        }

        // POST api/<ParkingSlotMasterController>
        [HttpPost("ParkingSlotAdd")]
        public int ParkingSlotAdd([FromBody]ParkingSlot user)
        {
            ParkingSlot parking = new ParkingSlot();
            int res = parking.AddParkingSlot(user);
            return res;
        }

        // PUT api/<ParkingSlotMasterController>/5
        [HttpPut("ParkingSlotEdit")]
        public int ParkingSlotEdit([FromBody]ParkingSlot user)
        {
            ParkingSlot parking = new ParkingSlot();
            int res = parking.UpdateParkingSlot(user);
            return res;
        }

        // DELETE api/<ParkingSlotMasterController>/5
        [HttpPost("ParkingSlotDel")]
        public int ParkingSlotDel([FromBody]ParkingSlot user)
        {
            ParkingSlot parking = new ParkingSlot();
            int res = parking.DeleteParkingSlot(user);
            return res;
        }

        // PUT api/<ParkingSlotMasterController>/5
        [HttpPut("ParkingSlotActive")]
        public int ParkingSlotActive([FromBody] ParkingSlot user)
        {
            ParkingSlot parking = new ParkingSlot();
            int res = parking.InActivateParkingSlot(user);
            return res;
        }

        // GET api/<ParkingSlotMasterController>/5
        [HttpGet("GetLotNames")]
        public List<ParkingSlot> GetLotNames()
        {
            ParkingSlot parking = new ParkingSlot();
            List<ParkingSlot> parkingSlotList = parking.LotNameByUserID();
            return parkingSlotList;
        }


        // GET api/<ParkingSlotMasterController>/5
        [HttpGet("GetVehicleNames")]
        public List<ParkingSlot> GetVehicleNames()
        {
            ParkingSlot parking = new ParkingSlot();
            List<ParkingSlot> parkingSlotList = parking.VehicleNameByUserID();
            return parkingSlotList;
        }
    }
}
