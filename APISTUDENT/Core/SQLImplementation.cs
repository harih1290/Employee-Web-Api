using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using APISTUDENT.Core;
using APISTUDENT.Models;
namespace APISTUDENT.Core
{
    public class SQLImplementation:SqlConfig
    {
        public DataSet DynamicHelper(Employee emp, string action)
        {
            DataSet myDataSet = new DataSet();
            var jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(base.UnoConnStr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("EmployeeMeta", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@EmyDetails", SqlDbType.NVarChar).Value = jsondata;
                sql_cmnd.Parameters.AddWithValue("@Action", SqlDbType.NVarChar).Value = action;
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
                mySqlDataAdapter.SelectCommand = sql_cmnd;
                //DataSet myDataSet = new DataSet();
                sqlCon.Open();
                mySqlDataAdapter.Fill(myDataSet);
                sqlCon.Close();
            }

            return myDataSet;
        }
    }
}