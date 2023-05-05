using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartParkingBackend.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartParkingBackend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        Db check = new Db();
        // POST api/Login/Log
        [HttpPost("Log")]
        public IActionResult Post([FromBody] Users U)
        {
            
            DataTable dt = check.checkLogin(U.UserName, U.Password);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0][8]) == true)
                {
                    //"Your account is permenantly locked"
                    return NotFound(new { Message= "Your account is permenantly locked" });
                    
                }
                else if (Convert.ToBoolean(dt.Rows[0][7]) == false)
                {
                    //"Your account is temporarily locked"
                    return NotFound(new { Message = "Your account is temporarily locked" });
                }
                else
                {
                    return Ok(new { Message = "Login Success" });
                }
            }
            else
            {
                //"Invalid Email or Password"
                return NotFound(new { Message = "Invalid Email or Password" });
            }

        }

        public class UserEmail
        {
            public string Email { get; set; }
            
        }
        
        [HttpPost("Forgotpassword")]
        public IActionResult ForgotPassword([FromBody] UserEmail e)
        {
            //HttpContext.Session.SetString("Email", e.Email);
            //string email = HttpContext.Session.GetString("Email");
            
            string linkHref = check.SHA256Encrypt(e.Email);
            int valid = 3;
            valid = check.ForgotPassword(e.Email, linkHref);
            //int valid = 1;
            if (valid == 1)
            {
                Random rnd = new Random();
                int newotp = (rnd.Next(100000, 999999));
                check.insertOtpinDB(e.Email, newotp);
                int Sendlink = check.SendVerificationlinkEmail(e.Email, newotp);
                valid = Sendlink;
            }

            if (valid == 1) return Ok(new { Message = "Email Sent Successfully" }); 
            return NotFound(new { Message = "Something Went Wrong Try Again" }); ;
        }

        public class validateOtp
        {
            public int otp { get; set; }
            public string email { get; set; }
            
        }
        [HttpPost("validateotp")]
        public IActionResult validOtp(validateOtp userotp)
        {
            //string email = HttpContext.Session.GetString("Email");
            bool valid = false;
            valid = check.checkOtpvalid(userotp.email , userotp.otp);
            if (valid == true)
            {
                check.deleteOtp(userotp.otp);
                HttpContext.Session.SetString("Email", "");
                return Ok(new { Message = "Verified" }); ;
            }
            return NotFound(new { Message = "Enter Valid Otp" }); ;

        }

        public class ChangePass
        {
            public string email { get; set; }
            public string Newpass { get; set; }

        }
        [HttpPost("Changepass")]
        public IActionResult ChangePassword(ChangePass Cp)
        {            
            
            check.Changepassword(Cp.email, Cp.Newpass);
            
            return Ok(new { Message = "Password Updated Successfully" }); ;
        }
    }
}
