<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ovning30.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div class="jumbotron text-center">
  <h1>Välkommen</h1>
  <p>Niklas Redgert är bäst!</p> 
</div>
        <div>
            <asp:ListBox ID="ListBoxContacts" CssClass="form-control text-center" runat="server" Height="250px" AutoPostBack="True" OnSelectedIndexChanged="ListBoxContacts_SelectedIndexChanged"></asp:ListBox>
            <table style="";>
                <tr>
                    <td>
                        <asp:Label ID="LabelFirstname" runat="server" Text="Firstname"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxFirstname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelLastname" runat="server" Text="Lastname"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxLastname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click"/></td>
                    <td>
                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click"/></td>
                    <td>
                        <asp:Button ID="ButtonRemove" runat="server" Text="Remove" OnClick="ButtonRemove_Click"/></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
