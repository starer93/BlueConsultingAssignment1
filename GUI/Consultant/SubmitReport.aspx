<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitReport.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.SubmitReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 140px;
        }

        .auto-style3 {
            height: 87px;
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
            <td class="auto-style2">
                <h3>Expense Details</h3>
            </td>
            <td></td>
            <td>
                <h3>Expenses List</h3>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label1" runat="server">Location</asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server">Description</asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server">Amount</asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server">Currency</asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server">Receipts</asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                <br />
                <asp:DropDownList ID="listCurrency" runat="server" Height="22px" Width="127px">
                    <asp:ListItem>AUD</asp:ListItem>
                    <asp:ListItem>CHN</asp:ListItem>
                    <asp:ListItem>EUR</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:FileUpload ID="fupReceipts" runat="server" Width="212px" />
            </td>
            <td class="auto-style3">
                <asp:ListBox ID="listboxExpenses" runat="server" Width="245px" Height="112px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddExpense" runat="server" Text="Add Expense" Width="122px" OnClick="btnAddExpense_Click" />
            </td>
            <td>
                <asp:Button ID="btnSubmitReport" runat="server" Text="Submit Report" Width="150px" OnClick="btnSubmitReport_Click" />
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


