using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lab_3.DAL
{
    class Database
    {

        public static SqlConnection GetConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["LAB_3"].ToString();
            return new SqlConnection(strCon);
        }
        public static DataTable GetDataBySQL(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCommand;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteSQL(string sql, params SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, GetConnection());
            sqlCommand.Parameters.AddRange(sqlParameters);
            sqlCommand.Connection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
            return result;
        }
    }
}
