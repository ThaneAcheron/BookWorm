<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="BookDetails" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 24%;
        }
        .auto-style7 {
            height: 363px;
            width: 52%;
        }
        .auto-style9 {
            width: 10%;
            }
        .auto-style24 {
            height: 388px;
            width: 52%;
        }
        .auto-style25 {
            height: 388px;
            width: 25%;
        }
        .auto-style81 {
            height: 63px;
        }
        .auto-style88 {
            height: 75px;
        }
        .auto-style95 {            height: 116px;
        }
        .auto-style97 {
            width: 24%;
            height: 107px;
        }
        .auto-style98 {
            height: 388px;
            width: 24%;
        }
        .auto-style99 {
            width: 25%;
            height: 363px;
        }
        .auto-style101 {
            height: 163px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
        <table style="width: 100%; height: 320px;">
            <tr>
                <td class="auto-style97" style="vertical-align: middle; text-align: center; ">
                    <asp:ImageButton ID="BackBtn" runat="server" Height="74px" ImageUrl="~/Resources/Images/ArrowBack.jpg" Width="111px" OnClick="BackBtn_Click" />
                </td>
                <td align="center" class="auto-style9" rowspan="2">
                    <asp:Panel ID="HeaderPnl" runat="server" Width="700px" BackImageUrl="~/Resources/Images/BannerWhite.jpg" Height="81px" HorizontalAlign="Center">
                        <br />
                        <asp:Label ID="TitleLble" runat="server" Font-Bold="True" Font-Size="X-Large" Text="THE THEORY OF EVERYTHTING" ForeColor="White"></asp:Label>
                        <br />
                        <asp:Label ID="AuthorLble" runat="server" Text="Steven w. Hawking" ForeColor="White"></asp:Label>
                    </asp:Panel>
                </td>
                <td class="auto-style9" rowspan="2" style="vertical-align: top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="auto-style1" rowspan="2" style="vertical-align: top; ">
                                    <asp:Image ID="Image6" runat="server" Height="54px" ImageUrl="~/Resources/Images/AverageHeading.jpg" Width="165px" />
                    <br />
                                    <asp:Image ID="AvgStarImg1" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="40px" />
                                    <asp:Image ID="AvgStarImg2" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="40px" />
                                    <asp:Image ID="AvgStarImg3" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="40px" />
                                    <asp:Image ID="AvgStarImg4" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="40px" />
                                    <asp:Image ID="AvgStarImg5" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="40px" />
                    <br />
                                    <asp:Image ID="BookImg" runat="server" Height="240px" ImageUrl="~/Resources/BookImages/ThoeryOfEverything.jpg" Width="140px" />
                                    <asp:Panel ID="SubmittedPnl" runat="server" BackImageUrl="~/Resources/Images/RibbonBookDetails.jpg" Height="55px" Width="245px">
                                        <br />
                                        <asp:Label ID="submittedByLble" runat="server" ForeColor="White" Text="Submitted by&amp;nbsp"></asp:Label>
                                        <asp:Label ID="UserNameLble" runat="server" ForeColor="White" Text="UserName"></asp:Label>
                                        <br />
                                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style7" dir="ltr" style="vertical-align: top">
                    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Resources/Images/DetailsPanel.jpg" Height="425px" Width="543px" HorizontalAlign="Center">
                        <table style="width:100%; height: 100%; text-align: center;">
                            <tr>
                                <td class="auto-style81">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style88">
                                    <asp:Label ID="DisGenreLble" runat="server" Text="Genre" ForeColor="White" Font-Bold="False" Font-Italic="True" Font-Size="Large"></asp:Label>
                                    <br />
                                    <asp:Label ID="GenreLble" runat="server" Text="Self-help" ForeColor="White"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align ="center" class="auto-style101" style="vertical-align: top">
                                    <br />
                                    <asp:Label ID="DisAverageLble" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="Large" ForeColor="White" Text="Average rating"></asp:Label>
                                    <br />
                                    <asp:Label ID="AverageLble" runat="server" ForeColor="White" Text="60%"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="DisPeopleLble" runat="server" Text="Number of people who have rated this book" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:Label ID="NumberRatedLble" runat="server" Text="5" ForeColor="White"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="RateLble" runat="server" Font-Italic="True" Font-Size="Medium" ForeColor="White" Text="Rate this book"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="auto-style95" style="vertical-align: top">
                                    <asp:ImageButton ID="StarOneBtn" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="50px" OnClick="StarOneBtn_Click" />
                                    <asp:ImageButton ID="StarTwoBtn" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="50px" OnClick="StarTwoBtn_Click" />
                                    <asp:ImageButton ID="StarThreeBtn" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="50px" OnClick="StarThreeBtn_Click" />
                                    <asp:ImageButton ID="StarFourBtn" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="50px" OnClick="StarFourBtn_Click" />
                                    <asp:ImageButton ID="StarFiveBtn" runat="server" Height="60px" ImageUrl="~/Resources/Images/StarDefault.png" Width="50px" OnClick="StarFiveBtn_Click" />
                                    <br />
                                    <asp:ImageButton ID="SubmitImgBtn" runat="server" Height="42px" ImageUrl="~/Resources/Images/SubmitDefault.png" Width="132px" OnClick="SubmitImgBtn_Click" Visible="False" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Label ID="WarningLble" runat="server" Font-Italic="True" Font-Size="Medium" Font-Underline="False" ForeColor="#2BA4A9" Text="Once you have submitted a score it can not be retracted. Are you sure you want to rate this book ?&lt;br/&gt; " Visible="False"></asp:Label>
                    <br />
                    <asp:Panel ID="Panel3" runat="server" BackImageUrl="~/Resources/Images/SummaryPanel.jpg" Height="391px" ScrollBars="Auto" Width="283px" style="margin-top: 0px" HorizontalAlign="Center">
                                        <br />
                                        <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Size="X-Large" ForeColor="White" Text="Summary"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Label ID="SummaryLble" runat="server" Text="This short book consists of a compilation of several lectures by Stephen Hawking. Many of the ideas from them appear in several of his past books. Hawking attempts to explain sophisticated and complex mathematical ideas in an unsophisticated way." ForeColor="White" Width="80%"></asp:Label>
                                    </asp:Panel>
                </td>

                <td align ="center" class="auto-style99" style="vertical-align: top; ">
                    <asp:Image ID="Image7" runat="server" Height="54px" ImageUrl="~/Resources/Images/Similar Books.jpg" Width="165px" />
                    <asp:GridView ID="SimilarBooksGV" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="268px" ShowHeader="False" Width="145px" DataKeyNames="BookId" OnSelectedIndexChanged="SimilarBooksGV_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="BookId" HeaderText="BookId" InsertVisible="False" ReadOnly="True" SortExpression="BookId" Visible="False" />
                            <asp:ImageField DataImageUrlField="BookImageUrl">
                            </asp:ImageField>
                            <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Resources/Images/ReadMoreSized.jpg" ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWormConnectionString %>" SelectCommand="SELECT [BookId], [BookName], [BookImageUrl] FROM [BookInformation]"></asp:SqlDataSource>
                </td>

            </tr>
            <tr>
                <td class="auto-style98"></td>
                <td align="center" class="auto-style24">
                                    
                                    </td>
                <td class="auto-style25"></td>
            </tr>
        </table>
    </form>
</body>
</html>
