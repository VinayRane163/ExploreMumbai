<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users_booked.aspx.cs" Inherits="ExploreMumbai.users_booked" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users Bookings</title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

<style>
    
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

     footer {
            position: fixed;
            bottom: 0;
            width: 100%;
            background-color: black;
            text-align: center;
            color:white;
            padding: 25px;
        }
     .btn-info{
         background-color:crimson;
          
            text-align: center;
            margin-top: 15px;
            color: white;
            text-decoration: none;
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            cursor: pointer;
            width : 30%;
     }
     .btn-info:hover{
          background-color:crimson;       
          text-decoration: none;          
     }
     
</style>
</head>
<body>
    <form id="form1" runat="server">
             <table>
            <tr>
                <th>Booking ID</th>
               
                <th>Tour Name</th>
                <th>Travel Date<br /></th>
                
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
                      
                        <td><%# Eval("travel_date", "{0:dd-MM-yyyy}") %></td>
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

            </center>
        <footer>
          <div >
              To cancel your booking <a href="Cancelation_request.aspx" class="btn-info"> Click here </a>
        </div>
        </footer>


    </form>
</body>
</html>
