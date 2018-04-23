<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginPanel.ascx.cs" Inherits="Layouts_LoginPanel" %>
<style type="text/css">
    .auto-style1 {
        height: 86px;
    }
    .auto-style2 {
        height: 70px;
    }
    .auto-style3 {
        height: 86px;
        width: 187px;
    }
    .auto-style4 {
        height: 70px;
        width: 187px;
    }
    .auto-style5 {
        width: 187px;
    }
</style>
<asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Resources/Images/LogInPanel.jpg" style="margin-bottom: 0px; position: relative; top: 0px; left: 0px; height: 750px; margin-left: 0px; width: 232px;" HorizontalAlign="Center">
    <table style="width:100%; height: 334px;">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style3" style="vertical-align: middle; text-align: center"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style4" style="vertical-align: middle; text-align: center">
                <asp:Label ID="EmailLble" runat="server" ForeColor="#514634" Text="E-mail"></asp:Label>
                <br />
                <asp:TextBox ID="UserEmailTxtb" runat="server" Width="117px"></asp:TextBox>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
            <td class="auto-style4" style="vertical-align: middle; text-align: center">
                <asp:Label ID="PasswordLble" runat="server" ForeColor="#514634" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="PasswordTxtb" runat="server" TextMode="Password" Width="117px"></asp:TextBox>
            </td>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" style="vertical-align: middle; text-align: center">
                <asp:ImageButton ID="LoginBtn" runat="server" Height="34px" ImageUrl="~/Resources/Images/LoginDefault.jpg" OnClick="LoginBtn_Click" Width="101px" CausesValidation="False" />
                <br />
                <asp:CheckBox ID="KeepLoggedInChb" runat="server" ForeColor="#514634" Text="Keep me logged in" style="white-space: nowrap;"/>
                <br />
                <br />
                <asp:Label ID="ErrorLble" runat="server" Text="The username or password are incorrect." Visible="False" Font-Italic="True" ForeColor="#514634"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" style="vertical-align: middle; text-align: center">
                <asp:ImageButton ID="ForgotPassImgBtn" runat="server" ImageUrl="~/Resources/Images/ForgotPasswordDefault.png" Width="165px" PostBackUrl="~/RecoverPassword.aspx" CausesValidation="False" />
            </td>
        </tr>
    </table>
    <table style="width:100%; height: 334px;">
        <tr>
            <td class="auto-style5" style="vertical-align: top; text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Panel>

