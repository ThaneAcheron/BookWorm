using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layouts_FeaturedSidePanel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DetailsView2_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["BookId"] = FeaturedGV.SelectedDataKey.Value.ToString();
        Response.Redirect("BookDetails.aspx");
    }
}