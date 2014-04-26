<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AccountStaffMainGUI.aspx.cs" Inherits="GUI.Account_Staff.AccountStaffMainGUI" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <p>
            <asp:DropDownList ID="DropDownListMonth" runat="server" CausesValidation="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListYear" runat="server">
            </asp:DropDownList>
        </p>
    <div>
    
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" AntiAliasing="Text">
            <series >
                <asp:Series Name="series" IsValueShownAsLabel="True">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    
        <asp:Chart ID="ChartTotal" runat="server" OnLoad="ChartTotal_Load">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
        <br />
        <br />
    
    </div>
        <asp:DropDownList ID="DropDownListMonthReport" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListYearReport" runat="server">
        </asp:DropDownList>
        <br />
        <table border="1">
            <tr>
                <td>
                    Report ID</td>
                <td>
                    Total Amount
                </td>
                <td>
                     Date
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
</asp:Content>
