<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ExploreMumbai.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Page</title>

    <style>

        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .payment-container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 400px;
        }
       

        .form-group {
            margin-bottom: 20px;
        }

        .lol{
            display: flex;
            align-items: center;
        }

        .textbox-label {
            flex: 0 0 150px; /* Adjust the width of the label as needed */
        }

        .textbox {
            border: none; /* Make the border invisible */
            border-bottom: 1px solid #ddd; /* Add a bottom border for a subtle separation */
            padding: 8px;
            box-sizing: border-box;
            width: 100%;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
        }

        input[type="submit"] {
            background-color: #007bff;
            color: #fff;
            padding: 10px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

       
        .text-danger {
            color: red;
        }

        a{
            text-decoration:none;
            color:black;
        }
        a:hover{
            text-decoration:none;
        }
        .card-header {
    background-color: lavender;
    color: black;
    text-align: center;
    font-weight: bold;
    width: auto;
    padding: 20px; /* Increase padding for better coverage */
    margin-bottom: 10px;
}

    </style>

    <script type="text/javascript">
        function validateCreditCard() {
            function luhnCheck(value) {
                var sum = 0;
                var numdigits = value.length;
                var parity = numdigits % 2;
                for (var i = 0; i < numdigits; i++) {
                    var digit = parseInt(value.charAt(i));
                    if (i % 2 == parity) digit *= 2;
                    if (digit > 9) digit -= 9;
                    sum += digit;
                }
                return (sum % 10) == 0;
            }

            var cardNumber = document.getElementById('<%= cardNumber.ClientID %>').value.replace(/\s/g, '');
            var isValid = luhnCheck(cardNumber);

            if (!isValid) {
                alert('Invalid credit card number. Please enter a valid credit card number.');
                return false;
            }

            return true;
        }

        // Attach the validation function to the form submission
        document.getElementById('<%= btnMakePayment.ClientID %>').onclick = function () {
            return validateCreditCard();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server" class="payment-container"  method="post">
        <div class="card-header">
            Payment Gateway
        </div>
              
        <div class="form-group lol">
            <asp:Label ID="label_tourname" runat="server" CssClass="textbox-label" AssociatedControlID="tourname">Tour Name:</asp:Label>
            <asp:TextBox ID="tourname" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group lol">
            <asp:Label ID="label_total_Price" runat="server" CssClass="textbox-label" AssociatedControlID="total_Price">Total Price:</asp:Label>
            <asp:TextBox ID="total_Price" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>




        <div class="form-group">
            <asp:Label ID="label_nameo" runat="server" AssociatedControlID="username">name:</asp:Label>
            <asp:TextBox ID="username" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_textbox_label" runat="server" AssociatedControlID="UserID" Visible="false">User ID:</asp:Label>
            <asp:TextBox ID="UserID" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_textbox_label_mobile" runat="server" AssociatedControlID="mobile">Mobile:</asp:Label>
            <asp:TextBox ID="mobile" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_address" runat="server" AssociatedControlID="address">address:</asp:Label>
            <asp:TextBox ID="address" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_travel_date" runat="server" AssociatedControlID="travel_date">Travel Date:</asp:Label>
            <asp:TextBox ID="travel_date" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_price" runat="server" AssociatedControlID="tour_price" Visible="false">price:</asp:Label>
            <asp:TextBox ID="tour_price" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="tour_people" runat="server" AssociatedControlID="tour_n_people" Visible="false">User ID:</asp:Label>
            <asp:TextBox ID="tour_n_people" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_textbox_label_guidename" runat="server" AssociatedControlID="Guidename">Guide Name:</asp:Label>
            <asp:TextBox ID="Guidename" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="label_textbox_label_guideid" runat="server" AssociatedControlID="GuideId">Guide ID:</asp:Label>
            <asp:TextBox ID="GuideId" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox>
        </div>





        <div class="form-group">
            <label for="cardNumber">Card Number:</label>
            <asp:TextBox ID="cardNumber" runat="server" placeholder="Enter card number" CssClass="form-control" Required="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="expiryDate">Expiry Date:</label>
            <asp:TextBox ID="expiryDate" runat="server" placeholder="MM/YY" CssClass="form-control" Required="true"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revExpiryDate" runat="server" ControlToValidate="expiryDate"
               ValidationExpression="^(0[1-9]|1[0-2])\/(2[4-9]|3[0-9]|[4-9]\d{1,})$" ErrorMessage ="Invalid expiry date. Please enter a valid date in MM/YY format."
                Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label for="cvv">CVV:</label>
            <asp:TextBox ID="cvv" runat="server" placeholder="Enter CVV" CssClass="form-control" Required="true" TextMode="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revCvv" runat="server" ControlToValidate="cvv"
                ValidationExpression="^[0-9]{3,4}$" ErrorMessage="Invalid CVV. Please enter a valid CVV."
                Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>

       
            <center>
                     <asp:Button ID="btnMakePayment" runat="server" Text=" Pay" CssClass="btn btn-primary btn-block " OnClick="btnMakePayment_Click" Width="150px" /><br /><br />
                      <a href="Book.aspx" class="btn btn-info btn-block "><b>Cancel</b></a> 

             </center>
    </form>
</body>
</html>
