<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountStaffMainGUI.aspx.cs" Inherits="GUI.Account_Staff.AccountStaffMainGUI" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Account Staff</h2>
    <form id="form1" runat="server">
    <div>
    
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load">
            <series>
                <asp:Series Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    
        <br />
        Overall approved expenses:<br />
        <br />
        Reports<br />
        <asp:ListView ID="ListView1" runat="server">
        </asp:ListView>
    
    </div>
    </form>
</body>
</html>
