using CityMaster.Models;
using Npgsql;
using SmartParkingBackend.Models;
using StructureMap.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AreaMaster.Models
{
    public class Area
    {
        #region Declaration
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;

        public int intAreaID { get; set; }

        /*[StringLength(50, ErrorMessage = "Must be between 2 to 50 Characters", MinimumLength = 2)]
        [Required(ErrorMessage = "Area name is Required")]*/
        public string strAreaName { get; set; }
        /*[Required(ErrorMessage = "Address is Required")]*/
        public string strAddress { get; set; }

        /*[Required(ErrorMessage = "City is Required")]*/
        public int intCityID { get; set; }

        public string strCityName { get; set; }

        /*[RegularExpression("[0-9]{1,7}[.]{1}[0-9]{1,7}", ErrorMessage = "Must be a valid Latitude")]
        [Required(ErrorMessage = "Latitude is Required")]*/
        public decimal? decLatitude { get; set; }

        /*[Required(ErrorMessage = "Longitude is Required")]
        [RegularExpression("[0-9]{1,7}[.]{1}[0-9]{1,7}", ErrorMessage = "Must be a valid Longitude")]*/
        public decimal? decLongitude { get; set; }

        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }

        /*[Required(ErrorMessage = "Collector Name is Required")]*/
        public int intUserID { get; set; }

        public string strUserName { get; set; }

        public string strRemarks { get; set; }
        #endregion

        // Temporary Solution for SessionWrapper.UserID
        public int UserID = 124;


        public List<Area> AreaShow()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            /*string query = "SELECT FROM readarea('show'," + SessionWrapper.UserID + ");FETCH ALL FROM  \"show\";";*/
            string query = "SELECT FROM readarea('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<Area> arealist = Common.converttolist<Area>(dt);
            return arealist;
        }

        public int AddArea(Area areamodel)
        {
            areamodel.intCityID = 1;
            areamodel.intUserID = 124;


            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createarea( " + "'" + areamodel.strAreaName + "'" + "," +
                                                                areamodel.intCityID + "," +
                                                                areamodel.intUserID + "," +
                                                                "'" + areamodel.strAddress + "'" + "," +
                                                                "'" + areamodel.decLatitude + "'" + "," +
                                                                "'" + areamodel.decLongitude + "'" + "," +
                                                                "'" + Convert.ToString(areamodel.strRemarks) + "'" + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createarea"]);
            return response;
        }


        public int UpdateArea(Area areamodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from updatearea( " + areamodel.intAreaID + "," +
                                                    "'" + areamodel.strAreaName + "'" + "," +
                                                        areamodel.intCityID + "," +
                                                         areamodel.intUserID + "," +

                                                    /*areamodel.UserID + "," +*/

                                                    "'" + areamodel.strAddress + "'" + "," +
                                                    "'" + areamodel.decLatitude + "'" + "," +
                                                    "'" + areamodel.decLongitude + "'" + "," +
                                                    "'" + Convert.ToString(areamodel.strRemarks) + "'" + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updatearea"]);
            return response;
        }


        public int DeleteArea(Area areamodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from deletearea( " + areamodel.intAreaID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deletearea"]);
            return response;
        }


        public int InActivateArea(Area areamodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from activationarea( " + areamodel.intAreaID + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationarea"]);
            return response;
        }


        public List<City> GetCityNames()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            /*string query = "SELECT FROM readarea('show'," + SessionWrapper.UserID + ");FETCH ALL FROM  \"show\";";*/
            /*string query = "SELECT \"intCityID\",\"strCityName\" FROM \"tblCityMaster\" where \"bDeleted\" = 'false'order by \"intCityID\" asc; ";*/

            string query = "select * From getcityname('ref1'); fetch all from \"ref1\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[1];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<City> arealist = Common.converttolist<City>(dt);
            return arealist;
        }


        public List<Area> GetCollectorName()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            /*string query = "SELECT FROM readarea('show'," + SessionWrapper.UserID + ");FETCH ALL FROM  \"show\";";*/
            /*string query = "SELECT \"intCityID\",\"strCityName\" FROM \"tblCityMaster\" where \"bDeleted\" = 'false'order by \"intCityID\" asc; ";*/

            string query = "select * From getcollectorname('ref1'); fetch all from \"ref1\";";
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
