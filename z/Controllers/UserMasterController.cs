using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMaster.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        // GET api/<UserMaster>/5
        [HttpGet("UserMasterGet")]
        public List<UserMast> Get()
        {
            UserMast user = new UserMast();
            List<UserMast> list = user.UserShow();
            return list;
        }

        // POST api/<UserMaster>
        [HttpPost("UserMasterAdd")]
        public int UserMasterAdd([FromBody] UserMast user)
        {
            UserMast userM = new UserMast();
            int res = userM.AddUser(user);
            return res;
        }

        // PUT api/<UserMaster>/5
        [HttpPut("UserMasterEdit")]
        public int UserMasterEdit([FromBody] UserMast user)
        {
            UserMast userM = new UserMast();
            int res = userM.UpdateUser(user);
            return res;
        }

        // DELETE api/<UserMaster>/5
        [HttpPost("UserMasterDel")]
        public int UserMasterDel([FromBody]UserMast user)
        {
            UserMast userM = new UserMast();
            int res = userM.DeleteUser(user);
            return res;
        }

        // PUT api/<UserMaster>/5
        [HttpPut("UserMasterActive")]
        public int UserMasterActive([FromBody] UserMast user)
        {
            UserMast userM = new UserMast();
            int res = userM.InActivateUser(user);
            return res;
        }


        // GET api/<UserMaster>/5
        [HttpGet("GetAgencyNames")]
        public List<UserMast> GetAgencyNames()
        {
            UserMast user = new UserMast();
            List<UserMast> list = user.GetAgencyNames();
            return list;
        }


        // GET api/<UserMaster>/5
        [HttpGet("GetUserTypeNames")]
        public List<UserMast> GetUserTypeNames()
        {
            UserMast user = new UserMast();
            List<UserMast> list = user.GetUserTypeNames();
            return list;
        }
    }
}
