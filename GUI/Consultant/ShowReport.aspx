<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReport.aspx.cs" Inherits="GUI.Consultant.ShowReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <h3>Preview Report</h3>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="txtReportPreview" runat="server" Height="147px" TextMode="MultiLine" Width="342px" Wrap="False" ReadOnly="True"></asp:TextBox>
        </p>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Edit" Width="87px" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Width="92px" />
        </div>
        <p>
            <asp:Label ID="lblSelectedReportID" runat="server" Text="SelectedReportID: "></asp:Label>
        </p>
    </form>
</body>
</html>
