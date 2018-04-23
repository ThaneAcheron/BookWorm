using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

/// <summary>
/// Filename: WriteToFile.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the logic for writing the user rating information to a log file contained within the projects directory. 
/// </summary>
public class WriteToFile
{
	public WriteToFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void WriteLine(string bookTitle, string bookAuthor, string userId, int userRating)
    {
        //String used to store the users email address 
        string userEmail = null;
        
        //Open a new instance of the database class to retrieve the user email 
        UseDataBase usedb = new UseDataBase();
        //Connect to the database
        usedb.ConnectDataBase(); 
        //Query the database and store the dataset as a DataReader
        DataTableReader EmailReader = usedb.ExecuteQuery("SELECT [UserEmail] FROM [UserInformation] WHERE [UserId] = '" + userId.ToString() + "'").CreateDataReader();
        while(EmailReader.Read())
        {
            //Store the user email address 
            userEmail = EmailReader.GetString(0);
        }
        
        //Instanate a new streamReader class to write the rating information to a log file 
        StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\log.txt", true);
        //Write to logfile 
        sw.WriteLine("User E-mail: " + userEmail + ", Book Title: " + bookTitle + ", Book Author: " + bookAuthor + ", Rating: " + userRating.ToString() + "%" + ", Date/Time: " + DateTime.Now.ToString());

        //Clear up all resources 
         //Close the stream reader
        sw.Close();
         //Close the connection to the database
        usedb.Close();
         //Close the dataReader 
        EmailReader.Close(); 
        
    }
}