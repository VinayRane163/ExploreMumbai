<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Panel.aspx.cs" Inherits="ExploreMumbai.Admin_Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .dashboard-container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: mintcream;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 1);
            margin-top: 50px;
        }

        .dashboard-button {
            
            width: 100%;
            margin-bottom: 15px;
            font-size: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="dashboard-container">
             <center > <h2 class="dashboard-heading">Admin Dashboard</h2></center>  


        <a href="Guide_Register.aspx" class="btn btn-info dashboard-button">Add Guide</a>
        <a href="edit_guide.aspx" class="btn btn-info dashboard-button">Edit Guide</a>
        <a href="Add_tours.aspx" class="btn btn-info dashboard-button">Add Pack</a>
        <a href="edit_tours.aspx" class="btn btn-info dashboard-button">Edit Pack</a>
        <a href="admin_cancellation.aspx" class="btn btn-info dashboard-button">Cancel Booking Request</a>
        <a href="Admin_Review.aspx" class="btn btn-info dashboard-button">Review</a>
        <a href="Home_Admin.aspx" class="btn btn-info dashboard-button">Home page</a>
        <a href="View_Application.aspx" class="btn btn-info dashboard-button">Applications</a>
        <a href="Booking_display_admin.aspx" class="btn btn-info dashboard-button">Bookings</a>
        <asp:Button ID="Btn_Logout" runat="server" OnClick="BtnLogout_Click" Text="Logout" CssClass="btn btn-danger dashboard-button" />
    </form>
</body>
</html>
