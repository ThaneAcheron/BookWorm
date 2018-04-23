<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Layouts_Header" %>


<%@ Register src="LoginPanel.ascx" tagname="LoginPanel" tagprefix="uc1" %>


<asp:Panel ID="Panel1" runat="server" Height="93px" HorizontalAlign="Center" style="position: relative; top: -15px; left: 0px; width: 100%">
    <asp:Image ID="Image1" runat="server" Height="99px" ImageUrl="~/Resources/Images/HeaderDesignReversed.jpg" Width="201px" />
    <asp:ImageButton ID="AccountBtn" runat="server" Height="99px" ImageUrl="~/Resources/Images/AccountDefualt.jpg" PostBackUrl="~/Account.aspx" Width="114px" OnClick="AccountBtn_Click" CausesValidation="False" />
    <asp:ImageButton ID="BooksBtn" runat="server" Height="99px" Width="114px" ImageUrl="~/Resources/Images/BooksDefualt.jpg" PostBackUrl="~/Books.aspx" style="position: relative" CausesValidation="False" />
    &nbsp;<asp:ImageButton ID="HomeBtn" runat="server" Height="99px" ImageUrl="~/Resources/Images/HomeDefault.jpg" Width="152px" PostBackUrl="~/BookWormHome.aspx" style="position: relative" CausesValidation="False" />
    <asp:ImageButton ID="SubmitBookBtn" runat="server" Height="99px" Width="114px" ImageUrl="~/Resources/Images/SubmitBookDefault.jpg" style="position: relative" CausesValidation="False" OnClick="SubmitBookBtn_Click" />
    <asp:ImageButton ID="AboutBtn" runat="server" Height="99px" Width="114px" ImageUrl="~/Resources/Images/AboutDefault.jpg" PostBackUrl="~/About.aspx" style="position: relative" CausesValidation="False" />
    <asp:Image ID="Image2" runat="server" Height="99px" ImageUrl="~/Resources/Images/HeaderDesignRight.jpg" Width="200px" />
</asp:Panel>









