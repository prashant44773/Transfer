using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartParkingBackend.Models;
using Newtonsoft.Json;

namespace SmartParkingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceMasterController : ControllerBase
    {
        [HttpGet("Master")]
        public string GetData()
        {
            DeviceMaster deviceobject = new DeviceMaster();
            List<DeviceMaster> list = deviceobject.DeviceShow();

            var listjson = JsonConvert.SerializeObject(list);

            return listjson;
        }


        [HttpPost("Edit")]
        public bool EditData([FromBody] DeviceMaster deviceModel)
        {
            DeviceMaster deviceObject = new DeviceMaster();
            var eTMDeviceWarrantyStartDatelength = deviceModel.strETMDeviceWarrantyStartDate.Length;
            var eTMDeviceWarrantyEndDatelength = deviceModel.strETMDeviceWarrantyEndDate.Length;
            var t = deviceModel.strDeviceToken;
            if (eTMDeviceWarrantyStartDatelength > 10)
            {
                deviceModel.dteETMDeviceWarrantyStartDate = Convert.ToDateTime(deviceModel.strETMDeviceWarrantyStartDate.Substring(0, 16).Trim());
            }
            if (eTMDeviceWarrantyEndDatelength > 10)
            {
                deviceModel.dteETMDeviceWarrantyEndDate = Convert.ToDateTime(deviceModel.strETMDeviceWarrantyEndDate.Substring(0, 16).Trim());
            }
            if (deviceModel.dteETMDeviceWarrantyEndDate == null)
            {
                deviceModel.dteETMDeviceWarrantyEndDate = Convert.ToDateTime(deviceModel.strETMDeviceWarrantyEndDate);
            }


            int id = deviceObject.UpdateDevice(deviceModel);
            return true;
        }


    }
    
}
    