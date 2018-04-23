using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Books : System.Web.UI.Page
{
    //Variables and DataStructures 
    string querystring;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Used to databind the dropdownlist with the book genres 
        ArrayList DdlGenreArray = new ArrayList();

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
        ArrayCollections getlist = new ArrayCollections();
            DdlGenreArray = getlist.GenreList();
            DdlGenre.DataSource = DdlGenreArray;
            DdlGenre.DataBind();
        }
    }

    protected void FindYesBtn_Click(object sender, ImageClickEventArgs e)
    {
        //Data can be collected here. 
        ThankYouLble.Visible = true;
    }
    protected void SearchImgBtn_Click(object sender, ImageClickEventArgs e) 
    {
        //Declare the FilterAlgoithm class and use the filter method 
        FilterAlgorithm filterSearch = new FilterAlgorithm();     
        querystring = filterSearch.Filter(SearchTxtb.Text.Replace("'",""), DdlGenre.Text, OrderByPreDdl.Text, OrderBySufDdl.Text);

        //Execute the structed query
        SqlDataSource1.SelectCommand = querystring;
    }
    protected void DdlGenre_SelectedIndexChanged(object sender, EventArgs e)
    {

        //Declare the FilterAlgoithm class and use the filter method 
        FilterAlgorithm filterSearch = new FilterAlgorithm();
        querystring = filterSearch.Filter(SearchTxtb.Text, DdlGenre.Text, OrderByPreDdl.Text, OrderBySufDdl.Text);

        //Execute the structed query
        SqlDataSource1.SelectCommand = querystring;
    }

    protected void MainGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Logic for selecting an item in the gridview 
         //Note that a datakey has been referenced to the BookId of the corrosponding row via properties in the design view.      
          //Use a session variable to store information about the selectedRow
     
            Session["BookId"] = MainGridView.SelectedDataKey.Value.ToString();
            Response.Redirect("BookDetails.aspx");                    
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilterAlgorithm filterSearch = new FilterAlgorithm();
        querystring = filterSearch.Filter(SearchTxtb.Text, DdlGenre.Text, OrderByPreDdl.Text, OrderBySufDdl.Text);

        //Execute the structed query
        SqlDataSource1.SelectCommand = querystring;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilterAlgorithm filterSearch = new FilterAlgorithm();
        querystring = filterSearch.Filter(SearchTxtb.Text, DdlGenre.Text, OrderByPreDdl.Text, OrderBySufDdl.Text);

        //Execute the structed query
        SqlDataSource1.SelectCommand = querystring;
    }
}
