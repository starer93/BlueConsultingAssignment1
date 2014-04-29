<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepartmentSupervisorMainGUI.aspx.cs" Inherits="GUI.DepartmentSupervisor.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 195px;
        }

        .auto-style2 {
            width: 221px;
        }

        .auto-style3 {
            width: 100px;
        }

        .auto-style5 {
            width: 117px;
        }

        .auto-style6 {
            width: 134px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="title">Department Supervisor</div>

    <div>
        <br />
        Welcome,
        <asp:Label ID="lblCurrentUser" runat="server"></asp:Label>
        <br />
        <h3>Department Information</h3>
        <table border="1">
            <tr>
                <td class="auto-style2">Department Name</td>
                <td>
                    <asp:Label ID="lblDepartmentName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Department Budget
                </td>
                <td>
                    <asp:Label ID="lblTotalBudget" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Remaining Budget
                </td>
                <td>
                    <asp:Label ID="lblRemainingBudget" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Expense Reports Approved
                </td>
                <td>
                    <asp:Label ID="lblExpensesApproved" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <h3>Reports List</h3>
        <table>
            <tr>
                <td class="auto-style3">Select Date: </td>
                <td class="auto-style6">

                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" Width="133px">
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
                <td class="auto-style5">

                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Width="133px" Style="margin-left: 0px">
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem Selected="True">2014</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    [ReportID, Report Status, Submitted Date]
                </td>
            </tr>
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
                        <asp:ListItem>Rejected by Account Staff</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnViewReport" runat="server" Text="View Report" OnClick="btnViewReport_Click" Height="40px" Width="200px" />
    </div>


</asp:Content>
