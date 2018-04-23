using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BookWormService; //NameSpace of the webservice 

/// <summary>
/// Filename: ChangePassword.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the visul logic for acessing the webservice database and editing the user password 
/// </summary>
public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //Make sure the user is logged in
            if (Request.Cookies["LoggedInCookie"] == null || (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] != "true"))
            {
                Response.Redirect("Register.aspx");
            }

            //Apply events 
            UpdateImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/UpdateMouseOver.png'");
            UpdateImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/UpdateDefault.png'");

            BackImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/BackArrowMouseOver.jpg'");
            BackImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/BackArrowDefault.jpg'");
           
        }
    }
    protected void UpdateImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Check to see if the oldpassword matches the password in the database on the webservice 
        Service BookWormService = new Service(); 

        //Query the database to see if the password the user entered was correct 
        DataTableReader PasswordDataReader = BookWormService.ExecuteQuery("SELECT [UserPassword] FROM [UserInformation] WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "' AND [UserPassword] = '" + OldPassTxtb.Text.Replace("'", "") + "'").CreateDataReader();

        if (PasswordDataReader != null && PasswordDataReader.HasRows)
        {
            //Close the dataReader 
            PasswordDataReader.Close();
            //Retreive the query result
            bool result = BookWormService.ExecuteCommand("UPDATE [UserInformation] SET [UserPassword] = '" + NewPassTxtb.Text.Replace("'", "") + "' WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'"); 
            
            //Display a message weather the query executed successfully or not 
            if (result == true)
            {
                UpdateResultLble.Text = "Your password has been updated";
            }
            else
            {
                UpdateResultLble.Text = "Something went wrong, try again in a few minuttes";
            }
            
            //Make sure no values are carried over 
            OldPassWarningLble.Text = "";
        }
        else
        {
            //The password was incorrect, display a message to the user and close the DataReader
            PasswordDataReader.Close();
            OldPassWarningLble.Text = "Incorrect password";
        }

        //Close the connection to the database
        BookWormService.Dispose(); 

    }
}