using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Layouts_LoginPanel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide the ForgotPassImgBtn when the user is on the recoverpassword.aspx page since the button would redirect them to the same page
        if (this.Page.ToString() == "ASP.recoverpassword_aspx")
        {
            ForgotPassImgBtn.Visible = false;
        }

        //Set the events for the image buttons 
        if (!Page.IsPostBack)
        {
            LoginBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/LoginMouseOver.jpg'");
            LoginBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/LoginDefault.jpg'");

            ForgotPassImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/ForgotPasswordMouseOver.png'");
            ForgotPassImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/ForgotPasswordDefault.png'");
        }
    }
    protected void LoginBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Create a new instance of the database class
        UseDataBase useDb = new UseDataBase();

        //Structure a query
        string queryString = "SELECT * FROM [UserInformation] WHERE UserEmail = '";
        queryString += UserEmailTxtb.Text + "' AND UserPassword = '";
        queryString += PasswordTxtb.Text + "'; ";

        //Open a connect to the database
        useDb.ConnectDataBase();
        //Execute the query
        SqlDataReader sqlReader = useDb.ExecuteQuery(queryString);

        if (sqlReader != null && sqlReader.HasRows)
        {
            //Set up cookies if the userinformation exists. 

            HttpCookie loggedInCookie = new HttpCookie("LoggedInCookie");
            loggedInCookie["LoggedIn"] = "true";
            while (sqlReader.Read())
            {
                loggedInCookie["UserId"] = sqlReader.GetInt32(0).ToString();
            }

            //If the user wishes to be kept logged in then set the expiration date 
            if (KeepLoggedInChb.Checked == true) 
            {
                loggedInCookie.Expires = System.DateTime.Now.AddDays(7);
            }

            Response.Cookies.Add(loggedInCookie);
            Response.Redirect("Books.aspx");

        }
        else
        {
            //Display the error message. 
            ErrorLble.Visible = true;
        }

        sqlReader.Close();
        useDb.Close();
    }
}