using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Filename: UseDatBase.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class is used to establish a connection to the database, methods include writing and gathering results from the database
/// </summary>
public class UseDataBase
{
        SqlConnection sqlConn;
 
		//Open a Connection to the database
        public void ConnectDataBase()
        {
           sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookWormConnectionString"].ConnectionString);
           sqlConn.Open();
        }

        //Close the Connection to the database
        public void Close() 
        {
                 sqlConn.Close();
        }

		//Method to execute a query with no result 
        public bool ExecuteCommand (String query)
        {
           try
            {
            SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteReader();
                //Indicate Success
                return true;
           }
           catch (SqlException)
           {
                //Indicate Failure
               return false;
           }

        }

       //Method used to return a value (if any) 
        public SqlDataReader ExecuteQuery (string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.CommandText = query; 
                return cmd.ExecuteReader();
            }
            catch (SqlException)
            {
                return null;
            }
        }

      //Method used to count the Rows in the database 
    public int RecordNumber (string query)
        {
            //Variable to count the number of records
            int numberOfRecords = 0;

            SqlCommand cmd = new SqlCommand(query, sqlConn);
            SqlDataReader Datareader = cmd.ExecuteReader();
            while (Datareader.Read())
            {
                numberOfRecords = numberOfRecords + 1;
            }
            Datareader.Close();
            return numberOfRecords;
        }
}