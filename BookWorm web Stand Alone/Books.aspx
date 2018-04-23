<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 56px;
        }
        .auto-style7 {
            height: 40px;
        }
        .50%; {
            text-align: right;
        }
        .50%; {
            text-align: right;
        }
        .50%; {
            text-align: right;
        }
        .right; {
            text-align: right;
        }
        .auto-style9 {
            width: 534px;
        }
        .auto-style13 {
            width: 271px;
        }
        .auto-style16 {
            height: 40px;
            width: 44.5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
        <table style="width: 100%; height: 434px;">
            <tr>
                <td class="auto-style1" colspan="3">
                    <asp:Panel ID="Panel1" runat="server" Height="43px" Width ="100%" BackImageUrl="~/Resources/Images/BookWormSearchHeader.jpg" HorizontalAlign="Center" style="position: relative">
                        <table style="width: 100%; height: 42px; z-index: 1; left: 0px; top: 0px; position: relative;">
                            <tr>
                                <td class="auto-style7" style="text-align: right">
                                    <asp:TextBox ID="SearchTxtb" runat="server" Width="189px"></asp:TextBox>
                                </td>
                                <td class="auto-style16" style="vertical-align: middle; text-align: left; ">
                                    <asp:ImageButton ID="SearchImgBtn" runat="server" Height="20px" ImageUrl="~/Resources/Images/SearchButton.jpg" Width="52px" style="margin-top: 3px" OnClick="SearchImgBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style9" ; width: 50% style="text-align: center">
                    <asp:Image ID="Image5" runat="server" Height="26px" ImageUrl="~/Resources/Images/SearchHeader.jpg" Width="271px" />
                </td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style8; width: 25%" style="width: 25%; vertical-align: top; text-align: center;">
                    <asp:Image ID="Image4" runat="server" Height="104px" ImageUrl="~/Resources/Images/SearchFilters.jpg" Width="258px" style="margin-top: 0px; margin-bottom: 0px" />
                    <br />
                    <br />
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/Images/SearchByGenre.jpg" Width="259px" Height="51px" />
                    <br />
                    <br />
                    <asp:DropDownList ID="DdlGenre" runat="server" Width="195px" Height="20px" OnSelectedIndexChanged="DdlGenre_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                    <br />
                                 <br />
                    <asp:Image ID="Image6" runat="server" Height="51px" ImageUrl="~/Resources/Images/OrderBy.jpg" Width="259px" />
                    <br />
                    <br />
                    <asp:DropDownList ID="OrderByPreDdl" runat="server" Height="20px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>Rating</asp:ListItem>
                        <asp:ListItem>Name</asp:ListItem>
                        <asp:ListItem>Author</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="OrderBySufDdl" runat="server" Height="20px" Width="55px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem>ASC</asp:ListItem>
                        <asp:ListItem>DESC</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9" style="text-align: center; vertical-align: top;">
                    <asp:GridView ID="MainGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="260px" Width="100%" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="MainGridView_SelectedIndexChanged" DataKeyNames="BookId" PageSize="6">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="BookId" HeaderText="BookId" InsertVisible="False" ReadOnly="True" SortExpression="BookId" Visible="False" />
                            <asp:ImageField DataImageUrlField="BookImageUrl">
                                <ControlStyle BorderColor="White" BorderStyle="None" />
                                <FooterStyle BorderStyle="None" />
                                <HeaderStyle BorderStyle="None" />
                                <ItemStyle BorderStyle="None" />
                            </asp:ImageField>
                            <asp:BoundField DataField="BookName" HeaderText="Name" SortExpression="BookName">
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BookAuthor" HeaderText="Author" SortExpression="BookAuthor">
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BookAverageRating" HeaderText="Rating" SortExpression="BookAverageRating">
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Image" InsertImageUrl="~/Resources/Images/ReadMoreSized.jpg" SelectImageUrl="~/Resources/Images/ReadMoreSized.jpg" SelectText="More" ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWormConnectionString %>" SelectCommand="SELECT [BookName], [BookImageUrl], [BookAuthor], [BookAverageRating], [BookId] FROM [BookInformation]"></asp:SqlDataSource>
                </td>
                <td class="auto-style13" style="width: 25%; vertical-align: top; text-align: center;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/Images/DidYou.jpg" Height="104px" />
                    <br />
                    <asp:ImageButton ID="FindYesBtn" runat="server" Height="36px" ImageUrl="~/Resources/Images/YesDefault.jpg" Width="115px" OnClick="FindYesBtn_Click" />
                    <asp:ImageButton ID="FindNoBtn" runat="server" Height="36px" ImageUrl="~/Resources/Images/NoDefault.jpg" Width="115px" PostBackUrl="~/SubmitBook.aspx" />
                    <br />
                    <asp:Label ID="ThankYouLble" runat="server" Text="Thank you for your feedback!" ForeColor="#00A0B3" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Image ID="Image3" runat="server" Height="144px" ImageUrl="~/Resources/Images/SearchPageDrQuote.jpg" Width="259px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
