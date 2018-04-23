<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" UnobtrusiveValidationMode ="None" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/LoginPanel.ascx" tagname="LoginPanel" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style17 {
            width: 312px;
            height: 72px;
        }
        .auto-style18 {
            height: 72px;
        }
        .auto-style19 {
            width: 312px;
        }
        .auto-style29 {
            height: 89px;
        }
        .auto-style31 {
            width: 311px;
            height: 89px;
        }
        .auto-style32 {
            width: 72px;
            height: 89px;
        }
        .auto-style33 {
            width: 311px;
            height: 61px;
        }
        .auto-style34 {
            height: 61px;
            width: 72px;
        }
        .auto-style35 {
            height: 61px;
        }
        .auto-style36 {
            width: 311px;
            height: 41px;
        }
        .auto-style37 {
            height: 41px;
            width: 72px;
        }
        .auto-style38 {
            height: 41px;
        }
        .auto-style39 {
            width: 25%;
            height: 755px;
        }
        .auto-style40 {
            width: 50%;
            height: 755px;
        }
        .auto-style41 {
            height: 89px;
            width: 163px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
        <table style="width: 100%; height: 237px; position: relative;">
            <tr>
                <td align = "center" class="auto-style39">
                    <uc2:LoginPanel ID="LoginPanel1" runat="server" />
                </td>
                <td align ="center" style="vertical-align: top" class="auto-style40">
                    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Resources/Images/Register.jpg" Height="751px" style="margin-left: 14px; margin-right: 0px; position: relative;" Width="701px" HorizontalAlign="Center">
                        <table style="width: 100%; height: 553px;">
                            <tr>
                                <td class="auto-style33">
                                </td>
                                <td class="auto-style34"></td>
                                <td class="auto-style35" colspan="2" style="vertical-align: middle; text-align: center"></td>
                            </tr>
                            <tr>
                                <td class="auto-style36" style="vertical-align: top; text-align: center">
                                    &nbsp;</td>
                                <td class="auto-style37">&nbsp;</td>
                                <td class="auto-style38" colspan="2" style="vertical-align: middle; text-align: center">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style31">
                                    <asp:Label ID="UsernameLble" runat="server" Text="Username:" ForeColor="#514434"></asp:Label>
                                </td>
                                <td class="auto-style32"></td>
                                <td class="auto-style41" style="vertical-align: middle; text-align: center">
                                    <asp:TextBox ID="UsernameTxtb" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style29" style="vertical-align: middle; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UsernameTxtb" ErrorMessage="Please enter a user name " ForeColor="#514434">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style31">
                                    <asp:Label ID="EmailLble" runat="server" ForeColor="#514434" Text="E-mail:"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;</td>
                                <td class="auto-style41" style="vertical-align: middle; text-align: center">
                                    <asp:TextBox ID="EmailTxtb" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style29" style="vertical-align: middle; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTxtb" ErrorMessage="Please enter an E-mail address" ForeColor="#514434">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTxtb" ErrorMessage="E-mail is not valid " ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#514434">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style31">
                                    <asp:Label ID="PassworLble" runat="server" ForeColor="#514434" Text="Password:"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Re-enter password" ForeColor="#514434"></asp:Label>
                                </td>
                                <td class="auto-style32"></td>
                                <td class="auto-style41" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="PasswordTxtb" runat="server" style="" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:TextBox ID="ConfirmPassTxtb" runat="server" style="" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="auto-style29" style="text-align: left; vertical-align: middle;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PasswordTxtb" ErrorMessage="Please enter a password">*</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ConfirmPassTxtb" ControlToValidate="PasswordTxtb" Display="None" ErrorMessage="Passwords do not match" ForeColor="#514434">*</asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassTxtb" ErrorMessage="Please confirm your password" ForeColor="#514434">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style31">
                                    <asp:Label ID="SecurityLble" runat="server" ForeColor="#514434" Text="Security Question: &lt;br&gt; Security Answer: "></asp:Label>
                                </td>
                                <td class="auto-style32"></td>
                                <td class="auto-style41" style="vertical-align: middle; text-align: center">
                                    <asp:DropDownList ID="SecurityDdl" runat="server" style="">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:TextBox ID="SecurityTxtb" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style29" style="vertical-align: middle; text-align: left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SecurityTxtb" ErrorMessage="Please enter a Security Answer" ForeColor="#514434">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style31">
                                    <asp:Label ID="ReportBackLble" runat="server" ForeColor="#514434" Text=" "></asp:Label>
                                </td>
                                <td class="auto-style32"></td>
                                <td class="auto-style41" style="vertical-align: middle; text-align: center">
                                    <asp:ImageButton ID="SubmitImgBtn" runat="server" Height="43px" ImageUrl="~/Resources/Images/SubmitDefault.png" Width="133px" OnClick="SubmitImgBtn_Click" />
                                </td>
                                <td class="auto-style29" style="vertical-align: middle; text-align: center">&nbsp;</td>
                            </tr>
                        </table>

                    </asp:Panel>
                </td>
                <td align ="center" class="auto-style39" style="vertical-align:top; width: 25%;">
                    <asp:Image ID="Image1" runat="server" Height="301px" ImageUrl="~/Resources/Images/LoginOrRegister.jpg" Width="123px" style="vertical-align:top; text-align: justify; margin-left: 0px; position: relative; top: 0px; left: 0px;" />
                    <br />
                                    <asp:ValidationSummary ID="RegisterValSum" runat="server" DisplayMode="List" ForeColor="#514434" HeaderText="The following errors occured:" Font-Italic="True" />
                </td>
            </tr>
            <tr>
                <td class="auto-style17" style="width: 25%"></td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style18" style="width: 25%; vertical-align: top; text-align: center;">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19" style="width: 25%">&nbsp;</td>
                <td>&nbsp;</td>
                <td style="width: 25%; vertical-align: top; text-align: center;">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
