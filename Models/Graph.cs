using Npgsql;
using SmartParkingBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GraphModel.Models
{
    public class Graph
    {
        public int intAdvanceAmount { get; set; }
        public string dteVehicleOutTime { get; set; }
        public int intTotalFareAmount { get; set; }
        public int twoinflag { get; set; }
        public int twooutflag { get; set; }

        // Temporary ID
        int UserID = 124;

        public DataTable GetCollectionGraphData(int Lotid, int Areaid, string fromdate, string todate)
        {
            DataTable dt;
            cDBPostGresConnection objPostConnection;
            NpgsqlCommand pscmd;
            dt = new DataTable();
            objPostConnection = new cDBPostGresConnection();
            string query = "SELECT FROM collectiongraphdata('ref'," + UserID + "," + Areaid + "," + Lotid + ",'" + fromdate
                            + "','" + todate + "');FETCH ALL FROM \"ref\";";
            //string query = "SELECT FROM collectiongraphdata('ref'," + SessionWrapper.UserID + "," + Areaid + "," + Lotid + ",'" + Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")
            //                + "','" + Convert.ToDateTime(todate).ToString("yyyy-MM-dd") + "');FETCH ALL FROM \"ref\";";
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[0];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            return dt;
        }

        public DataTable GetInOutGraphData(int Lotid, int Areaid, string fromdate, string todate)
        {
            DataTable dt;
            cDBPostGresConnection objPostConnection;
            NpgsqlCommand pscmd;
            dt = new DataTable();
            objPostConnection = new cDBPostGresConnection();
            /*string query = "SELECT FROM inoutgraphdata('ref'," + UserID + "," + Areaid + "," + Lotid + ",'" + fromdate
                            + "','" + todate + "');FETCH ALL FROM \"ref\";";*/
            //string query = "SELECT FROM inoutgraphdata('ref'," + SessionWrapper.UserID + "," + Areaid + "," + Lotid + ",'" + Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")
            //                + "','" + Convert.ToDateTime(todate).ToString("yyyy-MM-dd") + "');FETCH ALL FROM \"ref\";";

            string query = "select inoutgraphdata('ref1',124,0,0,'03-05-2023','03-05-2023');fetch all from \"ref1\";";

            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            dt = objPostConnection.getDataBy_SqlCommand_CB(pscmd).Tables[1];
            objPostConnection = null;
            pscmd.Parameters.Clear();
            return dt;
        }
        public DataSet GetOccupancyGraphData(int Lotid, int Areaid, string fromdate, string todate)
        {
            DataTable dt;
            DataTable dt1;
            DataSet ds;
            cDBPostGresConnection objPostConnection;
            NpgsqlCommand pscmd;
            dt = new DataTable();
            dt1 = new DataTable();
            ds = new DataSet();
            objPostConnection = new cDBPostGresConnection();
            string query = "SELECT FROM occupancygraphdatatest3('ref1','ref2'," + UserID + "," + Areaid + "," + Lotid + ",'" + fromdate
                            + "','" + todate + "');FETCH ALL FROM \"ref1\";FETCH ALL FROM \"ref2\";";
            //string query = "SELECT FROM occupancygraphdatatest3('ref1','ref2'," + SessionWrapper.UserID + "," + Areaid + "," + Lotid + ",'" + Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")
            //                + "','" + Convert.ToDateTime(todate).ToString("yyyy-MM-dd") + "');FETCH ALL FROM \"ref1\";FETCH ALL FROM \"ref2\";";
            pscmd = new NpgsqlCommand(query);
            pscmd.CommandTimeout = 10;
            ds = objPostConnection.getDataBy_SqlCommand_CB(pscmd);
            objPostConnection = null;
            pscmd.Parameters.Clear();
            //ds.Tables.Add(dt);
            //ds.Tables.Add(dt1);
            return ds;
        }
    }
}

