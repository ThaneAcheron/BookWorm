<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" UnobtrusiveValidationMode ="None" %>

<%@ Register src="Layouts/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="Layouts/FeaturedSidePanelLeft.ascx" tagname="FeaturedSidePanelLeft" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 355px;
        }
        .auto-style5 {
            width: 50%;
        }
        .auto-style10 {
            width: 50%;
            height: 80px;
        }
        .auto-style13 {
            height: 86px;
        }
        .auto-style16 {
            height: 86px;
            width: 50%;
        }
        .auto-style17 {
            width: 50%;
            height: 70px;
        }
        .auto-style18 {
            height: 70px;
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
                <td align ="center" class="auto-style1" style="width: 25%; vertical-align: top;">
                    <asp:ImageButton ID="BackImgBtn" runat="server" Height="80px" ImageUrl="~/Resources/Images/BackArrowDefault.jpg" Width="230px" CausesValidation="False" PostBackUrl="~/Account.aspx" />
                    <br />
                    <uc2:FeaturedSidePanelLeft ID="FeaturedSidePanelLeft1" runat="server" />
                </td>
                <td align ="center" style="width: 50%; vertical-align: top;">
                    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Resources/Images/AccountPanel.jpg" Height="415px" Width="535px">
                        <table style="width:100%; height: 100%;">
                            <tr>
                                <td class="auto-style13"></td>
                                <td class="auto-style16" style="text-align: center; vertical-align: middle; ">
                                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="Change your password"></asp:Label>
                                </td>
                                <td class="auto-style13" style="2"></td>
                            </tr>
                            <tr>
                                <td rowspan="2" style="width: 25%">&nbsp;</td>
                                <td class="auto-style17" style="vertical-align: middle; text-align: center; ">
                                    <asp:Label ID="OldPassLble" runat="server" Text="Old password" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="OldPassTxtb" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="OldPassWarningLble" runat="server" Text=" " ForeColor="White"></asp:Label>
                                </td>
                                <td style="2" class="auto-style18">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="OldPassTxtb" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17" style="vertical-align: middle; text-align: center; ">
                                    <asp:Label ID="NewPassLble" runat="server" Text="New password" ForeColor="White"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="NewPassTxtb" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                </td>
                                <td style="2" class="auto-style18">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NewPassTxtb" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="3" style="width: 25%">&nbsp;</td>
                                <td class="auto-style17" style="vertical-align: middle; text-align: center; ">
                                    <asp:Label ID="ConfirmPassLble" runat="server" ForeColor="White" Text="Confirm new password"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="ConfirmPassTxtb" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords don't match" ForeColor="White" ControlToCompare="ConfirmPassTxtb" ControlToValidate="NewPassTxtb"></asp:CompareValidator>
                                </td>
                                <td style="2" class="auto-style18">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmPassTxtb" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10" style="vertical-align: top; text-align: center; ">
                                    <asp:ImageButton ID="UpdateImgBtn" runat="server" Height="50px" ImageUrl="~/Resources/Images/UpdateDefault.png" Width="130px" OnClick="UpdateImgBtn_Click" />
                                    <br />
                                    <asp:Label ID="UpdateResultLble" runat="server" Text=" " ForeColor="White"></asp:Label>
                                </td>
                                <td style="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style5" style="vertical-align: middle; text-align: center; ">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td align ="center" style="width: 25%; vertical-align: top;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/Images/ResetPassInstructions.jpg" Height="85px" Width="230px" />
                    <br />
                    <asp:Image ID="Image3" runat="server" Height="160px" ImageUrl="~/Resources/Images/UserIcon.jpg" Width="170px" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
