<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitReport.aspx.cs" Inherits="GUI.Consultant.SubmitReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <!-- css code goes here-->
    <style type="text/css">
        .auto-style1 {
            width: 67px;
        }
    </style>

</head>
<body>
    <h3>New Report</h3>
    <form id="form1" runat="server">
        <!--use table layout to group the textboxes-->
        <table style="width: auto">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Location"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxLocation" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxDescription" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Currency"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dropdownlistCurrency" runat="server" Height="22px" Width="127px">
                        <asp:ListItem>AUD</asp:ListItem>
                        <asp:ListItem>CHN</asp:ListItem>
                        <asp:ListItem>EUR</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label6" runat="server" Text="Receipts"></asp:Label>
                </td>
                <td><asp:FileUpload ID="FileUpload1" runat="server" Width="220px" />
                    &nbsp;</td>
            </tr>

        </table>
        <asp:Button ID="btnAddExpense" runat="server" Text="Add Expense" Width="203px"/>
        <p />
        <asp:ListBox ID="listboxExpenses" runat="server" Width="258px"></asp:ListBox>
        <p />
        <asp:Button ID="btnSubmitReport" runat="server" Text="Submit Report" Width="99px" OnClick="btnSubmitReport_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Back" Width="104px" OnClick="btnBack_Click" />
        <asp:Label ID="labelStatus" runat="server"></asp:Label>
    </form>
</body>
</html>

