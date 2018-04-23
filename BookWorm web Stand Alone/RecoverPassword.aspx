<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" UnobtrusiveValidationMode ="None" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc2" %>

<%@ Register src="Layouts/LoginPanel.ascx" tagname="LoginPanel" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            width: 25%;
            height: 314px;
        }
        .auto-style3 {
            height: 314px;
        }
        .auto-style4 {
            width: 25%;
        }
        .auto-style5 {
            height: 86px;
        }
        .auto-style8 {
            width: 484px;
        }
        .auto-style16 {
            height: 60px;
        }
        .auto-style17 {
            height: 60px;
            width: 484px;
        }
        .auto-style18 {
            height: 44px;
            width: 484px;
        }
        .auto-style19 {
            height: 72px;
        }
        .auto-style20 {
            height: 44px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Header ID="Header1" runat="server" />
    
    </div>
        <table style="width: 100%; height: 340px;">
            <tr>
                <td align = "center" class="auto-style4" style="vertical-align: top; width: 25%;">
                    <asp:ImageButton ID="BackImgBtn" runat="server" CausesValidation="False" Height="80px" ImageUrl="~/Resources/Images/BackArrowDefault.jpg" Width="229px" />
                    <uc2:FeaturedSidePanelLeft ID="FeaturedSidePanelLeft1" runat="server" />
                    <uc3:LoginPanel ID="LoginPanel1" runat="server" />
                </td>
                <td align ="center" class="auto-style1" style="vertical-align: top; width: 50%;">
                    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Resources/Images/AccountPanel.jpg" Height="414px" Width="535px">
                        <table style="width:100%; height: 100%;">
                            <tr>
                                <td class="auto-style5" colspan="5" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="Reset Your Password" Width="80%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16"></td>
                                <td class="auto-style17" colspan="3" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="EmailLble" runat="server" Text="E-mail address" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTxtb" ErrorMessage="Email is not valid" ForeColor="White" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    <asp:TextBox ID="EmailTxtb" runat="server" Width="149px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter an e-mail address" ForeColor="White" ControlToValidate="EmailTxtb">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style16"></td>
                            </tr>
                            <tr>
                                <td rowspan="5">&nbsp;</td>
                                <td class="auto-style17" colspan="3" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="SecurityQuestionLble" runat="server" Text="Security question" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="SecurityQuestionDdl" runat="server" Height="22px" Width="150px">
                                    </asp:DropDownList>
                                    <br />
                                </td>
                                <td rowspan="5">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style17" colspan="3" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="AnswerLble" runat="server" Text="Answer" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="AnswerTxtb" runat="server" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter an answer" ForeColor="White" ControlToValidate="AnswerTxtb">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="NewPassLble" runat="server" Text="New password" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter a new password" ForeColor="White" ControlToValidate="NewPasswordTxtb">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="NewPasswordTxtb" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="auto-style20" style="vertical-align: middle; text-align: center">
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ConfirmPassTxtb" ControlToValidate="NewPasswordTxtb" ErrorMessage="Passwords do not match" ForeColor="White">*</asp:CompareValidator>
                                </td>
                                <td class="auto-style18" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="ConfirmPassLble" runat="server" Text="Confirm password" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="ConfirmPassTxtb" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please confirm your password" ForeColor="White" ControlToValidate="ConfirmPassTxtb">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style19" colspan="3" style="vertical-align: middle; text-align: center">
                                    <asp:Label ID="ReportBackLble" runat="server" Font-Italic="True" ForeColor="White" Text=" "></asp:Label>
                                    <br />
                                    <asp:ImageButton ID="SubmitImgBtn" runat="server" Height="38px" ImageUrl="~/Resources/Images/SubmitDefault.png" Width="116px" OnClick="SubmitImgBtn_Click" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8" colspan="3">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td align ="center" class="auto-style4" style="vertical-align: top; width: 25%;">
                    <asp:Image ID="Image2" runat="server" Height="83px" ImageUrl="~/Resources/Images/ResetPassInstructions.jpg" Width="230px" />
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="160px" ImageUrl="~/Resources/Images/PasswordIcon.png" Width="170px" />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="210px" DisplayMode="List" Font-Italic="True" ForeColor="#02A1BF" HeaderText="The following errors occured:" />
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
