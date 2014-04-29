<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReport.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.ShowReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Preview Report</h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="SelectedReportID: "></asp:Label>
        <asp:Label ID="lblSelectedReportID" runat="server" Text="[value]"></asp:Label>
    </p>

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


    <div id="reportinfo">
        <asp:Label ID="lblReportInformation" runat="server" Visible="False"></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnViewReceipt" runat="server" Text="View Receipt" OnClick="btnViewReceipt_Click" />
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" Width="92px" />
    </div>
</asp:Content>

