using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layouts_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         //Apply MouseEvents to javascript Via C# 

        AccountBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/AccountMouseOver.jpg'");
        AccountBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/AccountDefualt.jpg'");

        AboutBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/AboutMouseOver.jpg'");
        AboutBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/AboutDefault.jpg'");

        BooksBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/BooksMouseOver.jpg'");
        BooksBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/BooksDefualt.jpg'");

        SubmitBookBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/SubmitBookMouseOver.jpg'");
        SubmitBookBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/SubmitBookDefault.jpg'");

        HomeBtn.Attributes.Add("onmouseover", "this.src = 'Resources/Images/HomeMouseOver.jpg'");
        HomeBtn.Attributes.Add("onmouseout", "this.src = 'Resources/Images/HomeDefault.jpg'");

    }
    protected void AccountBtn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Account.aspx");

    }
    protected void SubmitBookBtn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SubmitBook.aspx"); 
    }
}