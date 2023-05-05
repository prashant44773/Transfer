using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UserMaster.Models
{
    public class UserMast
    {
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;

        public int intUserID { get; set; }
        /*[StringLength(15, ErrorMessage = "Must be between 4 to 15 Characters", MinimumLength = 4)]
        [Required(ErrorMessage = "User Name is Required")]*/
        public string strUserName { get; set; }
        /*[Required(ErrorMessage = "User Type is Required")]*/
        public int intUserTypeID { get; set; }
        /*[Required(ErrorMessage = "Email Id is Required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+[.]{1}[a-zA-Z0-9]{2,5}$", ErrorMessage = "Must be a valid email")]*/
        public string strEmail { get; set; }

        public string strUserType { get; set; }
        /*[Required(ErrorMessage = "Full Name")]*/
        public string strFullName { get; set; }

        /*[Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]*/
        public string strPassword { get; set; }
        /*[Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(13, ErrorMessage = "Must be 10 or 13 characters", MinimumLength = 10)]
        [Range(1, 9999999999999, ErrorMessage = "Mobile number must be positive number")]*/
        public string strMobileNo { get; set; }
        /*[Required(ErrorMessage = "Agency Name is Required")]*/
        public int intAgencyID { get; set; }


        public string strAgencyName { get; set; }

        public int intRoleID { get; set; }

        /*[Required(ErrorMessage = "RoleName")]*/
        public string strRoleName { get; set; }

/*        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }

        // Temporary Solution
        int UserID = 124;


        public List<UserMast> UserShow()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM readuser('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<UserMast> list = Common.converttolist<UserMast>(dt);
            return list;
        }


        public int AddUser(UserMast usermodel)
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string strEncryptedPassword = Common.ComputeSha256Hash(usermodel.strPassword);
            string query = "select * from createuser( " + "'" + usermodel.strUserName + "'" +
                                                      "," + "'" + usermodel.strEmail + "'" +
                                                       "," + "'" + usermodel.strMobileNo + "'" +
                                                       "," + "'" + usermodel.strPassword + "'" +
                                                          "," + "'" + strEncryptedPassword + "'" +
                                                       "," + usermodel.intAgencyID +
                                                        "," + usermodel.intUserTypeID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createuser"]);
            return response;
        }


        public int UpdateUser(UserMast usermodel)
        {
            Db Common = new Db();
            
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string strEncryptedPassword = Common.ComputeSha256Hash(usermodel.strPassword);
            string query = "select * from updateuser( " + usermodel.intUserID + "," + "'" + usermodel.strUserName + "'" +
                                                      "," + "'" + usermodel.strEmail + "'" +
                                                       "," + "'" + usermodel.strMobileNo + "'" +
                                                       "," + "'" + usermodel.strPassword + "'" +
                                                          "," + "'" + strEncryptedPassword + "'" +
                                                       "," + usermodel.intAgencyID +
                                                        "," + usermodel.intUserTypeID + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updateuser"]);
            return response;
        }


        public int DeleteUser(UserMast usermodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "select * from deleteuser( " + usermodel.intUserID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deleteuser"]);
            return response;
        }


        public int InActivateUser(UserMast usermodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from activationuser( " + usermodel.intUserID + "); ";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationuser"]);
            return response;
        }


        public List<UserMast> GetAgencyNames()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM getagencyname('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<UserMast> list = Common.converttolist<UserMast>(dt);
            return list;
        }


        public List<UserMast> GetUserTypeNames()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM getusertypename('show'," + UserID + ");FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<UserMast> list = Common.converttolist<UserMast>(dt);
            return list;
        }

    }
}
