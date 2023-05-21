using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Data Access Layer

namespace Data_Access_Layer
{
    public class Data_Access
    {
        //Initialize Data
        SqlConnection conn;
        SqlCommand comn;
        SqlDataAdapter da;
        DataTable dt;

        //Constructor
        public Data_Access()
        {
            conn = new SqlConnection();
            comn = new SqlCommand();
            comn.Connection = conn;
            da = new SqlDataAdapter();
            da.SelectCommand = comn;
        }

        //Connecting to Database
        public void Link()
        {
            conn.ConnectionString = @"Data Source= DESKTOP-362PC89\SQLEXPRESS; Initial Catalog = GradeManagement; Integrated Security = True";
            conn.Open();
        }
        // Remove Connection from Database
        public void Unlink()
        {
            conn.Close();
        }

        //Datatable for SQL query
        public DataTable SelectData(string strsql)
        {
            comn.CommandText = strsql;
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // To execute query in business Layer
        public void ExecuteQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
