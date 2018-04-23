using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BookWormService; //Name of the webservice 

/// <summary>
/// Filename: BookDetail.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the visual logic for displaying and acessing the book information from the webservice.
/// </summary>

public partial class BookDetails : System.Web.UI.Page
{
    #region VisualLogic  

    //Event used to load all the required infromation from the database to display the book details
    protected void Page_Load(object sender, EventArgs e)
    {
        //The following variable is used to store the userId from the BookInformation DataTable
        int userId = 0;

        //Check the cookies to see if the user is loggedin otherwise redirect to Register.aspx 
        if (Request.Cookies["LoggedInCookie"] == null || (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] != "true"))
        {
            Response.Redirect("Register.aspx");
        }

        //Check if the user has already rated the book if so; disable the stars to prevent the user from rating the book again
          //Create a connection to the service and query against the database 
        Service BookWormService = new Service();
        DataTableReader sqlReader = BookWormService.ExecuteQuery("SELECT * FROM [RatingInformation] WHERE [BookID] = '" + (string)Session["BookId"] + "' AND [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'").CreateDataReader();

        //Apply the appropriate values if the user has already scored the book 
        if(sqlReader.HasRows && sqlReader != null)
        {
            //Display a message that the user has already rated the book
            RateLble.Text = "You have already rated this book";

            //Disable the stars to prevent the user from rating the book again
            DisableStars();

            //display the value that the user scored the book on the stars
            while (sqlReader.Read())
            {
                SetStars(sqlReader.GetInt32(2));
            }
        }

        //Close the datareader
        sqlReader.Close();

