using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; 
using System.Data.SqlClient;

/// <summary>
/// Filename: CalculateAndStore.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the logic for calulating a new average (Users total score / Number of users that scored) and stores 
/// the new average into the database>[UserInformation]&[BookInformation] 
/// </summary>
public class CalculateAndStore
{
	public CalculateAndStore()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void CalculateAndStoreAverage(int UserScore, string BookId, string UserId)
    {
        //Used to store the current average rating of the book
        int AverageRating = 0;
        int NumberOfRates = 0;
        int NewRating = 0;

        //Connect to the database 
        UseDataBase usedb = new UseDataBase();
        usedb.ConnectDataBase();

        //Retreive the number of people who have rated the book 
        NumberOfRates = usedb.RecordNumber("SELECT * FROM [RatingInformation] WHERE [BookId] = '" + BookId.ToString() + "'") + 1;

        //Retrive the users ratings
        DataSet RatingsRead = usedb.ExecuteQuery("SELECT [Rating] FROM [RatingInformation] WHERE BookId = '" + BookId.ToString() + "'");

        //Convert the dataSet to a DataReader
        DataTableReader sqlReader = RatingsRead.CreateDataReader();

        if (sqlReader.HasRows)
        {
            //This variable is used to increment the loop
            int increment = 0;
            while (sqlReader.Read())
            {
                //Store the average rating    
                AverageRating = AverageRating + sqlReader.GetInt32(increment);
                increment = increment++;
            }
        }

        //Close the DataReader
        sqlReader.Close();

        //Calculate the new average using the old average plus the new user average devided by the number of people who have scored this book
        AverageRating = AverageRating + UserScore;
        NewRating = AverageRating / NumberOfRates;

        //Store the new average in the BookInformation table 
        usedb.ExecuteCommand("UPDATE [BookInformation] SET [BookAverageRating] = '" + NewRating + "' WHERE [BookId] = " + BookId.ToString());

        //Close the database 
        usedb.Close();

        //Open a new connection 
        UseDataBase storeRating = new UseDataBase();
        storeRating.ConnectDataBase();

        //Store the UsersScore in the RatingInformation table 
        storeRating.ExecuteCommand("INSERT INTO [RatingInformation] ([BookId],[UserId],[Rating]) VALUES ('" + BookId.ToString() + "','" + UserId.ToString() + "','" + UserScore.ToString() + "');");

        //Close the connection 
        storeRating.Close();
    }
}