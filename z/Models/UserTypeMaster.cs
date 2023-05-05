using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UserTypeMaster.Models
{
    public class UserType
    {
        private cDBPostGresConnection objPostConnection;
        private NpgsqlCommand pscmd;
        private DataTable dt;


        public int intUserTypeID { get; set; }
        /*[StringLength(15, ErrorMessage = "Must be between 4 to 15 Characters", MinimumLength = 4)]
        [Required(ErrorMessage = "User Type is Required")]*/
        public string strUserType { get; set; }

        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime dteModifiedOn { get; set; }

        /*[Required(ErrorMessage = "Active")]*/
        public bool? bActive { get; set; }

        /*[Required(ErrorMessage = "Delete")]*/
        public bool? bDeleted { get; set; }

        /*[Required]*/
        public bool? bAllowforWeb { get; set; }


        public Boolean bAllowModifications { get; set; }


        public List<UserType> UserTypeShow()
        {
            Db Common = new Db();

            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();
            string query = "SELECT FROM readusertype('show');FETCH ALL FROM  \"show\";";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            List<UserType> list = Common.converttolist<UserType>(dt);
            return list;
        }


        public int AddUserType(UserType usertypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from createusertype(" + "'" + usertypemodel.strUserType + "'" + "," + usertypemodel.bAllowModifications + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["createusertype"]);
            return response;
        }

        public int UpdateUserType(UserType usertypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from updateusertype(" + usertypemodel.intUserTypeID + "," + "'" + usertypemodel.strUserType + "'" + "," + usertypemodel.bAllowModifications + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["updateusertype"]);
            return response;
        }


        public int DeleteUserType(UserType usertypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from deleteusertype(" + usertypemodel.intUserTypeID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["deleteusertype"]);
            return response;
        }


        public int InActivateUserType(UserType usertypemodel)
        {
            objPostConnection = new cDBPostGresConnection();
            pscmd = new NpgsqlCommand();

            string query = "select * from activationusertype(" + usertypemodel.intUserTypeID + ");";
            dt = new DataTable();
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            pscmd.Dispose();
            int response = Convert.ToInt32(dt.Rows[0]["activationusertype"]);
            return response;
        }   
    }

      
}
