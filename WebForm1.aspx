<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Breakfast_Cards_Manage_System.WebForm1" %>

<!DOCTYPE html PUBlIC "-//W3C//DTD XHTML 1.1//EN>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-us">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Breakfast Cards Manage System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Breakfast Cards Manage System</h1>
        </div>
        <div>
            <h2>早餐卡管理系统</h2>
        </div>
        <hr />
        <br />
        <div>
            This Month:
         
            <asp:Label ID="Label_ThisYearMonth" runat="server"  Text="Label"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
        <br />
        <hr />
        <div>
            <br>If don't need modify,no change,please click "Confirm".<br>
            如果不需要修改，没有变化，请按下“Comfirm”.<asp:Button ID="Comfirm" runat="server" Text="Confirm" OnClick="Comfirm_Click" />
        </div>
        <br />
        <hr />
        <br />
        <div>
            Otherwise,please medify quantity below.请下面修改数量。
        </div>
        <div>
            Group Name：
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Intune</asp:ListItem>
                <asp:ListItem>Office</asp:ListItem>
                <asp:ListItem>SCCM</asp:ListItem>
                <asp:ListItem>Teams</asp:ListItem>
                <asp:ListItem>POD1</asp:ListItem>
                <asp:ListItem>POD2</asp:ListItem>
                <asp:ListItem>S500 team1</asp:ListItem>
                <asp:ListItem>S500 team2</asp:ListItem>
                <asp:ListItem>SharePoint</asp:ListItem>
            </asp:DropDownList>
            Quantity:
            <asp:TextBox ID="TextBox1" runat="server" Width="126px"></asp:TextBox>
            <asp:Button ID="Modify" runat="server" OnClick="Modify_Click" Text="Modify" />
        </div>
        <div>
            Next Month:
         
            <asp:Label ID="Label_NextYearMonth" runat="server"  Text="Label"></asp:Label>
        </div>
        <hr />
        <div>
            Add:增加：<br />
            Year:<asp:DropDownList ID="DropDownList_Add_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Add_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Add_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            Quantity:<asp:TextBox ID="TextBox_Add_Quantity" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Add_Comfirm" runat="server" Text="Add" OnClick="Button_Add_Comfirm_Click" />
        </div>
        <div>
            Delete:删除：<br />
            Year:<asp:DropDownList ID="DropDownList_Delete_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Delete_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Delete_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            <asp:Button ID="Button_Delete" runat="server" Text="Delete" OnClick="Button_Detele_Click" />
        </div>
        <div>
            Revise:修改：<br />
            Year:<asp:DropDownList ID="DropDownList_Revise_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Revise_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Revise_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            Quantity:<asp:TextBox ID="TextBox_Revise_Quantity" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Revise" runat="server" Text="Revise" />
        </div>
        <div>
            Inquiry:查询<br />
            Year:<asp:DropDownList ID="DropDownList_Inquiry_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Inquiry_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Inquiry_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            <asp:Button ID="Button_Inquiry" runat="server" Text="Inquiry" />
        </div>
        <hr />
        <div style="font-family:Arial">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="YearMonth" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="YearMonth" HeaderText="YearMonth" ReadOnly="True" SortExpression="YearMonth" />
                    <asp:BoundField DataField="Intune" HeaderText="Intune" SortExpression="Intune" />
                    <asp:BoundField DataField="Office" HeaderText="Office" SortExpression="Office" />
                    <asp:BoundField DataField="SCCM" HeaderText="SCCM" SortExpression="SCCM" />
                    <asp:BoundField DataField="Teams" HeaderText="Teams" SortExpression="Teams" />
                    <asp:BoundField DataField="POD1" HeaderText="POD1" SortExpression="POD1" />
                    <asp:BoundField DataField="POD2" HeaderText="POD2" SortExpression="POD2" />
                    <asp:BoundField DataField="S500_1" HeaderText="S500_1" SortExpression="S500_1" />
                    <asp:BoundField DataField="S500_2" HeaderText="S500_2" SortExpression="S500_2" />
                    <asp:BoundField DataField="SharePoint" HeaderText="SharePoint" SortExpression="SharePoint" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BreakfastCardsConnectionString %>" SelectCommand="SELECT [YearMonth], [Intune], [Office], [SCCM], [Teams], [POD1], [POD2], [S500_1], [S500_2], [SharePoint] FROM [Cards]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
