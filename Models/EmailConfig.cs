using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartParkingBackend.Models
{
    public class EmailConfig
    {
        public string strHost { get; set; }
        public string strPort { get; set; }
        public string strUsername { get; set; }
        public string strPassword { get; set; }
        public string FromEmail { get; set; }

    }
}
