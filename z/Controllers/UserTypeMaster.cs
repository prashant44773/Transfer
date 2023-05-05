using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserTypeMaster.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeMaster : ControllerBase
    {

        // GET api/<UserTypeMaster>/5
        [HttpGet("UserTypeGet")]
        public List<UserType> UserTypeGet()
        {
            UserType user = new UserType();
            List<UserType> users = user.UserTypeShow();
            return users;
        }

        // POST api/<UserTypeMaster>
        [HttpPost("UserTypeAdd")]
        public int UserTypeAdd([FromBody] UserType user)
        {
            UserType userM = new UserType();
            int res = userM.AddUserType(user);
            return res;
        }

        // PUT api/<UserTypeMaster>/5
        [HttpPut("UserTypeEdit")]
        public int UserTypeEdit([FromBody] UserType user)
        {
            UserType userM = new UserType();
            int res = userM.UpdateUserType(user);
            return res;
        }

        // DELETE api/<UserTypeMaster>/5
        [HttpPost("UserTypeDel")]
        public int Delete([FromBody]UserType user)
        {
            UserType userM = new UserType();
            int res = userM.DeleteUserType(user);
            return res;
        }

        // PUT api/<UserTypeMaster>/5
        [HttpPut("UserTypeActive")]
        public int UserTypeActive([FromBody] UserType user)
        {
            UserType userM = new UserType();
            int res = userM.InActivateUserType(user);
            return res;
        }
    }
}
