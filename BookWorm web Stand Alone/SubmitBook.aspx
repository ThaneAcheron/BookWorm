<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitBook.aspx.cs" Inherits="SubmitBook" UnobtrusiveValidationMode ="None" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 25%;
            }
        .auto-style2 {
            width: 25%;
            height: 37px;
        }
        .auto-style3 {
            height: 85px;
        }
        .auto-style5 {
            height: 85px;
            width: 26px;
        }
        .auto-style7 {
            width: 26px;
        }
        .auto-style8 {
            height: 85px;
            width: 434px;
        }
        .auto-style10 {
            width: 434px;
        }
        .auto-style11 {
            height: 85px;
            width: 618px;
        }
        .auto-style13 {
            width: 618px;
        }
        .auto-style14 {
            height: 85px;
            width: 383px;
        }
        .auto-style16 {
            width: 383px;
        }
        .auto-style17 {
            height: 50px;
            width: 618px;
        }
        .auto-style20 {
            height: 45px;
            width: 26px;
        }
        .auto-style21 {
            height: 45px;
            width: 383px;
        }
        .auto-style22 {
            height: 45px;
            width: 434px;
        }
        .auto-style23 {
            height: 45px;
        }
        .auto-style25 {
            width: 50%;
        }
        .auto-style26 {
            height: 45px;
            width: 618px;
        }
        .auto-style29 {
            height: 65px;
            width: 208px;
        }
        .auto-style31 {
            width: 208px;
        }
        .auto-style35 {
            height: 65px;
        }
        .auto-style40 {
            height: 70px;
            width: 208px;
        }
        .auto-style41 {
            height: 70px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
        <table style="width: 100%; height: 697px;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td align ="center" rowspan="2" style="vertical-align: top;" class="auto-style25">
                    <asp:Panel ID="Panel1" runat="server" Height="410px" BackImageUrl="~/Resources/Images/SubmitBookBackPanel.jpg" Width="538px">
                        <table style="width:100%; height: 100%;">
                            <tr>
                                <td class="auto-style5"></td>
                                <td class="auto-style14"></td>
                                <td class="auto-style11" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="X-Large" ForeColor="White" Text="Submit Book"></asp:Label>
                                </td>
                                <td class="auto-style8"></td>
                                <td class="auto-style3"></td>
                            </tr>
                            <tr>
                                <td class="auto-style20"></td>
                                <td class="auto-style21"></td>
                                <td align ="center" class="auto-style26" style="vertical-align: middle;">
                                    <asp:Label ID="BookNameLble" runat="server" ForeColor="White" Text="Book name"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="BookNameTxtb" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="auto-style22" style="vertical-align: bottom; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the book name" ForeColor="White" ControlToValidate="BookNameTxtb">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style23"></td>
                            </tr>
                            <tr>
                                <td class="auto-style7" rowspan="5">&nbsp;</td>
                                <td class="auto-style16" rowspan="5">&nbsp;</td>
                                <td class="auto-style26" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="AuthorNameLble" runat="server" ForeColor="White" Text="Author name"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="AuthorTxtb" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="auto-style10" style="vertical-align: bottom; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the book author" ForeColor="White" ControlToValidate="AuthorTxtb">*</asp:RequiredFieldValidator>
                                </td>
                                <td rowspan="5">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="GenreLble" runat="server" Text="Genre" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="GenreDdl" runat="server" Height="22px" Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style10">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style17" style="vertical-align: middle; text-align: center" rowspan="2">
                                    <asp:Label ID="Label8" runat="server" Text="Image upload" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:FileUpload ID="BookImageFileUpL" runat="server" ForeColor="White" Width="180px" />
                                    <br />
                                </td>
                                <td class="auto-style10" style="vertical-align: bottom; text-align: left">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="BookImageFileUpL" ErrorMessage="jpg/png images are only allowed" ValidationExpression="^.*\.(jpg|JPG|png|PNG)$" ForeColor="White">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10" style="vertical-align: bottom; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="BookImageFileUpL" ErrorMessage="Please upload an image" ForeColor="White">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13" style="vertical-align: top; text-align: center">
                                    <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Summary"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="BookSummaryTxtb" runat="server" Height="54px" TextMode="MultiLine" Width="260px"></asp:TextBox>
                                    <br />
                                    <asp:ImageButton ID="SubmitImgBtn" runat="server" Height="41px" ImageUrl="~/Resources/Images/SubmitDefault.png" OnClick="SubmitImgBtn_Click" Width="137px" />
                                </td>
                                <td class="auto-style10" style="vertical-align: middle; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BookSummaryTxtb" ErrorMessage="Please enter the book summary" ForeColor="White">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Label ID="UploadReportLble" runat="server" Text="  " ForeColor="#02A1BF"></asp:Label>
                    <br />
                    <asp:Panel ID="BookDetailsPnl" runat="server" BackColor="#3399FF" Height="386px" Width="285px" BackImageUrl="~/Resources/Images/SummaryPanel.jpg">
                        <table style="width:100%; height: 100%;">
                            <tr>
                                <td class="auto-style35"></td>
                                <td class="auto-style29" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="DetailsHeadingLble" runat="server" Font-Size="Larger" ForeColor="White" Text="Book Details "></asp:Label>
                                </td>
                                <td class="auto-style35"></td>
                            </tr>
                            <tr>
                                <td class="auto-style41"></td>
                                <td class="auto-style40" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="DetailsNameLble" runat="server" Text="Book name: " ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:Label ID="NameValueLble" runat="server" Text="The theory of everything" ForeColor="White"></asp:Label>
                                </td>
                                <td class="auto-style41"></td>
                            </tr>
                            <tr>
                                <td rowspan="4">&nbsp;</td>
                                <td class="auto-style40" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="DetailsAuthorLble" runat="server" ForeColor="White" Text="Author:"></asp:Label>
                                    <br />
                                    <asp:Label ID="AuthorValueLble" runat="server" ForeColor="White" Text="Steven W. Hawking"></asp:Label>
                                </td>
                                <td rowspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style40" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="DetailsGenreLble" runat="server" ForeColor="White" Text="Genre:"></asp:Label>
                                    <br />
                                    <asp:Label ID="GenreValueLble" runat="server" ForeColor="White" Text="Self Help"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style40" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="DetailsSubmitterLble" runat="server" ForeColor="White" Text="Submitter:"></asp:Label>
                                    <br />
                                    <asp:Label ID="SubmitterValueLble" runat="server" Text="Craig Turner" ForeColor="White"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style31">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td align ="center" style="vertical-align: top;" class="auto-style1">
                    <asp:Image ID="Image2" runat="server" Height="46px" ImageUrl="~/Resources/Images/FrontCoverSample.jpg" Width="266px" />
                    <br />
                    <asp:Image ID="ImageSampleImg" runat="server" ImageUrl="~/Resources/BookImages/NoImage.jpg" Height="240px" Width="140px" />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" style="margin-top: 5px" DisplayMode="List" ForeColor="#02A1BF" HeaderText="The following errors occured" Width="245px" />
                    <asp:Image ID="Image4" runat="server" Height="104px" ImageUrl="~/Resources/Images/HelpUsExpand.jpg" Width="258px" />
                    <br />
                </td>
                <td align ="center" class="auto-style1" style="vertical-align: top">
                    <asp:Image ID="Image3" runat="server" Height="46px" ImageUrl="~/Resources/Images/submittedByYouSubmitBook.jpg" Width="266px" />
                    <asp:GridView ID="SubmittedBy" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BookId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="3" ShowHeader="False" OnSelectedIndexChanged="submittedByYouGv_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="BookId" HeaderText="BookId" InsertVisible="False" ReadOnly="True" SortExpression="BookId" Visible="False" />
                            <asp:ImageField DataImageUrlField="BookImageUrl">
                            </asp:ImageField>
                            <asp:BoundField DataField="BookSubmiterId" HeaderText="BookSubmiterId" SortExpression="BookSubmiterId" Visible="False" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWormConnectionString %>" SelectCommand="SELECT [BookId], [BookName], [BookImageUrl], [BookSubmiterId] FROM [BookInformation]"></asp:SqlDataSource>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
