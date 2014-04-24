<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReport.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="GUI.Consultant.ShowReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Preview Report</h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="SelectedReportID: "></asp:Label>
        <asp:Label ID="lblSelectedReportID" runat="server" Text="[value]"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtReportPreview" runat="server" Height="147px" TextMode="MultiLine" Width="342px" Wrap="False" ReadOnly="True"></asp:TextBox>
    </p>
    <div>
        <asp:Button ID="btnViewReceipt" runat="server" Text="View Receipt" OnClick="btnViewReceipt_Click" />
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" Width="92px" />
    </div>
</asp:Content>

