using AgenciesMaster.Models;
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
    public class AgencyMasterController : ControllerBase
    {


        [HttpGet("AgencyMasterGet")]
        public List<Agency> AgencyMasterGet()
        {
            Agency agency = new Agency();
            List<Agency> agencylist = agency.AgencyShow();
            return agencylist;
        }

        // POST api/<AgencyMasterController>
        [HttpPost("AgencyMasterAdd")]
        public int AgencyMasterAdd([FromBody]Agency agnt)
        {
            Agency agency = new Agency();
            int agencylist = agency.AddAgency(agnt);
            return agencylist;
        }

        // PUT api/<AgencyMasterController>/5
        [HttpPut("AgencyMasterEdit")]
        public int AgencyMasterEdit([FromBody] Agency agnt)
        {
            Agency agency = new Agency();
            int agencylist = agency.UpdateAgency(agnt);
            return agencylist;
        }

        // DELETE api/<AgencyMasterController>/5
        [HttpPost("AgencyMasterDel")]
        public int AgencyMasterDel([FromBody]Agency agnt)
        {
            Agency agency = new Agency();
            int agencylist = agency.DeleteAgency(agnt);
            return agencylist;
        }

        // PUT api/<AgencyMasterController>/5
        [HttpPut("AgencyMasterActive")]
        public int AgencyMasterActive([FromBody] Agency agnt)
        {
            Agency agency = new Agency();
            int agencylist = agency.InActivateAgency(agnt);
            return agencylist;
        }
    }
}
