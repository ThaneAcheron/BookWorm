<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturedSidePanelLeft.ascx.cs" Inherits="Layouts_FeaturedSidePanel" %>
<asp:Panel ID="Panel1" runat="server" Height="493px" Width="247px" HorizontalAlign="Center" BorderColor="#0033CC">
    <asp:Image ID="Image1" runat="server" Height="94px" ImageUrl="~/Resources/Images/Featured.jpg" Width="233px" />
    <asp:GridView ID="FeaturedGV" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BookId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeader="False" Width="247px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="BookId" HeaderText="BookId" InsertVisible="False" ReadOnly="True" SortExpression="BookId" Visible="False" />
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Resources/Images/ReadMoreSized.jpg" ShowSelectButton="True" />
            <asp:ImageField DataImageUrlField="BookImageUrl">
            </asp:ImageField>
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
</asp:Panel>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWormConnectionString %>" SelectCommand="SELECT TOP 4 [BookId], [BookName], [BookImageUrl] FROM [BookInformation] ORDER BY [BookAverageRating] DESC"></asp:SqlDataSource>


