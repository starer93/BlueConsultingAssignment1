<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMainGUI.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.ConsultantMainGUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Consultant</h1>
    <table>
        <tr>
            <td>
                <p>
                    Welcome,        
                        <asp:Label ID="lblUsername" runat="server" Text="User"></asp:Label>
                </p>
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="listboxReports" runat="server" Width="328px" Height="208px"></asp:ListBox>
            </td>
            <td>
                <asp:RadioButtonList ID="rblReportFilter" runat="server" Height="177px" Width="179px" OnInit="rblReportFilter_Init">
                    <asp:ListItem Value="0">All reports</asp:ListItem>
                    <asp:ListItem Value="1">Submitted reports</asp:ListItem>
                    <asp:ListItem Value="2">Approved reports</asp:ListItem>
                    <asp:ListItem Value="3">Submitted but not yet approved reports (Pending)</asp:ListItem>
                </asp:RadioButtonList>
                        <asp:Button ID="btnFilter" runat="server" Text="Filter" Width="180px" OnClick="btnFilter_Click"/>

            </td>
            <td>
                <asp:TextBox ID="txtReportPreview" runat="server" Height="190px" TextMode="MultiLine" Width="342px" Wrap="False" ReadOnly="True" Style="margin-top: 0px"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Button ID="btnCreateReport" runat="server" Text="Create Report" OnClick="btnCreateReport_Click"/>
    <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click"/>
    <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="94px" OnClick="btnLogout_Click"/>

    <asp:Label ID="Label1" runat="server" Text="SelectedReport: "></asp:Label>
    <asp:Label ID="lblSelectedReport" runat="server" Text="Value"></asp:Label>
</asp:Content>


