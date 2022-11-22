using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using APISTUDENT.Core;
using APISTUDENT.Models.Interface;
namespace APISTUDENT.Models
{
    public class SQLHelperRepository:SqlConfig,ISqlHelpernterface
    {
        public DataSet SqlCommander(Employee emp,string action)
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
                mySqlDataAdapter.Fill(myDataSet);
                sqlCon.Close();
            }
        
            return myDataSet;
        }
    }
}