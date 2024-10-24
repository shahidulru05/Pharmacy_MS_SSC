using System;
using System.Data;
using System.Data.SqlClient;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC.Common
{
    public class Db
    {
        // SQL connection
        private static string _databaseName = "PHARMACY_MS_SSC";
        private static string _userId = "sa";
        private static string _password = "bkbabu";
        private static string _connectionString = @"Data Source=" + GlobalSettings.Server +
                                                           "; Initial Catalog=" + _databaseName +
                                                           "; User ID=" + _userId +
                                                           "; Password=" + _password + "";

        private static SqlConnection conn = new SqlConnection(_connectionString);
        private static SqlCommand cmd = new SqlCommand("", conn);
        private static SqlDataReader dr;
        private static SqlDataAdapter da;
        private static DataTable dt;

        //Method

        public static bool HasExisted(string query)
        {
            GetConnection();
            cmd.CommandText = query;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count>0;
        }

        public static void GetConnection()
        {
            CloseConnection();
            conn.Open();
        }

        public static void CloseConnection()
        {
            if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
            {
                conn.Close();
            }
        }

        public static bool QueryExecute(string query)
        {
            GetConnection();
            cmd.CommandText = query;
            return cmd.ExecuteNonQuery() > 0;
        }

        public static SqlDataReader GetDataReader(string query)
        {
            GetConnection();

            try
            {
                dr.Close();
            }
            catch {}

            cmd.CommandText = query;
            dr = cmd.ExecuteReader();
            return dr;
        }

        public static DataTable GetDataTable(string query)
        {
            GetConnection();
            cmd.CommandText = query;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataSet GetDataSet(string query)
        {
            GetConnection();
            cmd.CommandText = query;
            da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static string GenerateInvoice(string firstInvString, int startInvNum, int increment, string dbTblName, string tblIdFieldName, string tblInvFieldName)
        {
            try
            {
                GetConnection();
                var year = Settings.Default.CURRENT_PERIOD;
                string defaultInvoice = firstInvString + year + startInvNum;

                var cmd = new SqlCommand("SELECT " + tblInvFieldName + " AS INV FROM " + dbTblName + " WHERE " + tblIdFieldName + " = (SELECT MAX(" + tblIdFieldName + ") AS ID FROM " + dbTblName + ")", conn);
                var dr = cmd.ExecuteReader();
                if (dr.Read() && !dr.IsDBNull(0))
                {
                    var db_invoice = dr["INV"].ToString();
                    var db_inv_year = db_invoice.Substring(firstInvString.Length, 4);
                    return Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                        ? defaultInvoice
                        : new AutoGenerateInvoice().Invoice(db_invoice, firstInvString + year, increment);
                }
                dr.Close();
                return defaultInvoice;
            }
            catch
            {
                return "";
            }
        }

    }
}
