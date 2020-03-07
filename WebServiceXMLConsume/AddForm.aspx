<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddForm.aspx.cs" Inherits="WebServiceXMLConsume.AddForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="font-family:Arial">
            <tr>
                <td>
                    First Number
                </td>
                <td>
                    <asp:TextBox ID="txtFirstNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Second Number
                </td>
                <td>
                    <asp:TextBox ID="txtSecondNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Result
                </td>
                <td>
                    <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
