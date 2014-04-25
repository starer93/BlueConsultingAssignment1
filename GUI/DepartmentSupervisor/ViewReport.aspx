<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="GUI.DepartmentSupervisor.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>  View Report </h1>
    Report ID:
    <asp:Label ID="lblReportID" runat="server"></asp:Label>
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Height="197px" Width="431px"></asp:ListBox>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