         //Unfortunatly I'm including some javascript for the star animations (sorry about this but there's no mouseover events for asp.net) 
           //The below code executes the star animations based on the onmouseover/onmouseout events.
        if (!Page.IsPostBack)
        {
           //Star Animations 
            //StarOne
            StarOneBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/StarMouseOver.png'");
            StarOneBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/StarDefault.png'");

            //StarTwoBtn  
            StarTwoBtn.Attributes.Add("onmouseover", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarMouseOver.png'; this.src = 'Resources/Images/StarMouseOver.png'");
            StarTwoBtn.Attributes.Add("onmouseout", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarDefault.png'; this.src = 'Resources/Images/StarDefault.png'");

            //StarThreeBtn
            StarThreeBtn.Attributes.Add("onmouseover", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarMouseOver.png'; document.getElementById('StarTwoBtn').src = 'Resources/Images/StarMouseOver.png'; this.src = 'Resources/Images/StarMouseOver.png'");
            StarThreeBtn.Attributes.Add("onmouseout", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarDefault.png'; document.getElementById('StarTwoBtn').src = 'Resources/Images/StarDefault.png'; this.src = 'Resources/Images/StarDefault.png'");

            //StarFourBtn 
            StarFourBtn.Attributes.Add("onmouseover", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarMouseOver.png'; document.getElementById('StarTwoBtn').src = 'Resources/Images/StarMouseOver.png'; document.getElementById('StarThreeBtn').src = 'Resources/Images/StarMouseOver.png'; this.src = 'Resources/Images/StarMouseOver.png'");
            StarFourBtn.Attributes.Add("onmouseout", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarDefault.png'; document.getElementById('StarTwoBtn').src = 'Resources/Images/StarDefault.png'; document.getElementById('StarThreeBtn').src = 'Resources/Images/StarDefault.png'; this.src = 'Resources/Images/StarDefault.png'");

            //StarFiveBtn 
            StarFiveBtn.Attributes.Add("onmouseover", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarMouseOver.png'; document.getElementById('StarTwoBtn').src = 'Resources/Images/StarMouseOver.png'; document.getElementById('StarThreeBtn').src = 'Resources/Images/StarMouseOver.png'; document.getElementById('StarFourBtn').src = 'Resources/Images/StarMouseOver.png'; this.src = 'Resources/Images/StarMouseOver.png'");
            StarFiveBtn.Attributes.Add("onmouseout", "document.getElementById('StarOneBtn').src = 'Resources/Images/StarDefault.png'; document.getElementById('StarTwoBtn').src = 'Resources/Images/StarDefault.png'; document.getElementById('StarThreeBtn').src = 'Resources/Images/StarDefault.png'; document.getElementById('StarFourBtn').src = 'Resources/Images/StarDefault.png'; this.src = 'Resources/Images/StarDefault.png'");

            //MouseOver events for the other buttons 
            
            //GoBackBtn
            BackBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/ArrowBackMouseOver.jpg'");
            BackBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/ArrowBack.jpg'");

            //SubmitBtn 

            SubmitImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/SubmitMouseOver.png'");
            SubmitImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/SubmitDefault.png'");

        }

       //The following code sets the book details/lables to the appropriate values from the database 
         //Query the service on the database and convert the dataset to a DataReader
        DataTableReader bookDetailsReader = BookWormService.ExecuteQuery("SELECT [BookName], [BookAuthor], [BookAverageRating], [BookSummary], [BookGenre], [BookImageUrl], [BookSubmiterId] FROM [BookInformation] WHERE [BookId] = '" + (string)Session["BookId"] + "'").CreateDataReader();

        if (bookDetailsReader.HasRows)
        {
            while (bookDetailsReader.Read())
            {
                //Apply the values to the appropriate lables from the database based on the datakey selected on Books.apsx
                TitleLble.Text = bookDetailsReader.GetString(0).ToUpper();
                AuthorLble.Text = bookDetailsReader.GetString(1);
                AverageLble.Text = bookDetailsReader.GetInt32(2).ToString() + "%";
                SummaryLble.Text = bookDetailsReader.GetString(3);
                GenreLble.Text = bookDetailsReader.GetString(4);
                BookImg.ImageUrl = bookDetailsReader.GetString(5);
                userId = bookDetailsReader.GetInt32(6);

                //Set the gridView query to select the top 4 rated similar books
               // SqlDataSource1.SelectCommand = "SELECT TOP 4 [BookImageUrl] , [BookName] , [BookId] FROM [BookInformation] WHERE [BookId] != '" + (string)Session["BookId"] + "' AND [BookGenre] = '" + result.GetString(4) + "' OR [BookAuthor] = '" + result.GetString(4) + "' ORDER BY [BookAverageRating]";
                SimilarBooksGV.DataSource = BookWormService.ExecuteQuery("SELECT TOP 4 [BookImageUrl] , [BookName] , [BookId] FROM [BookInformation] WHERE [BookId] != '" + (string)Session["BookId"] + "' AND [BookGenre] = '" + bookDetailsReader.GetString(4) + "' OR [BookAuthor] = '" + bookDetailsReader.GetString(4) + "' ORDER BY [BookAverageRating]").CreateDataReader();
                SimilarBooksGV.DataBind();
                //Set the images for the stars based on the average percentage
                if (bookDetailsReader.GetInt32(2) <= 20)
                {
                    AvgStarImg1.ImageUrl = "Resources/Images/StarMouseOver.png";
                }
                else if (bookDetailsReader.GetInt32(2) > 20 & bookDetailsReader.GetInt32(2) <= 40)
                {
                    AvgStarImg1.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg2.ImageUrl = "Resources/Images/StarMouseOver.png";
                }
                else if (bookDetailsReader.GetInt32(2) > 40 & bookDetailsReader.GetInt32(2) <= 60)
                {
                    AvgStarImg1.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg2.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg3.ImageUrl = "Resources/Images/StarMouseOver.png";
                }
                else if (bookDetailsReader.GetInt32(2) > 60 & bookDetailsReader.GetInt32(2) <= 80)
                {
                    AvgStarImg1.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg2.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg3.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg4.ImageUrl = "Resources/Images/StarMouseOver.png";
                }
                else if (bookDetailsReader.GetInt32(2) > 80)
                {
                    AvgStarImg1.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg2.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg3.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg4.ImageUrl = "Resources/Images/StarMouseOver.png";
                    AvgStarImg5.ImageUrl = "Resources/Images/StarMouseOver.png";
                }
            }
            //Close the dataReader
            bookDetailsReader.Close();

            //Query a new DataReader to retrieve the username of the person who submitted the book using the userId from the BookInformationTable
            DataTableReader SubmittedBy = BookWormService.ExecuteQuery("SELECT [UserName] FROM [UserInformation] WHERE [UserId] = '" + userId + "'").CreateDataReader();

            //Read and assign the value
            while(SubmittedBy.Read())
            {
                UserNameLble.Text = SubmittedBy.GetString(0);
            }
            //Close the dataReader
            SubmittedBy.Close();
        }
        else
        {
            //Something went wrong with the database base (Redirect the user back to the books search page)
            Response.Redirect("Books.aspx");
        }

        //Recrord the number of times the book has been rated and assign the value to the label
        NumberRatedLble.Text = BookWormService.RecordRecords("SELECT * FROM [RatingInformation] WHERE [BookId] = '" + (string)Session["BookId"]+  "'").ToString();

        //Close the connection to the database
        BookWormService.Dispose();
        
   }

    //Sends the user back to books.aspx
    protected void BackBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Redirect the user to books.aspx if the back button is clicked 
        Response.Redirect("Books.aspx");
    }

    //Events used to set the rating of the users score depending on what star they clicked
    protected void StarOneBtn_Click(object sender, ImageClickEventArgs e)
    {
        SubmitImgBtn.Visible = true;
        WarningLble.Visible = true;
        WarningLble.Text = "Once you have submitted a score it can not be retracted. Are you sure you want to rate this book ?<br/> ";
        Session["UserScore"] = 20;
        WarningLble.Text = WarningLble.Text + "1/5";

        //Display the score of the stars
        StarOneBtn.ImageUrl = "Resources/Images/StarMouseOver.png";

    }
    protected void StarTwoBtn_Click(object sender, ImageClickEventArgs e)
    {
        StarClicked();
        Session["UserScore"] = 40;
        WarningLble.Text = WarningLble.Text + "2/5";

    }
    protected void StarThreeBtn_Click(object sender, ImageClickEventArgs e)
    {
        StarClicked();
        Session["UserScore"] = 60;
        WarningLble.Text = WarningLble.Text + "3/5";

    }
    protected void StarFourBtn_Click(object sender, ImageClickEventArgs e)
    {
        StarClicked();
        Session["UserScore"] = 80;
        WarningLble.Text = WarningLble.Text + "4/5";

    }
    protected void StarFiveBtn_Click(object sender, ImageClickEventArgs e)
    {
        StarClicked();
        Session["UserScore"] = 100;
        WarningLble.Text = WarningLble.Text + "5/5";
    }


    //This event calls a method to insert data and calculate the average of the percentages(total value - number of values)
    protected void SubmitImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Instanate the webservice to execute a command against the database 
        Service BookWormService = new Service();
        //Calculate the new average(this method is located on the web service) 
        BookWormService.CalculateAndStoreAverage((int)Session["UserScore"], (string)Session["BookId"], Request.Cookies["LoggedInCookie"]["UserId"]);
        //Log the rating of the user on the web service 
        BookWormService.WriteToLogFile(TitleLble.Text, AuthorLble.Text, Request.Cookies["LoggedInCookie"]["UserId"], (int)Session["UserScore"] );

        //Hide the appropriate buttons and lables 
        WarningLble.Visible = false;
        SubmitImgBtn.Visible = false;
        RateLble.Text = "Thank you for your feed back!";

        //Set the star values by calling the below method (see additional methods)
        SetStars((int)Session["UserScore"]);

        //Disable the stars
        DisableStars();

        //Clear the service resources 
        BookWormService.Dispose();
    }

    //Event used to load a different book
    protected void SimilarBooksGV_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["BookId"] = SimilarBooksGV.SelectedDataKey.Value.ToString();
        Response.Redirect("BookDetails.aspx");
    }
    #endregion 

    #region additional methods
    //These additional methods are used to reduce redudent code, since it's visual logic it's in the code behind page 
      //The following method disables the stars
    private void DisableStars()
    {
        StarOneBtn.Enabled = false;
        StarTwoBtn.Enabled = false;
        StarThreeBtn.Enabled = false;
        StarFourBtn.Enabled = false;
        StarFiveBtn.Enabled = false;
    }

      //The following method sets the star ImgUrl's depending on the users score
    private void SetStars(int value)
    {
        if (value == 20)
        {
            StarOneBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
        }
        else if (value == 40)
        {
            StarOneBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarTwoBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
        }
        else if (value == 60)
        {
            StarOneBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarTwoBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarThreeBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
        }
        else if (value == 80)
        {
            StarOneBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarTwoBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarThreeBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarFourBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
        }
        else if (value == 100)
        {
            StarOneBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarTwoBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarThreeBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarFourBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
            StarFiveBtn.ImageUrl = "Resources/Images/StarMouseOver.png";
        }
    }

      //This method displays the appropiate lables and image buttons when the user has selected a score/star
    private void StarClicked()
    {
        SubmitImgBtn.Visible = true;
        WarningLble.Visible = true;
        WarningLble.Text = "Once you have submitted a score it can not be retracted. Are you sure you want to rate this book ?<br/> ";
    }
         
    #endregion
}

