<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMainGUI.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.ConsultantMainGUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 130px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>ConsultantID:
        <asp:Label ID="lblUsername" runat="server" Text="[User]"></asp:Label>
        &nbsp;</h2>

    <table>
        <tr>
            <td style="vertical-align: top">
                <asp:Button ID="btnLoadReports" runat="server" Text="Load Reports" Width="130px" OnClick="btnLoadReports_Click" />
                <br />
                <asp:Button ID="btnCreateReport" runat="server" Text="Create Report" OnClick="btnCreateReport_Click" Width="130px" />
                <br />
                <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click" Width="130px" />
                <br />

            </td>


            <td>
                <asp:ListBox ID="listboxReports" runat="server" Width="388px" Height="213px" Style="margin-left: 0px"></asp:ListBox>
            </td>
            <td style="vertical-align: top">
                <asp:RadioButtonList ID="rblReportFilter" runat="server" Height="16px" Width="96px" OnInit="rblReportFilter_Init">
                    <asp:ListItem Value="0">Submitted</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="2">Pending</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="btnFilter" runat="server" Text="Filter" Width="93px" OnClick="btnFilter_Click" />

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="130px" OnClick="btnLogout_Click" Style="vertical-align: bottom" />

            </td>

        </tr>
    </table>

</asp:Content>
