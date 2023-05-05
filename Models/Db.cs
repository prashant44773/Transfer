using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace SmartParkingBackend.Models
{
    public class Db
    {

        private readonly IConfiguration configuration;
        private EmailConfig E = Startup.Ec;    

        public DataTable checkLogin(string email, string password)
        {
            try
            {
                DataTable dt;
                cDBPostGresConnection objPostConnection;
                NpgsqlCommand pscmd;
                dt = new DataTable();
                objPostConnection = new cDBPostGresConnection();
                pscmd = new NpgsqlCommand();
                string query = "SELECT FROM checkadmin_T('ref','" + email + "','" + password + "');FETCH ALL FROM ref";
                pscmd = new NpgsqlCommand(query);
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                objPostConnection = null;
                pscmd.Parameters.Clear();
                pscmd.Dispose();
                return dt;
            }

            catch (Exception e)
            {
                return null;
            }
        }
        public string SHA256Encrypt(string plainText)
        {
            try
            {
                string hash = "f0xle@rn";
                // Get the bytes of the string
                byte[] bytesToBeEncrypted = UTF8Encoding.UTF8.GetBytes(plainText);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripleDES.CreateEncryptor();
                        byte[] result = transform.TransformFinalBlock(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        var EncryptedText = Convert.ToBase64String(result, 0, result.Length);
                        return EncryptedText;
                    }
                }
            }
            catch (Exception e)
            {
               return null;
            }
        }
        public int ForgotPassword(string email, string encryptedEmail)
        {
            try
            {
                DataTable dt;
                cDBPostGresConnection objPostConnection;
                NpgsqlCommand pscmd;
                dt = new DataTable();
                objPostConnection = new cDBPostGresConnection();
                string query = "SELECT * FROM \"spForgotPassword\"('" + email + "','" + encryptedEmail + "');";
                pscmd = new NpgsqlCommand(query);
                pscmd.CommandTimeout = 10;
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                objPostConnection = null;
                pscmd.Parameters.Clear();
                int valid = Convert.ToInt16(dt.Rows[0]["spForgotPassword"]);
                return valid;
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        public int SendVerificationlinkEmail(string email, int otp)
        {
            try
            {
                
                MailMessage msg = new MailMessage();
                msg.Subject = "Reset Password";
                //msg.Body = $"Hello your recovery password is {otp}";

                msg.Body = "<h2 style='font-weight:bold;color:black;text-align:center;'> Hi, We got request for reset your account password. </h2>" +
                    "<br/><br/><center>" +
                    "<br/><br/><h3 style='font-weight:bold;color:red;text-align:center;'>" + otp + "</h3>" +
                    "<br/><h3 style='font-weight:bold;color:red;text-align:center;'>*Important Note: This Link will expire in 10 Minutes</h3>";
                msg.IsBodyHtml = true;
                string toaddress = email;
                msg.To.Add(toaddress);
                string fromaddress = E.FromEmail;
                msg.From = new MailAddress(fromaddress);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = E.strHost;
                smtp.Port = Convert.ToInt32(E.strPort);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(E.strUsername, E.strPassword);
                //smtp.Send(msg);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int Changepassword(string email, string newpassword)
        {
            
            string EncryptedPassword = SHA256Encrypt(newpassword);
            try
            {
                DataTable dt;
                cDBPostGresConnection objPostConnection;
                NpgsqlCommand pscmd;
                dt = new DataTable();
                objPostConnection = new cDBPostGresConnection();
                string query = $"UPDATE \"tblUsers\" SET \"strPassword\" = '{newpassword}' WHERE \"strEmail\" = '{email}';";
                pscmd = new NpgsqlCommand(query);
                pscmd.CommandTimeout = 10;
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                objPostConnection = null;
                pscmd.Parameters.Clear();
                int getResponse = Convert.ToInt32(dt.Rows[0]["changepassword"]);
                return getResponse;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public  List<T> converttolist<T>(DataTable dt)
        {
            
            
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception e)
            {
               return null;
            }
        }
        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo prop in temp.GetProperties())
                {
                    if (prop.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] != DBNull.Value)
                        {
                            prop.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        public void insertOtpinDB(string email, int otp)
        {

            {
                try
                {
                    DataTable dt;
                    cDBPostGresConnection objPostConnection;
                    NpgsqlCommand pscmd;
                    dt = new DataTable();
                    objPostConnection = new cDBPostGresConnection();
                    DateTime currDate = DateTime.Now;
                    string query = $"INSERT INTO tblOtp VALUES ('{email}',{otp},'{currDate}');";
                    pscmd = new NpgsqlCommand(query);
                    pscmd.CommandTimeout = 10;
                    dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                    objPostConnection = null;
                    pscmd.Parameters.Clear();
                    
                }
                catch (Exception e)
                {
                    
                }
            }
        }
        public bool checkOtpvalid(string email,int userOtp)
        {
            try
            {
                DataTable dt;
                cDBPostGresConnection objPostConnection;
                NpgsqlCommand pscmd;
                dt = new DataTable();
                objPostConnection = new cDBPostGresConnection();
                
                DateTime delayedTime = DateTime.Now.AddMinutes(-10);
                string query = $"SELECT * FROM tblOtp WHERE dt_generateddate >= '{delayedTime}' and str_email='{email}' and int_otp={userOtp};";
                pscmd = new NpgsqlCommand(query);
                pscmd.CommandTimeout = 10;
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                if (dt.Rows.Count != 0)
                    return true;
                objPostConnection = null;
                pscmd.Parameters.Clear();
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void deleteOtp(int userOtp)
        {
            try
            {
                DataTable dt;
                cDBPostGresConnection objPostConnection;
                NpgsqlCommand pscmd;
                dt = new DataTable();
                objPostConnection = new cDBPostGresConnection();

                DateTime delayedTime = DateTime.Now.AddMinutes(-10);
                string query = $"DELETE FROM tblOtp WHERE int_otp={userOtp};";
                pscmd = new NpgsqlCommand(query);
                pscmd.CommandTimeout = 10;
                dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
                
            }
            catch (Exception e)
            {
                
            }
        }

    }
}
