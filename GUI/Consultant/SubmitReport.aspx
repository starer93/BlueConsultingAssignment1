<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitReport.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.SubmitReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 57px;
        }

        .auto-style5 {
            width: 150px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>New Expense Report</h2>
    <p>
        ConsultantID:                
        <asp:Label ID="lblConsultantID" runat="server">[Value] </asp:Label>
        Date:               
        <asp:Label ID="lblDate" runat="server">[Value]</asp:Label>
    </p>
    <table>
        <tr>
            <td>
                <b>Attach Receipt</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server">Receipts</asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fupReceipts" runat="server" Width="212px" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnCreateReport" runat="server" OnClick="btnCreateReport_Click" Text="Create Report" Width="150px" />
    <br />
    <br />
    <table>
        <tr>
            <td>
                <b>Expense Details</b>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server">Location</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLocation" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label6" runat="server">Description</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label3" runat="server">Amount</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label4" runat="server">Currency</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="listCurrency" runat="server" Height="22px" Width="127px" Enabled="False">
                    <asp:ListItem>AUD</asp:ListItem>
                    <asp:ListItem>CHN</asp:ListItem>
                    <asp:ListItem>EUR</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
    <asp:Button ID="btnAddExpense" runat="server" Text="Add Expense" Width="150px" OnClick="btnAddExpense_Click" Enabled="False" />
    <br />
    <br />
    <table>
        <tr>
            <td>
                <b>Expense List</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="listboxExpenses" runat="server" Width="275px" Height="70px"></asp:ListBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSubmitReport" runat="server" Text="Submit Report" Width="150px" OnClick="btnSubmitReport_Click" Enabled="False" />
    <asp:Button ID="btnClose" runat="server" Text="Close" Width="150px" OnClick="btnClose_Click" />
    <br />    
    <asp:Label ID="lblStatus" runat="server"></asp:Label>

</asp:Content>


