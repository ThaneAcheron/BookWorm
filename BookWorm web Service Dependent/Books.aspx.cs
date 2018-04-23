using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using BookWormService; //Namespace of the webservice 

/// <summary>
/// Filename: Books.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the visual logic for displaying a list of books, accessing search methods and viewing books
/// </summary>
/// 
public partial class Books : System.Web.UI.Page
{
   //This page controls the events for the retrieving and querying strings against a webservice database to display dynamic results 
    //Variables  
     //Used to create a querystring to uses against the BookWormServer Database 
    string querystring;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Check the cookies to see if the user is loggedin otherwise redirect to Register.aspx 
        if (Request.Cookies["LoggedInCookie"] == null || (Request.Cookies["LoggedInCookie"] != null && Request.Cookies["LoggedInCookie"]["LoggedIn"] != "true"))
        {
            Response.Redirect("Register.aspx");
        }

        //Check if the page has been loaded before 
        if (!Page.IsPostBack)
        {
        //Add mouseenter/mouseover events to the image buttons
        FindYesBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/YesMouseOver.jpg'");
        FindYesBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/YesDefault.jpg'");

        FindNoBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/NoMouseOver.jpg'");
        FindNoBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/NoDefault.jpg'");

        //Databind items to the DropDownList (DdlGenere) using an ArrayCollection 
         //Used to databind the dropdownlist with the book genres 
        ArrayList DdlGenreArray = new ArrayList();
           //DataBind the dropdownlist by getting the list from the ArrayCollections class
        ArrayCollections getlist = new ArrayCollections();
            //Get the list
            DdlGenreArray = getlist.GenreList();
            //Apply the source
            DdlGenre.DataSource = DdlGenreArray;
            //DataBind
            DdlGenre.DataBind();

       //Open a new instance of the bookWormService
        Service BookWormService = new Service();
            //Execute the query against the database on the service (Man, I love APIs) 
            MainGridView.DataSource = BookWormService.ExecuteQuery("SELECT [BookId], [BookName], [BookImageUrl], [BookAuthor], [BookAverageRating] FROM [BookInformation] ");
            //Databind the gridView 
            MainGridView.DataBind();
            //Dispose of the Service Resources 
            BookWormService.Dispose(); 
        }
    }

    protected void FindYesBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Data can be collected here. 
        ThankYouLble.Visible = true;
    }
    protected void MainGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Logic for selecting an item in the gridview 
        //Note that a datakey has been referenced to the BookId of the corrosponding row via properties in the design view.      
        //Use a session variable to store information about the selectedRow

        Session["BookId"] = MainGridView.SelectedDataKey.Value.ToString();
        Response.Redirect("BookDetails.aspx");
    }
    protected void SearchImgBtn_Click(object sender, ImageClickEventArgs e) 
    {
        //Databind the gridview
        DataBindGridView(); 
    }
    protected void DdlGenre_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Databind the gridview
        DataBindGridView(); 
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Databind the gridview
        DataBindGridView(); 
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Databind the gridview
        DataBindGridView(); 
    }

    protected void MainGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //We have to programmatically set the pageIndexChanged event, since we are databinding to a dataset.
        //Next page 
        MainGridView.PageIndex = e.NewPageIndex;
        //DataBind 
        DataBindGridView();
    }

    //This method is used for databinding the gridview to a dataSet from the BookWormService 
    private void DataBindGridView()
    {
        //Declare the FilterAlgoithm class and use the filter method 
        FilterAlgorithm filterSearch = new FilterAlgorithm();
        //Remove ' to prevent sqlinjection/Exeption
        querystring = filterSearch.Filter(SearchTxtb.Text.Replace("'", ""), DdlGenre.Text, OrderByPreDdl.Text, OrderBySufDdl.Text);
        //Open a new instance of the bookWormService
        Service BookWormService = new Service();
        //Execute the structed query
        MainGridView.DataSource = BookWormService.ExecuteQuery(querystring);
        //Databind 
        MainGridView.DataBind();
        //Dispose the resources
        BookWormService.Dispose(); 
    }
 
}
