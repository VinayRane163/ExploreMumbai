<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking_display_admin.aspx.cs" Inherits="ExploreMumbai.Booking_display_admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <style>
        
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
        .auto-style1 {
            margin-left: 655;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <h2>
                Bookings
            </h2>
            <p>
                <asp:RegularExpressionValidator ID="DateValidator" runat="server" ControlToValidate="Search_date"
                    ErrorMessage="Valid format yyyy-mm-dd" 
                    ValidationExpression="^\d{2}-\d{2}-\d{4}$">
                </asp:RegularExpressionValidator>
            </p>
            <p>
            <!-- <asp:TextBox ID="bookingId" runat="server" placeholder="Booking ID"></asp:TextBox>-->

&nbsp;
                <asp:TextBox ID="Search_date" runat="server" placeholder="date:DD:MM:YYYY"></asp:TextBox>

                &nbsp;

                <asp:TextBox ID="Search_ID" runat="server"  placeholder="UserID"></asp:TextBox>
              
     <label for="Tour_Name">DESTINATION:</label><asp:DropDownList ID="Tour_Name" runat="server" class="form-control" OnSelectedIndexChanged="Tour_Name_SelectedIndexChanged" AutoPostBack="true" CssClass="auto-style1" Width="229px"></asp:DropDownList>

            </p>
            <p>
                <asp:Button ID="search" runat="server" OnClick="BtnSearch_Click" Text="SEARCH" CssClass="btn btn-info"  />                
                &nbsp;&nbsp;

                <asp:Button ID="Reload" runat="server" OnClick="BtnReload_Click" Text="RELOAD " CssClass="btn btn-info" />
            &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" OnClick="BtnDelete_Click" Text="BACK" CssClass="btn btn-danger" />
            </p>
            <p>

                &nbsp;</p>
        </center>
        <table>
            <tr>
                <th>Booking ID</th>
                <th>User ID</th>
                <th>User Name</th>
                <th>User Mobile</th>
                <th>User Country</th>
                <th>User Address</th>
                <th>Travel Date<br />(dd:mm:yyyy) </th>
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
                        <td><%# Eval("travel_date", "{0:dd-MM-yyyy}") %></td>
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
        <center>    
        <br />
            </center>

    </form>
</body>
</html>
