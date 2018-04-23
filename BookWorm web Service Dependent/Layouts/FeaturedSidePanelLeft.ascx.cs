using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookWormService; //NameSpace of the webservice
/// <summary>
/// Filename: FeaturedSidePanel.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This contains the visual logic for the featured side panel
/// </summary>
public partial class Layouts_FeaturedSidePanel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Get the top rated books from the database on the webservice 
             //Open a new instance of the webservice 
            Service BookWormService = new Service();
             //Query the database
            FeaturedGV.DataSource = BookWormService.ExecuteQuery("SELECT TOP 5 [BookId],[BookImageUrl] FROM [BookInformation] ORDER BY [BookAverageRating] DESC");
            //Databind and clear the service resources 
            FeaturedGV.DataBind();
            BookWormService.Dispose(); 
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Store the datakey in a session varaible and redirect the user to view the bookdetails on BookDetails.aspx
        Session["BookId"] = FeaturedGV.SelectedDataKey.Value.ToString();
        Response.Redirect("BookDetails.aspx");
    }
}