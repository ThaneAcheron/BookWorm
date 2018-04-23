using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using BookWormService;

/// <summary>
/// Filename: Account.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class provides the visual logic and acess to the webservice database wich allows the user to edit thier account credentails 
/// </summary>
/// 
public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check to see if the user is logged in else redirect them to the login page
        if (Request.Cookies["LoggedInCookie"] == null || (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] != "true"))
        {
            Response.Redirect("Register.aspx");
        }



        if (!IsPostBack)
        {
            //Set the button events
            logoutImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/LogoutMouseOver.png'");
            logoutImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/LogOutDefault.png'");

            PasswordImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/ChangePasswordMouseOver.jpg'");
            PasswordImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/ChangePasswordDefault.jpg'");

            SubmitImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/SubmitABookMouseOver.jpg'");
            SubmitImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/SubmitABookDefault.jpg'");

            UpdateBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/UpdateMouseOver.png'");
            UpdateBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/UpdateDefault.png'");

            RecoverPassImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/RecoverPasswordMouseOver.jpg'");
            RecoverPassImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/RecoverPasswordDefault.jpg'"); 

            //Databind the security question  to the drop down list
            //Create a new instance of the class containing the list of security questions: /App_code/ArrayCollections.cs
            ArrayList SecurityQuestionsList = new ArrayList();
            ArrayCollections getlist = new ArrayCollections();
            SecurityQuestionsList = getlist.SecurityQuestions();

            //Set as the datasource 
            SecurityQuestionDdl.DataSource = SecurityQuestionsList;

            //DataBind
            SecurityQuestionDdl.DataBind();

            //Set the textbox values to the userInfo from the database/Check to see the update report
             //Once a new instance of the service 
            Service BookWormService = new Service();             

            //Query against the database and store the dataset as a dataReader 
            DataTableReader UserInfo = BookWormService.ExecuteQuery("SELECT [UserName],[UserPassword],[UserEmail],[UserAnswer],[UserQuestion] FROM [UserInformation] WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"].ToString() + "'").CreateDataReader(); 

            //Read from the dataset and apply the values to the lables
            while (UserInfo.Read())
            {
                UserNameTxtb.Text = UserInfo.GetString(0);
                UserNameHeaderLble.Text = UserInfo.GetString(0);
                EmailTxtb.Text = UserInfo.GetString(2);
                SecurityAnswerTxtb.Text = UserInfo.GetString(3);
                SecurityQuestionDdl.SelectedValue = UserInfo.GetString(4);
            }

            //Set the gridView to select all books containig the users Id 
            SubmittedGV.DataSource = BookWormService.ExecuteQuery("SELECT [BookImageUrl] , [BookId] , [BookName] FROM [BookInformation] WHERE [BookSubmiterId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'");
            SubmittedGV.DataBind(); 

            //Close the connection to the database 
            UserInfo.Close();

            //Clear the resources 
            BookWormService.Dispose(); 
        }

            // disply the report if the user has tried to update thier profile 
             if (Session["UpDateReport"] != null)
             {
                 //Make sure no values are carried over 
                 UpdateReportLble.Text = "";

                 if (Session["UpDateReport"].ToString() == "True")
                 {
                     UpdateReportLble.Text = "Update Successful!";
                 }
                 else
                 {
                     UpdateReportLble.Text = "Something went wrong, try again in a few minuttes.";
                 }
             }

            //Make sure no values are carried over 
             Session["UpDateReport"] = null; 
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set the selected datakey to a session variable
        Session["BookId"] = SubmittedGV.SelectedDataKey.Value.ToString();
        Response.Redirect("BookDetails.aspx");
    }
    protected void SubmitImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SubmitBook.aspx");
    }
    protected void UpdateBtn_Click(object sender, ImageClickEventArgs e)
    {
        //This code updates the sql database based on the users input on the textboxs against the database on the web service
         //Create a new instance of the web service 
        Service update = new Service(); 

        //Update the database on the webservice with the new account credintials 
        Session["UpDateReport"] = update.ExecuteCommand("UPDATE [UserInformation] SET [UserName] = '" + UserNameTxtb.Text.Replace("'", "") + "', [UserEmail] = '" + this.EmailTxtb.Text.Replace("'", "") + "' ,[UserQuestion] = '" + this.SecurityQuestionDdl.Text.Replace("'", "") + "' ,[UserAnswer] = '" + this.SecurityAnswerTxtb.Text.Replace("'", "") + "' WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'");
     
        //Close the database
       update.Dispose();

        //Refresh the page
       Response.Redirect("Account.aspx");
    }
    protected void logoutImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Check to see if the LoggedInCookie has a value
        if (Request.Cookies["LoggedInCookie"]["LoggedIn"] != null)
        {
            //Set loggedIn to false
            HttpCookie loggedInCookie = new HttpCookie("LoggedInCookie");
            loggedInCookie["LoggedIn"] = "false";
            Response.SetCookie(loggedInCookie);
            //Redirect to home page
            Response.Redirect("BookWormHome.aspx");
        }
    }
}