<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="GUI.DepartmentSupervisor.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="title">View Report </div>
    <br />
    Report ID:
    <asp:Label ID="lblReportID" runat="server"></asp:Label>
    <br />
    <h3>Expense List</h3>
    <asp:ListView ID="listViewExpenses" runat="server">
        <LayoutTemplate>
            <div style="width: 100%; margin: 0 auto;">
                <table border="1" style="width: 100%">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Description</th>
                            <th>Location</th>
                            <th>Amount</th>
                            <th>Currency</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </tbody>
                </table>
            </div>
            <hr />
            <div style="text-align: center">
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><%# Eval("description") %></td>
                <td><%# Eval("location") %></td>
                <td><%# Eval("amount") %></td>
                <td><%# Eval("currency") %></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            No records found
  
        </EmptyDataTemplate>
    </asp:ListView>

    <br />
    <asp:Button ID="btnViewReceipt" runat="server" OnClick="btnViewReceipt_Click" Text="View Receipt" Width="306px" Height="40px" />
    <br />
    <br />
    <div id="reportinfo">
        <asp:Label ID="lblReportInformation" runat="server">ok</asp:Label>
    </div>
    <asp:Button ID="btnApprove" runat="server" BackColor="#33CC33" Height="39px" Text="Approve" Width="160px" OnClick="btnApprove_Click" />
    <asp:Button ID="btnReject" runat="server" BackColor="Red" Height="40px" OnClick="btnReject_Click" Text="Reject" Width="148px" />
    <br />
    <br />
</asp:Content>
