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
        <br />
    
    </div>
         <asp:ListBox ID="ListBoxReport" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBoxReport_SelectedIndexChanged"></asp:ListBox>
        <div>
       <asp:ListView runat="server" ID="ListViewReport" >
         <LayoutTemplate> 
             <table border="1" style="width:300px"> 
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
             <asp:Button ID="ButtonApprove" runat="server" Text="Approve"/>
             <asp:Button ID="ButtonReject" runat="server" Text="Reject"/>
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
    </form>
</body>
</html>
