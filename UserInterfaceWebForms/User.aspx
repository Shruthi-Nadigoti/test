<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication1.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="border-color:black;border-width:thick;background-color:lightgray;margin-left:200px;" >
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter the Details:"></asp:Label>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="First Name :"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Last Name :"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Date of Birth :"></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </p>
        <p>
            Phone No :<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p>
            Email No:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Height="56px" Width="184px"></asp:TextBox>
        </p>
    </form>
        </div>
</body>
</html>
