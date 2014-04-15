<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMainGUI.aspx.cs"  Inherits="GUI.Consultant.ConsultantMainGUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Blue Consulting - Consultant</h1>
        <table>
            <tr>
                <td>
                    <p>
                        Welcome,        
                        <asp:Label ID="lblTest" runat="server" Text="Test"></asp:Label>
                    </p>
                </td>
                <td>
                    <asp:Label ID="labelDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="listboxReports" runat="server" Width="328px" Height="208px"></asp:ListBox>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="204px">
                        <asp:ListItem>Filter1</asp:ListItem>
                        <asp:ListItem>Filter2</asp:ListItem>
                        <asp:ListItem>Filter3</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnCreateReport" runat="server" Text="Create Report" OnClick="btnCreateReport_Click" />
        <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click" />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="94px" OnClick="btnLogout_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
