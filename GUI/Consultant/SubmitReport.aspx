<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitReport.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.SubmitReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 150px;
        }

        .auto-style6 {
            width: 150px;
            height: 26px;
        }

        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            height: 25px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

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
                <b>Expense Details</b>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="Label1" runat="server">Location</asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label6" runat="server">Description</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label3" runat="server">Amount</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label4" runat="server">Currency</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="listCurrency" runat="server" Height="22px" Width="127px">
                    <asp:ListItem>AUD</asp:ListItem>
                    <asp:ListItem>CNY</asp:ListItem>
                    <asp:ListItem>EUR</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
    <asp:Label ID="labErrorMessage" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="btnAddExpense" runat="server" Text="Add Expense" Width="150px" OnClick="btnAddExpense_Click" />
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

    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnAddReceipt" runat="server" Text="Add Receipt" Width="150px" OnClick="btnSubmitReport_Click" Enabled="False" />
    <asp:Button ID="btnClose" runat="server" Text="Close" Width="150px" OnClick="btnClose_Click" />


</asp:Content>


