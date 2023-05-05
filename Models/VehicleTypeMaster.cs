using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace VehicleTypeMaster.Models
{
    public class VehicleType
    {
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;


        public int intVehicleTypeID { get; set; }

        /*[Required(ErrorMessage = "Vehicle Type is Required")]*/
        public string strVehicleType { get; set; }
        /*[Required(ErrorMessage = "Minimum Fare is Required")]*/
        public int? intMinimumFare { get; set; }



        /*[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }


        public List<VehicleType> VehicleTypeShow()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM readvehicletype('show');FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<VehicleType> list = Common.converttolist<VehicleType>(dt);
            return list;
        }


        public int AddVehicleType(VehicleType vtypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createvehicletype(" + "'" + vtypemodel.strVehicleType + "'" + "," + vtypemodel.intMinimumFare + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createvehicletype"]);
            return response;
        }


        public int UpdateVehicleType(VehicleType vtypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from updatevehicletype(" + vtypemodel.intVehicleTypeID + "," + "'" + vtypemodel.strVehicleType + "'" + "," + vtypemodel.intMinimumFare + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updatevehicletype"]);
            return response;
        }


        public int DeleteVehicleType(VehicleType vtypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from deletevehicletype(" + vtypemodel.intVehicleTypeID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deletevehicletype"]);
            return response;
        }

        public int InActivateVehicleType(VehicleType vtypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from activationvehicletype(" + vtypemodel.intVehicleTypeID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationvehicletype"]);
            return response;
        }
    }
}
