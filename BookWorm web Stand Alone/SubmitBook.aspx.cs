using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;


public partial class SubmitBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["LoggedInCookie"] == null || (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] != "true"))
        {
            Response.Redirect("Register.aspx");
        }

        if (!Page.IsPostBack)
        {

            //Set the events for the image button
            SubmitImgBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/SubmitDefault.png'");
            SubmitImgBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/SubmitMouseOver.png'");

            //Databind the dropdown list 
             //Open a new instance of the class containing the genrelist 
              //Store as an arraylist 
            ArrayCollections getlist = new ArrayCollections();
            ArrayList genreList = getlist.GenreList();
             //Remove "All" from the arraylist since it is not a genre 
            genreList.Remove("All"); 

            //Set source and databind 
            GenreDdl.DataSource = genreList;
            GenreDdl.DataBind();
 
        }

        //Set the gridviews select command to only bring up books that the user has rated
        SqlDataSource1.SelectCommand = "SELECT TOP 4 [BookImageUrl] , [BookId] , [BookName] FROM [BookInformation] WHERE [BookSubmiterId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'";

        //Hide the details panel 
        BookDetailsPnl.Visible = false; 

    }
    protected void submittedByYouGv_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set the selected datakey to a session variable
        Session["BookId"] = SubmittedBy.SelectedDataKey.Value.ToString();
        Response.Redirect("BookDetails.aspx");
    }
    protected void SubmitImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Make sure the file is not larger than 800KB (File extention validation is done by a regular expression validator on the client side)
        double size = BookImageFileUpL.FileContent.Length;
        if (size > 819200)
        {
            UploadReportLble.Text = "The file is too large, it must be under 800KB.";
        }
        else
        {
            if (BookImageFileUpL.HasFile == true)
            {
               //Start a new instance of the resize class /AppCode/
               ResizeImage resize = new ResizeImage();

                //Create and store an new GUID for a unique image name 
               string guid = System.Guid.NewGuid().ToString() + ".jpg";  

               // Specify the upload directory
               string directory = Server.MapPath("Resources/BookImages/");

               //Store the image from the uploadFile control into memory
               Bitmap image = new Bitmap(BookImageFileUpL.FileContent);

               //Resize the image(used from the ResizeImage class) and store the resized image in a new bitmap
               Bitmap resizedImage = resize.Resize(image, 105, 150);
                
               // Save the new graphic file to the server 
               resizedImage.Save(directory + guid);
                  
               //Dispose the BitMaps 
               image.Dispose();
               resizedImage.Dispose();

               //Set the ImgURL of the sampleImg control to display the uploaded image 
               ImageSampleImg.ImageUrl = "Resources/BookImages/" + guid;

               //Show the book details panel
               BookDetailsPnl.Visible = true;
                 //Apply the appropriate values to the lables
               NameValueLble.Text = BookNameTxtb.Text;
               AuthorValueLble.Text = AuthorTxtb.Text;
               GenreValueLble.Text = GenreDdl.SelectedValue.ToString();

               //Open a new connection to the database and insert the information entered by the user
               UseDataBase usedb = new UseDataBase();
               usedb.ConnectDataBase();
               //Insert command 
               usedb.ExecuteCommand("INSERT INTO [BookInformation] (BookName , BookAuthor, BookSummary, BookGenre, BookImageUrl , BookSubmiterId , BookAverageRating) VALUES ('" + BookNameTxtb.Text.Replace("'", "") + "','" + AuthorTxtb.Text.Replace("'", "") + "','" + BookSummaryTxtb.Text.Replace("'", "") + "','" + GenreDdl.SelectedValue.ToString() + "','/Resources/BookImages/" + guid + "','" + Request.Cookies["LoggedInCookie"]["UserId"] + "' , '0' )");
               //Close the connection to the database 
               usedb.Close();

               //Open a new connection to the database 
               UseDataBase getName = new UseDataBase();
               getName.ConnectDataBase(); 

               //Store the select result in a datareader 
               SqlDataReader UserName = getName.ExecuteQuery("SELECT [UserName] FROM [UserInformation] WHERE [UserId] = '" + Request.Cookies["LoggedInCookie"]["UserId"] + "'");

                //Set the submitterValueLble text to display the users name 
                while(UserName.Read())
                {
                    SubmitterValueLble.Text = UserName.GetString(0);
                }

                //Close the connection to the database/DataReader
                getName.Close();
                UserName.Close();

               //Report back to the user
               UploadReportLble.Text = "Submittion successful, Thank you!"; 
            }
        }
    }
}