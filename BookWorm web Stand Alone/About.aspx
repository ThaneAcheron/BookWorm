<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/LoginPanel.ascx" tagname="LoginPanel" tagprefix="uc2" %>

<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 81px;
        }
        .auto-style2 {
            height: 81px;
            width: 262px;
        }
        .auto-style3 {
            width: 262px;
        }
        .auto-style4 {
            height: 60px;
        }
        .auto-style5 {
            height: 60px;
            width: 262px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server"  />
    
    </div>
        <p>
            <table style="width: 100%; height: 340px;">
                <tr>
                    <td align ="center" style="width: 25%; vertical-align: top">
                        &nbsp;</td>
                    <td  align = "center" style="width: 50%; vertical-align: top;">
                        <asp:Panel ID="MainPnl" runat="server" Width="540px" BackImageUrl="~/Resources/Images/About.jpg" Height="414px">
                        </asp:Panel>
                    </td>
                    <td style="width: 25%">&nbsp;</td>
                </tr>
                </table>
        </p>
    </form>
</body>
</html>
