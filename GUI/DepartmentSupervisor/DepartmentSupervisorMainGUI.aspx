<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepartmentSupervisorMainGUI.aspx.cs" Inherits="GUI.DepartmentSupervisor.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Department Supervisor</h1>
    <div>
    
        Welcome,
        <asp:Label ID="lblCurrentUser" runat="server"></asp:Label>
        <br />
        <br />
    <table>
            <tr>
                <td class="auto-style1">
                    <p>
                        Department Name:<asp:Label ID="lblDepartmentName" runat="server"></asp:Label>
                        ||</p>
                </td>
                <td class="auto-style1">
                    <p>
                    Department Budget:<asp:Label ID="lblTotalBudget" runat="server"></asp:Label> || </p>
                </td>
                <td class="auto-style1">
                    <p>
                    Remaining Budget: 
                    <asp:Label ID="lblRemainingBudget" runat="server"></asp:Label></p>
                </td>
            </tr>
        </table>
        <br />
        
        <table>
            <tr>
                <td class="auto-style1">
                    <p>
                        <asp:ListBox ID="listBoxReports" runat="server" Height="211px" Width="262px"></asp:ListBox>
                        </p>
                </td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>All Reports</asp:ListItem>
                        <asp:ListItem>Approved Reports</asp:ListItem>
                        <asp:ListItem>Rejected Reports</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnViewReport" runat="server" Text="View Report" />
    </div>
</asp:Content>
