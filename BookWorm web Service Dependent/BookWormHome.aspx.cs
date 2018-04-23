using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
using BookWormService; //Namespace of the webservice 

/// <summary>
/// Filename: BookWormHome.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the visual logic for the homepage
/// </summary>
 
public partial class BookWormDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!Page.IsPostBack)
        {
            //Add Events to the image buttons 
            ConnectImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/ConnectWithUsMouseDown.jpg'");
            ConnectImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/ConnectWithUs.jpg'");

            UserIconImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/UserIconMouseOver.jpg'");
            UserIconImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/UserIconDefault.jpg'");

            LogOutImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/LogOutHomeMouseOver.jpg'");
            LogOutImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/LogOutHome.jpg'");
        }

        //Open a new instance of the service 
        Service BookWormService = new Service();      

        //Apply the number of records to the appropriate label
        BooksNumberLble.Text = BookWormService.RecordRecords("SELECT * FROM BookInformation").ToString(); 
        //Count the number of UserRecords ref. db_Bookworm_data>>UserInformation table. 
        UsersNumberLble.Text = BookWormService.RecordRecords("SELECT * FROM UserInformation").ToString(); 

        //Check to see if the user is logged in and show the appropriate controls
        if (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] == "true")
        {
           
            ConnectImgBtn.Visible = false;
            UserIconImgBtn.Visible = true;
            LogOutImgBtn.Visible = true;

            //Get and set UserName to the UserNameLble    
            //Query the database
            DataSet userNameData = BookWormService.ExecuteQuery("SELECT [UserName] FROM [UserInformation] WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'"); 

            //Convert the dataSet to a DataReader
            DataTableReader sqlReader = userNameData.CreateDataReader();

            //get the username
            while(sqlReader.Read())
            {
                WellcomeBackLble.Text = sqlReader.GetString(0);
            }

            //close the dataReader and show the username  
            sqlReader.Close();
            WellcomeBackLble.Visible = true;
        }
        else
        {
            //if the user is not logged in
            ConnectImgBtn.Visible = true;
            UserIconImgBtn.Visible = false;
            WellcomeBackLble.Visible = false;
        }
        //Dispose the Service
        BookWormService.Dispose(); 
    }
    protected void LogOutImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Check to see if the loggedInCookie has a value
        if (Request.Cookies["LoggedInCookie"]["LoggedIn"] != null)
        {
            //Set cookie to false
            HttpCookie loggedInCookie = new HttpCookie("LoggedInCookie");
            loggedInCookie["LoggedIn"] = "false";
            Response.SetCookie(loggedInCookie);
            //Refresh page
            Response.Redirect("BookWormHome.aspx");
        }
    }
}