<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookWormHome.aspx.cs" Inherits="BookWormDefault" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/LoginPanel.ascx" tagname="LoginPanel" tagprefix="uc2" %>


<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc3" %>


<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc4" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: center;
        }
        .auto-style13 {
            height: 127px;
            width: 397px;
        }
        .auto-style15 {
            height: 206px;
            width: 397px;
        }
        .auto-style25 {
            width: 410px;
            height: 162px;
        }
        .auto-style26 {
            width: 476px;
            height: 162px;
        }
        .auto-style27 {
            height: 162px;
            width: 399px;
        }
        .auto-style28 {
            height: 144px;
            width: 397px;
        }
        .auto-style29 {
            height: 66px;
        }
        .auto-style30 {
            height: 9px;
        }
        .auto-style31 {
            height: 55px;
            width: 397px;
        }
    </style>
</head>
<body style="width: 1330px">
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
    
            <table style="width: 100%; height: 497px;" id="BodyTble">
                <tr>
                    <td align="center" class="auto-style25" style="vertical-align: top">  
                        <uc4:FeaturedSidePanelLeft ID="FeaturedSidePanelLeft1" runat="server" />
                    </td>
                    <td align="center" class="auto-style26" style="vertical-align: top">
                        <asp:Image ID="WelcomeGIFImg" runat="server" ImageUrl="~/Resources/Images/BookWormAnimatedPanelGIF.gif" style="position: relative; top: 0px; left: 0px; height: 360px; width: 507px" />
                        <table style="width: 107%; height: 401px;">
                            <tr>
                                <td class="auto-style30"></td>
                            </tr>
                            <tr>
                                <td>
                        <asp:Image ID="Image1" runat="server" Height="203px" ImageUrl="~/Resources/Images/BannerQuote.jpg" Width="507px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style29"></td>
                            </tr>
                        </table>
                    </td>
                    <td align="center" class="auto-style27">
                        <br />
                        <asp:Panel ID="HomeLeftPnl" runat="server" BackImageUrl="~/Resources/Images/BookWormHomePanelLeft.jpg" Height="746px" Width="397px" HorizontalAlign="Center">
                            <br />
                            <table style="width: 100%; height: 546px;">
                                <tr>
                                    <td class="auto-style13">
                                        <asp:ImageButton ID="UserIconImgBtn" runat="server" Height="85px" ImageUrl="~/Resources/Images/UserIconDefault.jpg" Visible="False" Width="89px" PostBackUrl="~/Account.aspx" />
                                        <asp:ImageButton ID="ConnectImgBtn" runat="server" Height="71px" ImageUrl="~/Resources/Images/ConnectWithUs.jpg" Width="131px" PostBackUrl="~/Register.aspx" />
                                        <br />
                                        <asp:Label ID="WellcomeBackLble" runat="server" Text="WelcomeBack" Font-Italic="True" Font-Size="Medium" Font-Strikeout="False" ForeColor="#0033CC" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style31">
                                        <asp:ImageButton ID="LogOutImgBtn" runat="server" Height="36px" ImageUrl="~/Resources/Images/LogOutHome.jpg" Visible="False" Width="98px" OnClick="LogOutImgBtn_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style28" style="vertical-align: bottom">
                                        <asp:Label ID="BooksNumberLble" runat="server" Font-Size="Medium" ForeColor="White" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15" style="vertical-align: bottom">
                                        <asp:Label ID="UsersNumberLble" runat="server" Font-Size="Medium" ForeColor="White" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>            
                        </asp:Panel>
                    </td>
                </tr>
                </table>
       
    </form>
</body>
</html>
