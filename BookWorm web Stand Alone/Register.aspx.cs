using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Set the events for the image button
            SubmitImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/SubmitDefault.png'");
            SubmitImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/SubmitMouseOver.png'");

            //Databind the security question drop downlist to an arraylist 
             //Start an instance of the class that contains the security questions 
            ArrayCollections getList = new ArrayCollections();
            ArrayList SecurityQuestions = getList.SecurityQuestions(); 

             //Set the datasource and databind the control 
            SecurityDdl.DataSource = SecurityQuestions;
            SecurityDdl.DataBind();

        }
    }
    protected void SubmitImgBtn_Click(object sender, ImageClickEventArgs e)
    {
         //This code inserts a new record of user details into the UserInformation table in the database
         //Open a connection to the database
        UseDataBase insertUser = new UseDataBase();
        insertUser.ConnectDataBase();
         
         //Insert the new record details
        bool result = insertUser.ExecuteCommand("INSERT INTO [UserInformation] (UserName , UserEmail , UserPassword , UserQuestion , UserAnswer) VALUES ('" + UsernameTxtb.Text.Replace("'", "") + "','" + EmailTxtb.Text.Replace("'", "") + "','" + PasswordTxtb.Text.Replace("'", "") + "','" + SecurityDdl.SelectedValue.ToString() + "','" + SecurityTxtb.Text.Replace("'", "") + "')");

        //Display a report back message weather the account was sucessfully created or not
        if (result == true)
        {
            ReportBackLble.Text = "Your account was sucessfully created, enter your new login details in the login bar.";
        }
        else
        {
            ReportBackLble.Text = "Your account was not sucessfully created, please try again.";
        }

         //Close the connection to the database
        insertUser.Close();
    }
}