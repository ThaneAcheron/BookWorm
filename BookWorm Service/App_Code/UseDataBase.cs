using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; //This is required to retrive the connection string

/// <summary>
/// Filename: UseDatBase.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class is used to establish a connection to the database, methods include writing, gathering and counting results from the database.
/// </summary>
public class UseDataBase
{
    SqlConnection sqlConn;

    //Open a Connection to the database
    public void ConnectDataBase()
    {
        //Use the connectionstring stored in the web.config
        sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookWormConnectionString"].ConnectionString);
        sqlConn.Open();
    }

    //Close the Connection to the database
    public void Close()
    {
        sqlConn.Close();
    }

    //Method to execute a query with no result 
    public bool ExecuteCommand(String query)
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
    public DataSet ExecuteQuery(string query)
    {
        try
        {
            // Creates a DataAdapter that queries the database.
            SqlDataAdapter adapter = new SqlDataAdapter(query,sqlConn);
            // Creates an empty DataSet.
            DataSet dset = new DataSet();
            // DataSet is filled with the data retrieved by the DataAdapter query.
            adapter.Fill(dset);
            return dset;
        }
        catch (SqlException)
        {
            //No results found return null DataSet
            return null;
        }
    }

    //Method used to count the Rows in the database 
    public int RecordNumber(string query)
    {
        //Variable to count the number of records
        int numberOfRecords = 0;

        //Set the query and connection information 
        SqlCommand cmd = new SqlCommand(query, sqlConn);
        //Execute the query with a datareader
        SqlDataReader Datareader = cmd.ExecuteReader();
        //Read the number of record in the datareader
        while (Datareader.Read())
        {
            numberOfRecords = numberOfRecords + 1;
        }
        //Close the DataReader
        Datareader.Close();
        //Return the number of records
        return numberOfRecords;
    }
}