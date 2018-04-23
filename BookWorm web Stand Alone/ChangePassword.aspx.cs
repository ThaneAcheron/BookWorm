using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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
        //Check to see if the oldpassword matches the password in the database 
        UseDataBase usedb = new UseDataBase();
        usedb.ConnectDataBase();

        //Query the database to see if the password the user entered was correct 
        SqlDataReader sqlReader = usedb.ExecuteQuery("SELECT [UserPassword] FROM [UserInformation] WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "' AND [UserPassword] = '" + OldPassTxtb.Text.Replace("'", "") + "'");

        if (sqlReader != null && sqlReader.HasRows)
        {
            //Close the dataReader 
            sqlReader.Close();
            //Retreive the query result
            bool result = usedb.ExecuteCommand("UPDATE [UserInformation] SET [UserPassword] = '" + NewPassTxtb.Text.Replace("'", "") + "' WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'"); 
            
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
            sqlReader.Close();
            OldPassWarningLble.Text = "Incorrect password";
        }

        //Close the connection to the database
        usedb.Close();
    }
}