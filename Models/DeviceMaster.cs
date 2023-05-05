using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SmartParkingBackend.Models;
namespace SmartParkingBackend.Models
{
    public class DeviceMaster
    {

        
        #region Declaration
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;

        public int intDeviceID { get; set; }

        [Required(ErrorMessage = "Device No is Required")]
        public string strDeviceNo { get; set; }

        [Required(ErrorMessage = "Device Model is Required")]
        public string strDeviceModel { get; set; }

        [Required(ErrorMessage = "Device Token is Required")]
        public string strDeviceToken { get; set; }
        [Required(ErrorMessage = "Parking Lot is Required")]
        public int intParkingLotID { get; set; }

        /*[Required(ErrorMessage = "Parking Lot is Required")]*/
        public string strParkingLotName { get; set; }

        /*[Required(ErrorMessage = "ETM Sim Number is Required")]*/
        [StringLength(13, ErrorMessage = "Must be 10 or 13 characters", MinimumLength = 10)]
        [Range(1, 9999999999999, ErrorMessage = "Sim number must be positive number")]
        public string strETMSimNumber { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        /*[Required(ErrorMessage = "ETM Device Warranty Start Date is Required")]*/
        public DateTime? dteETMDeviceWarrantyStartDate { get; set; }
        [Required(ErrorMessage = "ETM Device Warranty Start Date is Required")]
        public string strETMDeviceWarrantyStartDate { get; set; }
        [Required(ErrorMessage = "ETM Device Warranty End Date is Required")]

        public string strETMDeviceWarrantyEndDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        /*[Required(ErrorMessage = "ETM Device Warranty End Date is Required")]*/
        public DateTime? dteETMDeviceWarrantyEndDate { get; set; }


        public string strRemarks { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dteModified { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }
        #endregion

        #region DeviceShow
        public List<DeviceMaster> DeviceShow()
        {
            Db check = new Db();
            try
            {
                objPostConnection = new cDBPostGresConnection();
                pscmd = new NpgsqlCommand();
                string query = "SELECT FROM readdevice('show','209');FETCH ALL FROM  \"show\";";

                dt = new DataTable();
                pscmd = new NpgsqlCommand(query);
                pscmd.CommandTimeout = 10;
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                objPostConnection = null;
                pscmd.Parameters.Clear();
                pscmd.Dispose();
                List<DeviceMaster> devicelist = check.converttolist<DeviceMaster>(dt);
                return devicelist;
            }
            catch (Exception e)
            {
               
                return null;
            }
        }
        #endregion

        #region
        public int UpdateDevice(DeviceMaster devicemodel)
        {
            try
            {
                objPostConnection = new cDBPostGresConnection();
                pscmd = new NpgsqlCommand();

                string query = "select * from updatedevice( " + devicemodel.intDeviceID + "," +
                                                            "'" + devicemodel.strDeviceNo + "'" + "," +
                                                            "'" + devicemodel.strDeviceModel + "'" + "," +
                                                            "'" + devicemodel.strDeviceToken + "'" + "," +

                                                            "'" + devicemodel.strETMSimNumber + "'" + "," +
                                                            "'" + string.Format("{0:MM-dd-yyyy}", devicemodel.dteETMDeviceWarrantyStartDate) + "'" + "," +
                                                            "'" + string.Format("{0:MM-dd-yyyy}", devicemodel.dteETMDeviceWarrantyEndDate) + "'" + "," +
                                                            "'" + devicemodel.strRemarks + "'" +
                                                            ");";
                dt = new DataTable();
                pscmd = new NpgsqlCommand(query);
                pscmd.CommandTimeout = 10;
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                objPostConnection = null;
                pscmd.Parameters.Clear();
                pscmd.Dispose();
                int response = Convert.ToInt32(dt.Rows[0]["updatedevice"]);
                return response;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion
    }
}
