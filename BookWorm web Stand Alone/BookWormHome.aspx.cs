using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

public partial class BookWormDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region EventScript  

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
        //Count the number of BookRecords ref. db_Bookworm_data>>BookInformation table.
        UseDataBase usedb = new UseDataBase();
        usedb.ConnectDataBase();

        //Apply the number of records to the appropriate label
        BooksNumberLble.Text = usedb.RecordNumber("SELECT * FROM BookInformation").ToString(); 
        //Count the number of UserRecords ref. db_Bookworm_data>>UserInformation table. 
        UsersNumberLble.Text = usedb.RecordNumber("SELECT * FROM UserInformation").ToString(); 

        //Close the connection to the database 
        usedb.Close();
        #endregion 

        #region SidePanelLeftScript 

        //Check to see if the user is logged in and show the appropriate controls
        if (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] == "true")
        {
           
            ConnectImgBtn.Visible = false;
            UserIconImgBtn.Visible = true;
            LogOutImgBtn.Visible = true;

            //Get and set UserName to the UserNameLble 
            UseDataBase username = new UseDataBase();
            username.ConnectDataBase();

            //Query the database
            SqlDataReader getname = username.ExecuteQuery("SELECT [UserName] FROM [UserInformation] WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'"); 

            //get the username
            while(getname.Read())
            {
                WellcomeBackLble.Text = getname.GetString(0);
            }

            //Close the connection to the database and the dataReader
            getname.Close();
            username.Close();
            WellcomeBackLble.Visible = true;
        }
        else
        {
            //if the user is not logged in
            ConnectImgBtn.Visible = true;
            UserIconImgBtn.Visible = false;
            WellcomeBackLble.Visible = false;
        }
        
        #endregion 

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