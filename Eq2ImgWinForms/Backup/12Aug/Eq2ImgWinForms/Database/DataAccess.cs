using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Astrila.Eq2ImgWinForms.Database
{
    public class DataAccess
    {

        // private static string Path = System.IO.Directory.GetParent(Application.StartupPath).ToString(); 
        public static readonly string connection = "Data Source=trusoft;Initial Catalog=TestPaperEngine;Integrated Security=true;";

    }
    public class cc2
    {
        public void newCommand_ExecuteNonQuery(string sql, SqlConnection ccn)
        {
            try
            {
                if (ccn.State == ConnectionState.Closed) { ccn.Open(); }
                SqlCommand cmd = new SqlCommand(sql, ccn);

                cmd.ExecuteNonQuery();
            }
            catch { }
        }
        public double newCommand_ExecuteScaler(string sql, SqlConnection ccn)
        {
            try
            {
                if (ccn.State == ConnectionState.Closed) { ccn.Open(); }
                SqlCommand cmd = new SqlCommand(sql, ccn);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch { return 0; }
        }
        public string newCommand_ExecuteScaler_string(string sql, SqlConnection ccn)
        {
            try
            {
                if (ccn.State == ConnectionState.Closed) { ccn.Open(); }
                SqlCommand cmd = new SqlCommand(sql, ccn);
                return cmd.ExecuteScalar().ToString();
            }
            catch { return ""; }
        }
        public DataTable newCommand_Dataadapter(string sql, SqlConnection ccn)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ccn.State == ConnectionState.Closed) { ccn.Open(); }
                SqlDataAdapter cmd = new SqlDataAdapter(sql, ccn);
                cmd.Fill(dt);
                return dt;
            }
            catch { return dt; }
        }
        public void newCommand_DELETE(string sql, SqlConnection ccn)
        {
            try
            {
                if (ccn.State == ConnectionState.Closed) { ccn.Open(); }
                SqlCommand cmd = new SqlCommand(sql, ccn);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        public bool newCommand_ExecuteScaler_bool(string SQL, SqlConnection con)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand(SQL, con);
                return Convert.ToBoolean(cmd.ExecuteScalar().ToString());
            }
            catch { return false; }
        }
    }
}
