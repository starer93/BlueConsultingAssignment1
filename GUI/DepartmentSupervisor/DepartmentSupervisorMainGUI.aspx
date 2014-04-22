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
                <td class="auto-style1">
                    <p>
                    Expenses Approved: 
                    <asp:Label ID="lblExpensesApproved" runat="server"></asp:Label></p>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="auto-style1">
                    
                    <asp:DropDownList ID="ddlMonth" runat="server">
                        <asp:ListItem Value="01">January</asp:ListItem>
                        <asp:ListItem Value="02">February</asp:ListItem>
                        <asp:ListItem Value="03">March</asp:ListItem>
                        <asp:ListItem Selected="True" Value="04">April</asp:ListItem>
                        <asp:ListItem Value="05">May</asp:ListItem>
                        <asp:ListItem Value="06">June</asp:ListItem>
                        <asp:ListItem Value="07">July</asp:ListItem>
                        <asp:ListItem Value="08">August</asp:ListItem>
                        <asp:ListItem Value="09">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
                <td class="auto-style1">
                    
                    <asp:DropDownList ID="ddlYear" runat="server">
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem Selected="True">2014</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblReportsDescription" runat="server"></asp:Label>
        <br />
        
        <table>
            <tr>
                <td class="auto-style1">
                    <p>
                        <asp:ListBox ID="listBoxReports" runat="server" Height="211px" Width="375px"></asp:ListBox>
                        </p>
                </td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="radioButtonReportFilter" runat="server" OnSelectedIndexChanged="radioButtonReportFilter_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True">All Reports</asp:ListItem>
                        <asp:ListItem>Pending Reports</asp:ListItem>
                        <asp:ListItem>Approved Reports</asp:ListItem>
                        <asp:ListItem>Rejected Reports</asp:ListItem>
                        <asp:ListItem>Rejected by Account Staff</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnViewReport" runat="server" Text="View Report" OnClick="btnViewReport_Click" />
    </div>
</asp:Content>
