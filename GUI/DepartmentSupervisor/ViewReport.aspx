<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="GUI.DepartmentSupervisor.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>  View Report </h1>
    Report ID:
    <asp:Label ID="lblReportID" runat="server"></asp:Label>
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Height="197px" Width="304px"></asp:ListBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnApprove" runat="server" BackColor="#33CC33" Height="39px" Text="Approve" Width="160px" />
    <asp:Button ID="btnReject" runat="server" BackColor="Red" Height="40px" OnClick="btnReject_Click" Text="Reject" Width="148px" />
    <br />
</asp:Content>
