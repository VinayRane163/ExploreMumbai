<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_tours.aspx.cs" Inherits="ExploreMumbai.edit_tours" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Tours</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="form-group">
            <label for="TourId">Enter Tour ID:</label>
            <asp:TextBox ID="TourId" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSelect" runat="server" OnClick="BtnSelect_Click" Text="Select" CssClass="btn btn-primary" />
            <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" CssClass="btn btn-success" />
            <asp:Button ID="btnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" CssClass="btn btn-danger" />
        </div>
        <!-- Display selected tour details in textboxes -->
        <div class="form-group">
            <label for="Tour_Name">Tour Name:</label>
            <asp:TextBox ID="Tour_Name" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tour_Price">Tour Price:</label>
            <asp:TextBox ID="Tour_Price" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tour_Description">Tour Description:</label>
            <asp:TextBox ID="Tour_Description" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <!-- Display additional feedback or messages -->
        <div runat="server" id="TourDetails" class="mt-3"></div>
    </form>
</body>
</html>
