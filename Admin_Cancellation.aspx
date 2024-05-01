<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Cancellation.aspx.cs" Inherits="ExploreMumbai.Admin_Cancellation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Cancellation</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        .custom-container {
            border: 1px solid black;
            padding: 20px;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">

        <!-- Delete Section -->
        <div class="mt-4 custom-container">
            <h4> Book Cancellation Application</h4>
            <div class="form-group">
                <label for="txtDeleteId">ID:</label>
                <asp:TextBox ID="txtDeleteId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnDelete" runat="server" Text="Revoke Booking " CssClass="btn btn-danger" OnClick="btnDelete_Click" />

            <asp:Button ID="return" runat="server" Text="Cancel Revoke Request" CssClass="btn btn-danger" OnClick="req_Click" />

            <asp:Button ID="back" runat="server" Text="back" CssClass="btn btn-danger" OnClick="bACK_Click" />
        </div>



       <div class="row custom-container">
    <div class="col-md-6 border-right">
        <h4>From Booking </h4>
        <asp:Repeater ID="rptBooking" runat="server">
            <ItemTemplate>
                <div>
                    <p>BookingID: <%# Eval("BookingID") %></p>
                    <p>Total Price: <%# Eval("Tour_People_Number") %></p>
                    <p>UserID: <%# Eval("User_id") %></p>
                    <p>travel date: <%# Eval("travel_date") %></p>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="col-md-6">
        <h4>Cancellation  request</h4>
        <asp:Repeater ID="rptCancellationRequest" runat="server">
            <ItemTemplate>
                <div>
                    <p>BookingID: <%# Eval("BookingID") %></p>
                    <p>Reason: <%# Eval("Reason") %></p>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>


    </form>
</body>
</html>
