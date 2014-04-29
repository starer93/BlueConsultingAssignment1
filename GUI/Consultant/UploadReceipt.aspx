<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadReceipt.aspx.cs" Inherits="GUI.Consultant.UploadReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="fupReceipts" runat="server" Width="250px" />
    </div>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        <asp:Label ID="lblFileUpload" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>
</body>
</html>
