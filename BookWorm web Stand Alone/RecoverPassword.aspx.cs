using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient; 

public partial class RecoverPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Set events for the submit button 
            SubmitImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/SubmitDefault.png'");
            SubmitImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/SubmitMouseOver.png'");

            BackImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/BackArrowMouseOver.jpg'");
            BackImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/BackArrowDefault.jpg'");

            //Databind the dropdownlist with the security question 
             //Start a new instance of the class contains the list and store it in an arraylist
            ArrayCollections GetList = new ArrayCollections();
            ArrayList Questions = GetList.SecurityQuestions();

             //Databind the arraylist to the drop down list
            SecurityQuestionDdl.DataSource = Questions;
            SecurityQuestionDdl.DataBind();
        }


        if (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] == "true")
        {
            LoginPanel1.Visible = false;
            BackImgBtn.PostBackUrl = "Account.aspx";
        }
        else
        {
            FeaturedSidePanelLeft1.Visible = false;
            BackImgBtn.PostBackUrl = "Register.aspx";
        }
    }
    protected void SubmitImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        //This code updates the password of the user 
         //Open a connection to the database
        UseDataBase usedb = new UseDataBase();
        usedb.ConnectDataBase();

         //Query the database to see if the record exists using the information provided by the user
        SqlDataReader userInfoReader = usedb.ExecuteQuery("SELECT * FROM [UserInformation] WHERE [UserEmail] = '" + EmailTxtb.Text.Replace("'", "") + "' AND [UserQuestion] = '" + SecurityQuestionDdl.SelectedValue.ToString() + "' AND [UserAnswer] = '" + AnswerTxtb.Text.Replace("'", "") + "'");

        if(userInfoReader != null && userInfoReader.HasRows)
        {
            //Close the datareader
            userInfoReader.Close();
            //Update the password of the user based on the information provided by the user 
            usedb.ExecuteCommand("UPDATE [UserInformation] SET [UserPassword] = '" + NewPasswordTxtb.Text.Replace("'", "") + "' WHERE [UserEmail] = '" + EmailTxtb.Text.Replace("'", "") + "' AND [UserQuestion] = '" + SecurityQuestionDdl.SelectedValue.ToString() + "' AND [UserAnswer] = '" + AnswerTxtb.Text.Replace("'", "") + "'"); 

            //Indicate success
            ReportBackLble.Text = "Your password has successfully been updated";
        }
        else
        {
            //Close the datareader 
            userInfoReader.Close();

            //Idicate the record does not exist
            ReportBackLble.Text = "The Email/Security question or answer is not correct.";
        }
    }
}