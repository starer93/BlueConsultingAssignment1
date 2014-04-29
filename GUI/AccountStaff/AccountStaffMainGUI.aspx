<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AccountStaffMainGUI.aspx.cs" Inherits="GUI.Account_Staff.AccountStaffMainGUI" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/BlueConsulting.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Account Staff</h1>
    <h2>Monthly Budgets</h2>
    <hr />
    <div style="text-align: center">

        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" AntiAliasing="Text">
            <Series>
                <asp:Series Name="series" IsValueShownAsLabel="True">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <asp:Chart ID="ChartTotal" runat="server" OnLoad="ChartTotal_Load">
            <Series>
                <asp:Series Name="Series2" IsValueShownAsLabel="True">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea2">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
        <br />
        <asp:Label ID="labRemainBudget" runat="server" Text="Company Total Remain Budget: "></asp:Label>
    </div>
    <h2>Reports</h2>
    <hr />
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Right">
        <asp:DropDownList ID="DropDownListMonthReport" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListYearReport" runat="server">
        </asp:DropDownList>
        <br />
        <div style="width: 50%; margin: 0 auto; text-align: left;">
            <table id ="TableReport" border="1" style="width: 100%; align-content: center">
                <tr>
                    <td>Report ID</td>
                    <td>Total Amount</td>
                    <td>Date</td>
                    <td>Receipt</td>
                    <td>Show Expenses</td>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="ListBoxReport" runat="server"></asp:ListBox>
                    </td>
                    <td>
                        <asp:Label ID="LabelAmount" runat="server" Text="[Amount]"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelDate" runat="server" Text="[Date]"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnReceipt" runat="server" Text="Receipt" OnClick="btnReceipt_Click" />
                    </td>
                     <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show Expenses" OnClick="btnShow_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>

    <div>

        <asp:ListView runat="server" ID="ListViewExpense">
            <LayoutTemplate>
                <div style="width: 50%; margin: 0 auto; text-align: center;">
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
    </div>

                <hr />
                <div style="text-align: center">
                    <asp:Button ID="ButtonApprove" runat="server" Text="Approve" OnClick="ButtonApprove_Click" />
                    <asp:Button ID="ButtonReject" runat="server" Text="Reject" OnClick="ButtonReject_Click" />
                </div>
</asp:Content>
