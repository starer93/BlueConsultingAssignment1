<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMainGUI.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.ConsultantMainGUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>ConsultantID:
        <asp:Label ID="lblUsername" runat="server" Text="[User]"></asp:Label>
        &nbsp;</h2>

    <table>
        <tr>
            <td style="vertical-align: top">
                <asp:Button ID="btnCreateReport" runat="server" Text="Create Report" OnClick="btnCreateReport_Click" Width="130px" />
                <br />
                <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click" Width="130px" />
                <br />

            </td>


            <td>
                <asp:ListBox ID="listboxReports" runat="server" Width="388px" Height="213px" Style="margin-left: 0px"></asp:ListBox>
            </td>
            <td style="vertical-align: top">
                <asp:RadioButtonList ID="rblReportFilter" runat="server" Height="16px" Width="260px" OnInit="rblReportFilter_Init" OnSelectedIndexChanged="rblReportFilter_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Submitted by Consultant</asp:ListItem>
                    <asp:ListItem Value="1">Approved by Department Supervisor</asp:ListItem>
                    <asp:ListItem Value="2">Approved by Account Staff</asp:ListItem>
                    <asp:ListItem>Rejected by Department Supervisor</asp:ListItem>
                    <asp:ListItem>Rejected by Account Staff</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="130px" OnClick="btnLogout_Click" Style="vertical-align: bottom" />
            </td>
        </tr>
    </table>

</asp:Content>
