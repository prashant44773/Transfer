using AreaMaster.Models;
using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLotMaster.Models
{
    public class ParkingLot
    {
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;

        public int intParkingLotID { get; set; }

        /*[StringLength(50, ErrorMessage = "Must be between 2 to 50 Characters", MinimumLength = 2)]
        [Required(ErrorMessage = "Lot Name is Required")]*/
        public string strParkingLotName { get; set; }

        /*[Required(ErrorMessage = "Parking Lot Address is Required")]

        [StringLength(1000, ErrorMessage = "Must be between 4 to 1000 Characters", MinimumLength = 4)]*/
        public string strAddress { get; set; }
        /*[Required(ErrorMessage = "Area Name is Required")]*/
        public int intAreaID { get; set; }

        public string strAreaName { get; set; }
        /*[Required(ErrorMessage = "City Name is Required")]*/
        public int intCityID { get; set; }


        public string strCityName { get; set; }

        /*[Required(ErrorMessage = "Latitude is Required")]*/
        public decimal? decLatitude { get; set; }

        /*[Required(ErrorMessage = "Longitude is Required")]*/
        public decimal? decLongitude { get; set; }

        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }

        // Temporary Solution
        int UserID = 124;

        public List<ParkingLot> ParkingLotShow()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            /*string query = "SELECT FROM readparkinglot('show'," + SessionWrapper.UserID + ");FETCH ALL FROM  \"show\";";*/
            string query = "SELECT FROM readparkinglot('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<ParkingLot> parkinglotlist = Common.converttolist<ParkingLot>(dt);
            return parkinglotlist;
        }


        public int AddParkingLot(ParkingLot lotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createparkinglot( " + "'" + lotmodel.strParkingLotName + "'" + "," + "'" + lotmodel.strAddress + "'" + "," + lotmodel.intCityID + "," + lotmodel.intAreaID + "," + "'" + lotmodel.decLatitude + "'" + "," + "'" + lotmodel.decLongitude + "'" + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int lot = Convert.ToInt32(dt.Rows[0]["createparkinglot"]);
            return lot;
        }


        public int UpdateParkingLot(ParkingLot lotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from updateparkinglot( " + lotmodel.intParkingLotID + "," + "'" + lotmodel.strParkingLotName + "'" + "," + "'" + lotmodel.strAddress + "'" + "," + lotmodel.intCityID + "," + lotmodel.intAreaID + "," + "'" + lotmodel.decLatitude + "'" + "," + "'" + lotmodel.decLongitude + "'" + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int lot = Convert.ToInt32(dt.Rows[0]["updateparkinglot"]);
            return lot;
        }


        public int DeleteParkingLot(ParkingLot lotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from deleteparkinglot( " + lotmodel.intParkingLotID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int lot = Convert.ToInt32(dt.Rows[0]["deleteparkinglot"]);
            return lot;
        }

        public int InActivatePrkingLot(ParkingLot lotmodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from activationparkinglot( " + lotmodel.intParkingLotID + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int lot = Convert.ToInt32(dt.Rows[0]["activationparkinglot"]);
            return lot;
        }

        public List<Area> GetAreaNameByCity()
        {
            Db Common = new Db();
            Area lot = new Area();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            /*string query = "select * From getcollectorname('ref1'); fetch all from \"ref1\";";*/
            string query = "select * From getareanameaspercity('ref1'," + lot.UserID + "); fetch all from \"ref1\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[1];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<Area> arealist = Common.converttolist<Area>(dt);
            return arealist;
        }
    }

}

