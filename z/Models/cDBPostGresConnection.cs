using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartParkingBackend.Models
{
    public class cDBPostGresConnection
    {
        public string ConStr = string.Empty;
        NpgsqlConnection cn = new NpgsqlConnection();
        NpgsqlCommand cmd = null;
        NpgsqlDataAdapter ad = null;
        private readonly IConfiguration configuration;


        public cDBPostGresConnection()
        {
            ConStr = Startup.strcon;
            //configuration.GetConnectionString("DefaultConnection");
        }

        public DataSet getDataBy_SqlCommand_CB(NpgsqlCommand cmd)
        {
            cn = new NpgsqlConnection(ConStr);

            DataSet ds = new DataSet();
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.CommandTimeout = 100;
                cmd.Connection = cn;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cmd.Dispose();
            }
        }
    }
}
