<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking_display_admin.aspx.cs" Inherits="ExploreMumbai.Booking_display_admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* Add any additional styling here */
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <h2>
                Booking
            </h2>
        </center>
        <table>
            <tr>
                <th>Booking ID</th>
                <th>User ID</th>
                <th>User Name</th>
                <th>User Mobile</th>
                <th>User Country</th>
                <th>User Address</th>
                <th>Travel Date</th>
                <th>Tour Name</th>
                <th>Tour Price</th>
                <th>Tour People Number</th>
                <th>Tour Price Total</th>
                <th>Guide Name</th>
                <th>Guide ID</th>
            </tr>
            <asp:Repeater ID="rptGuides" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("BookingID") %></td>
                        <td><%# Eval("User_id") %></td>
                        <td><%# Eval("User_Name") %></td>
                        <td><%# Eval("User_mobile") %></td>
                        <td><%# Eval("User_Country") %></td>
                        <td><%# Eval("User_Address") %></td>
                        <td><%# Eval("travel_date") %></td>
                        <td><%# Eval("Tour_Name") %></td>
                        <td><%# Eval("Tour_Price") %></td>
                        <td><%# Eval("Tour_People_Number") %></td>
                        <td><%# Eval("Tour_Price_Total") %></td>
                        <td><%# Eval("GuideName") %></td>
                        <td><%# Eval("GuideId") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
