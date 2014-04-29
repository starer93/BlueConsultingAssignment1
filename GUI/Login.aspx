<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="BlueConsulting.css" rel="stylesheet" type="text/css" />

</head>

<body>
    <form id="form1" runat="server">
        <div id="top">
            <table>
                <tr>
                    <td>Blue Consulting
                    </td>
                </tr>
            </table>
            <br />
        </div>

        <div id="middle">

            <asp:Login ID="Login1" runat="server">
            </asp:Login>
        </div>

        <div id="bottom">
            <asp:Label ID="Label2" runat="server" Text="Date: "></asp:Label>
            <asp:Label ID="lblDate" runat="server" Text="[Value]"></asp:Label>
            <br />
            <br />
        </div>
    </form>

</body>
</html>
