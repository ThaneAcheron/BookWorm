<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" UnobtrusiveValidationMode ="None" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style8 {
            height: 40px;
        }
        .auto-style11 {
            height: 60px;
            width: 370px;
        }
        .auto-style12 {
            width: 370px;
        }
        .auto-style13 {
        }
        .auto-style14 {
        }
        .auto-style18 {
        }
        .auto-style19 {
            height: 25px;
        }
        .auto-style20 {
            width: 25%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
        <table style="width: 100%; height: 235px;">
            <tr>
                <td align ="center" class="auto-style18" style="vertical-align: middle">
                    <asp:Image ID="AccountTasksImg" runat="server" Height="63px" ImageUrl="~/Resources/Images/AccountTasks.jpg" Width="288px" />
                    </td>
                <td align ="center" class="auto-style18" style="vertical-align: top" rowspan="3">
                    <asp:Panel ID="Panel1" runat="server" Width="545px" BackImageUrl="~/Resources/Images/AccountPanel.jpg" Height="425px" HorizontalAlign="Center">
                        <table style="width:100%; height: 100%; vertical-align: top;">
                            <tr>
                                <td class="auto-style19" colspan="3"></td>
                            </tr>
                            <tr>
                                <td class="auto-style8" colspan="3" style="vertical-align: top">
                                    <asp:Label ID="UserNameHeaderLble" runat="server" Font-Size="X-Large" ForeColor="White" Text="Username"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20" rowspan="6">&nbsp;</td>
                                <td class="auto-style11" style="width: 50%">
                                    <asp:Label ID="UserNameLble" runat="server" Text="User name" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="UserNameTxtb" runat="server" Width="160px" ValidateRequestMode="Enabled"></asp:TextBox>
                                </td>
                                <td class="auto-style13" style="width: 25%; text-align: left;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="UserNameTxtb" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11" style="width: 50%">
                                    <asp:Label ID="EmailLble" runat="server" Text="Email Address" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="EmailTxtb" runat="server" Width="160px" ValidateRequestMode="Enabled"></asp:TextBox>
                                </td>
                                <td class="auto-style13" style="width: 25%; text-align: left;">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email not valid" ControlToValidate="EmailTxtb" ForeColor="White" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTxtb" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11" style="width: 50%">
                                    <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Security Question"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="SecurityQuestionDdl" runat="server" Height="22px" Width="160px">
                                        <asp:ListItem>Mothers name</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                </td>
                                <td class="auto-style13" style="width: 25%; text-align: left;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11" style="width: 50%">
                                    <asp:Label ID="SecurityAnswerLble" runat="server" ForeColor="White" Text="Security Answer"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="SecurityAnswerTxtb" runat="server" Width="160px" ValidateRequestMode="Enabled"></asp:TextBox>
                                    <br />
                                </td>
                                <td class="auto-style13" style="width: 25%; text-align: left;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ControlToValidate="SecurityAnswerTxtb" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11" style="width: 50%">
                                    <br />
                                    <asp:ImageButton ID="UpdateBtn" runat="server" Height="46px" ImageUrl="~/Resources/Images/UpdateDefault.png" Width="145px" OnClick="UpdateBtn_Click" />
                                </td>
                                <td class="auto-style13" style="width: 25%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style12" style="width: 50%">
                                    <asp:Label ID="UpdateReportLble" runat="server" ForeColor="#8992A1" Text=" "></asp:Label>
                                </td>
                                <td class="auto-style13" style="width: 25%"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
                <td align ="center" class="auto-style18" style="vertical-align: middle">
                    <asp:Image ID="SubmittedByImg" runat="server" Height="63px" ImageUrl="~/Resources/Images/SubmittedByYou.jpg" style="margin-top: 6px" Width="288px" />
                    </td>
            </tr>
            <tr>
                <td align ="center" class="auto-style14" style="vertical-align: top">
                    <br />
                    <asp:ImageButton ID="logoutImgBtn" runat="server" Height="45px" ImageUrl="~/Resources/Images/LogOutDefault.png" Width="140px" OnClick="logoutImgBtn_Click" CausesValidation="False" />
                    <br />
                    <br />
                    <asp:ImageButton ID="PasswordImgBtn" runat="server" Height="55px" ImageUrl="~/Resources/Images/ChangePasswordDefault.jpg" Width="150px" CausesValidation="False" PostBackUrl="~/ChangePassword.aspx" />
                    <br />
                    <br />
                    <asp:ImageButton ID="RecoverPassImgBtn" runat="server" Height="50px" ImageUrl="~/Resources/Images/RecoverPasswordDefault.jpg" PostBackUrl="~/RecoverPassword.aspx" Width="143px" />
                    <br />
                    <br />
                    <asp:ImageButton ID="SubmitImgBtn" runat="server" Height="55px" ImageUrl="~/Resources/Images/SubmitABookDefault.jpg" Width="150px" OnClick="SubmitImgBtn_Click" CausesValidation="False" />
                    <br />
                    <asp:Image ID="Image3" runat="server" Height="102px" ImageUrl="~/Resources/Images/AccountHelp.jpg" Width="247px" />
                    </td>
                <td align ="center" style="width: 25%; vertical-align: top;">
                    <asp:GridView ID="SubmittedGV" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BookId" ForeColor="#333333" GridLines="None" Height="191px" ShowHeader="False" Width="264px" AllowCustomPaging="True" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="3">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="BookId" HeaderText="BookId" InsertVisible="False" ReadOnly="True" SortExpression="BookId" Visible="False" />
                            <asp:ImageField DataImageUrlField="BookImageUrl">
                            </asp:ImageField>
                            <asp:BoundField DataField="BookName" SortExpression="BookName" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Resources/Images/ReadMoreSized.jpg" ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle Font-Bold="True" ForeColor="Black" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 25%">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
