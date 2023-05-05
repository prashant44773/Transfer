using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace CityMaster.Models
{
    public class City
    {
        #region Declaration
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;

        public int intCityID { get; set; }
        /*[StringLength(25, ErrorMessage = "Must be between 4 to 25 Characters", MinimumLength = 4)]
        [Required(ErrorMessage = "City Name is Required")]*/
        public string strCityName { get; set; }

        /*[Required(ErrorMessage = "Address is Required")]*/
        public string strAddress { get; set; }

        /*        [StringLength(25, ErrorMessage = "Must be between 2 to 25 Characters", MinimumLength = 2)]
                [Required(ErrorMessage = "Manager Name is Required")]*/
        public string strManagerName { get; set; }

        public string strRemarks { get; set; }

        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/

        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }
        #endregion

        public List<City> CityShow()
        {
            Db Common = new Db();

            MethodBase methodname = MethodBase.GetCurrentMethod();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM readcitymaster('show');FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<City> citylist = Common.converttolist<City>(dt);
            return citylist;
        }

        public int UpdateCity(City citymodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from updatecitymaster(" + citymodel.intCityID + "," +
                                                            "'" + citymodel.strCityName + "'" + "," +
                                                             "'" + citymodel.strAddress + "'" + "," +
                                                              "'" + citymodel.strManagerName + "'" + "," +
                                                               "'" + citymodel.strRemarks + "'" +
                                                            ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updatecitymaster"]);
            return response;
        }


        public int DeleteCity(City citymodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from deletecitymaster(" + citymodel.intCityID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deletecitymaster"]);
            return response;
        }

        public int AddCity(City citymodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createcitymaster(" + "'" + citymodel.strCityName + "'" + "," +
                                                             "'" + citymodel.strAddress + "'" + "," +
                                                              "'" + citymodel.strManagerName + "'" + "," +
                                                               "'" + citymodel.strRemarks + "'" + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createcitymaster"]);
            return response;
        }


        public int InActivateCity(City citymodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from activationcity(" + citymodel.intCityID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationcity"]);
            return response;
        }
    } 
}
