<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cancelation_request.aspx.cs" Inherits="ExploreMumbai.Cancelation_request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cancelation Request</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #343a40;
        }

        .container {
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-top: 5px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            color: black;
        }

        .form-control {
            border-radius: 4px;
            box-shadow: none;
        }

        .btn-primary {
            background-color: black;
            border: 1px solid #007bff;
            border-radius: 4px;
            padding: 10px 20px;
        }

        .btn-primary:hover {
            background-color: white;
            border: 1px solid #0056b3;
            color:black
        }

         table {
             width: 100%;
             border-collapse: collapse;
             margin-top: 20px;
             margin-bottom:75px;
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
    <form id="form1" runat="server" class="container">
        <div align="center" class="container">
        <header>
          <h1>Request to Cancel Booking</h1>
       </header>

        </div>
        <br />
       
        <div class="col-md-6 mx-auto">
            <div class="form-group">
                <label for="txtBookingID">Booking ID:</label>
                <asp:TextBox ID="txtBookingID" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtReason">Reason:</label>
                <asp:TextBox ID="txtReason" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        <center>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" align="" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            <asp:Button ID="bACK" runat="server" Text="BACK" align="" CssClass="btn btn-primary" OnClick="btnBACK_Click" />

        </center>    
        </div>
        <div class="container">

        <table>
    <tr>
        <th>Booking ID</th>
       
        <th>Tour Name</th>
        <th>Travel Date<br /> mm/dd/yyyy</th>
        
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
                <td><%# Eval("Tour_Name") %></td>              
                <td><%# Eval("travel_date") %></td>
                <td><%# Eval("Tour_Price") %></td>
                <td><%# Eval("Tour_People_Number") %></td>
                <td><%# Eval("Tour_Price_Total") %></td>
                <td><%# Eval("GuideName") %></td>
                <td><%# Eval("GuideId") %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

        </div>

    </form>
</body>
</html>
