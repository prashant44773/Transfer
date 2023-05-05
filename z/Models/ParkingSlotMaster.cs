using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSlotMaster.Models
{
    public class ParkingSlot
    {
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;
        /*[Required]*/
        public int intParkingSlotID { get; set; }

        /*[Required(ErrorMessage = "Parking Lot Name is Required")]*/

        public int intParkingLotID { get; set; }

        /*[Required(ErrorMessage = "Lot Name")]*/
        public string strParkingLotName { get; set; }

        /*[Required(ErrorMessage = "Vehicle Type is Required")]*/
        public int intVehicleTypeID { get; set; }

        /*[Required(ErrorMessage = "Total Slots are Required")]*/
        public int? intTotalSlots { get; set; }


        public string strVehicleType { get; set; }

        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }


        // Temporay Soluytion
        private int UserID = 124;

        public List<ParkingSlot> ParkingSlotShow()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM readparkingslot('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<ParkingSlot> parkingslotlist = Common.converttolist<ParkingSlot>(dt);
            return parkingslotlist;
        }


        public int AddParkingSlot(ParkingSlot slotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createparkingslot( " + slotmodel.intParkingLotID + "," + slotmodel.intVehicleTypeID + "," + slotmodel.intTotalSlots + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createparkingslot"]);
            return response;
        }


        public int UpdateParkingSlot(ParkingSlot slotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from updateparkingslot( " + slotmodel.intParkingSlotID + "," + slotmodel.intParkingLotID + "," + slotmodel.intVehicleTypeID + "," + slotmodel.intTotalSlots + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updateparkingslot"]);
            return response;
        }


        public int DeleteParkingSlot(ParkingSlot slotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from deleteparkingslot( " + slotmodel.intParkingSlotID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deleteparkingslot"]);
            return response;
        }

        public int InActivateParkingSlot(ParkingSlot slotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from activationparkingslot( " + slotmodel.intParkingSlotID + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationparkingslot"]);
            return response;
        }


        public List<ParkingSlot> LotNameByUserID()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM getlotname('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<ParkingSlot> parkingslotlist = Common.converttolist<ParkingSlot>(dt);
            return parkingslotlist;
        }


        public List<ParkingSlot> VehicleNameByUserID()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM getvehiclename('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<ParkingSlot> parkingslotlist = Common.converttolist<ParkingSlot>(dt);
            return parkingslotlist;
        }
    }
}
