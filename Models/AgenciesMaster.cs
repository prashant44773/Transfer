using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;

using System.Linq;
using System.Threading.Tasks;

namespace AgenciesMaster.Models
{
    public class Agency
    {
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;


        public int intAgencyID { get; set; }
        /*[StringLength(50, ErrorMessage = "Must be between 4 to 50 Characters", MinimumLength = 4)]
        [Required(ErrorMessage = "Agency Name is Required")]*/
        public string strAgencyName { get; set; }

        public int intParkingLotID { get; set; }

        /*[Required(ErrorMessage = "Parking Lot is Required")]*/
        public string strParkingLotName { get; set; }

        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"*//*, ApplyFormatInEditMode = true*//*)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }


        /*[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Contract Start Date is Required")]*/
        public DateTime? dteContractStartDate { get; set; }
        /*[Required(ErrorMessage = "Contract Start Date is Required")]*/
        public string strContractStartDate { get; set; }
        /*[Required(ErrorMessage = "Contract End Date is Required")]*/
        public string strContractEndDate { get; set; }


        /*[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        /*[Required(ErrorMessage = "Contract Start Date is Required")]*/
        public DateTime? dteContractEndDate { get; set; }

        /*[Required(ErrorMessage = "Mobile Number is Required")]
        [StringLength(13, ErrorMessage = "Must be 10 or 13 characters", MinimumLength = 10)]
        [Range(1, 9999999999999, ErrorMessage = "Mobile number must be positive number")]*/
        public string strMobileNo { get; set; }

        /*[Required(ErrorMessage = "Email Id is Required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+[.]{1}[a-zA-Z0-9]{2,5}$", ErrorMessage = "Must be a valid email")]*/
        public string strEmail { get; set; }


        public string strRemarks { get; set; }

        /*[Required(ErrorMessage = "Contact Person is Required")]*/
        public string strContactPersonName { get; set; }

        // Temporary
        int UserID = 124;


        public List<Agency> AgencyShow()
        {
            Db Common = new Db();
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            /*string query = "SELECT FROM readagencies('show'," + SessionWrapper.UserID + ");FETCH ALL FROM  \"show\";";*/
            string query = "SELECT FROM readagencies('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<Agency> agencylist = Common.converttolist<Agency>(dt);
            return agencylist;
        }

        public int AddAgency(Agency Agencymodel)
        {

            /*CommonGetName common = new CommonGetName();*/
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createagencies( " + "'" + Agencymodel.strAgencyName + "'" + "," +
                                                             "'" + Agencymodel.strContactPersonName + "'" + "," +
                                                             "'" + Agencymodel.strEmail + "'" + "," +
                                                              "'" + Agencymodel.strMobileNo + "'" + "," +
                                                               "'" + string.Format("{0:MM-dd-yyyy}", Agencymodel.dteContractStartDate) + "'" + "," +
                                                                "'" + string.Format("{0:MM-dd-yyyy}", Agencymodel.dteContractEndDate) + "'" + "," +
                                                              "'" + Agencymodel.strRemarks + "'" +
                                                            ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createagencies"]);
            return response;
        }


        public int UpdateAgency(Agency Agencymodel)
        {
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime ContractStartDate = DateTime.ParseExact(Agencymodel.strContractStartDate, "dd-MM-yyyy", culture);
            DateTime ContractEndDate = DateTime.ParseExact(Agencymodel.strContractEndDate, "dd-MM-yyyy", culture);
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from updateagencies( " + Agencymodel.intAgencyID + "," +
                                                           "'" + Agencymodel.strAgencyName + "'" + "," +
                                                            "'" + Agencymodel.strContactPersonName + "'" + "," +
                                                             "'" + Agencymodel.strEmail + "'" + "," +
                                                              "'" + Agencymodel.strMobileNo + "'" + "," +
                                                               "'" + string.Format("{0:yyyy-MM-dd}", ContractStartDate) + "'" + "," +
                                                                "'" + string.Format("{0:yyyy-MM-dd}", ContractEndDate) + "'" + "," +
                                                              "'" + Agencymodel.strRemarks + "'" +
                                                           "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updateagencies"]);
            return response;
        }


        public int DeleteAgency(Agency Agencymodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from deleteagencies( " + Agencymodel.intAgencyID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deleteagencies"]);
            return response;
        }


        public int InActivateAgency(Agency Agencymodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from activationagencies( " + Agencymodel.intAgencyID + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationagencies"]);
            return response;
        }
            
    }
}