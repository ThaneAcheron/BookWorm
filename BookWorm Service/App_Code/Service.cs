using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data; 
using System.Data.SqlClient;

/// <summary>
/// Filename: Service.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class exposes the webservice methods, making them avaliable to clients. These methods are further dived up into
/// CaluclateAndStore.cs/UseDataBase.cs and WriteToFile.cs 
/// </summary>
/// 
[WebService(Namespace = "http://BookWormService.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    UseDataBase usedb = new UseDataBase();

    public Service () {
 
        //InitializeComponent(); 
    }

    [WebMethod]
    //For executing a command against the database, Bool result only 
    public bool ExecuteCommand(string query)
    {
        //Open a connection to the database 
        usedb.ConnectDataBase();
        //Execute the command 
        bool result = usedb.ExecuteCommand(query);
        usedb.Close(); 
        //return the result 
        return result; 
    }

    //For querying the database and returning a value(If any) 
    [WebMethod]
    public DataSet ExecuteQuery(string query)
    {
        usedb.ConnectDataBase();
        DataSet dset = usedb.ExecuteQuery(query); 
        usedb.Close();
        //Return the dataset 
        return dset;
    }

    //For recording the number of records 
    [WebMethod]
    public int RecordRecords(string query)
    {
        usedb.ConnectDataBase();
        //Return the number of records 
        return usedb.RecordNumber(query); 
    }

    //This method is used to Calculate and store the new average in to the ratings table and bookinformation table
    [WebMethod]
    public void CalculateAndStoreAverage (int UserScore, string BookId, string UserId)
    {
        //Calculate and store the average
         //Create a new instance of the class containing the logic 
        CalculateAndStore calculate = new CalculateAndStore(); 
         //Invoke the Calculate and store method 
        calculate.CalculateAndStoreAverage(UserScore, BookId,  UserId);
    }
    
    //This method writes new rating information to a logfile 
    [WebMethod]
    public void WriteToLogFile(string bookTitle, string bookAuthor, string UserId, int userRating)
    {
        WriteToFile WriteRating = new WriteToFile();
        WriteRating.WriteLine(bookTitle, bookAuthor, UserId, userRating);
    }
}
    