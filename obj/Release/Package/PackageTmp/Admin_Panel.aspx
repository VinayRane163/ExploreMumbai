<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Panel.aspx.cs" Inherits="ExploreMumbai.Admin_Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server" class="container">
        <div class="mt-5">
            <asp:Button ID="Btn_Logout" runat="server" OnClick="BtnLogout_Click" Text="Logout" CssClass="btn btn-danger" />
            <br />
            <br />
            <a href="Guide_Register.aspx" class="btn btn-primary">Add Guide</a>
            <br />
            <br />
            <a href="Add_tours.aspx" class="btn btn-success">Add Pack</a>
            <br /> 
            <br />
            <a href="edit_tours.aspx" class="btn btn-warning">Edit Pack</a>
            <br /> 
            <br />
            <a href="Home.aspx" class="btn btn-info">Home page</a>
             <br /> 
             <br />
             <a href="Booking_display_admin.aspx" class="btn btn-info">Bookings</a>
        </div>
    </form>
</body>
</html>
