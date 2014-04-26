<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AccountStaffMainGUI.aspx.cs" Inherits="GUI.Account_Staff.AccountStaffMainGUI" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="~/BlueConsulting.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pan1" runat="server" HorizontalAlign="Center">
        <p>
            <asp:DropDownList ID="DropDownListMonth" runat="server" CausesValidation="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListYear" runat="server">
            </asp:DropDownList>
        </p>

        <div>

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

        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <asp:DropDownList ID="DropDownListMonthReport" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListYearReport" runat="server">
        </asp:DropDownList>
        <br />
        <div id ="table">
        <table border="1">
            <tr>
                <td>Report ID</td>
                <td>Total Amount
                </td>
                <td>Date
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ListBoxReport" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBoxReport_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td>
                    <asp:Label ID="LabelAmount" runat="server" Text="[Amount]"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelDate" runat="server" Text="[Date]"></asp:Label>
                </td>
                <td>
                    <button type="button">Reciept</button>
                </td>
            </tr>
        </table>
            </div>
    </asp:Panel>

    <div>

        <asp:ListView runat="server" ID="ListViewReport">
            <LayoutTemplate>
                <table  align="center" border="1" style="width: auto">
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
                <asp:Button ID="ButtonApprove" runat="server" Text="Approve" />
                <asp:Button ID="ButtonReject" runat="server" Text="Reject" />
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
</asp:Content>
