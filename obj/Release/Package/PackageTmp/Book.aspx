<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="ExploreMumbai.Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booking Form</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 50px;
            background-color: #ffffff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        label {
            font-weight: bold;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-primary {
            background-color: #007bff;
            border-color: #007bff;
        }

        .btn-primary:hover {
            background-color: #0056b3;
            border-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <div class="form-group">
            <label for="User_id">USER ID:</label>
            <asp:TextBox ID="User_id" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="User_Name">USER NAME:</label>
            <asp:TextBox ID="User_Name" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="User_mobile">MOBILE NUMBER:</label>
            <asp:TextBox ID="User_mobile" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="User_Country">Country:</label>
            <asp:TextBox ID="User_Country" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="User_Address">ADDRESS:</label>
            <asp:TextBox ID="User_Address" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="travel_date">DATE OF TRAVEL:</label>
            <div class="input-group">
                <asp:TextBox ID="travel_date" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
            </div>
             <br />
             <asp:Calendar ID="Calendar1" runat="server" Height="36px" Width="88px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>

        <div class="form-group">
            <label for="Tour_Name">DESTINATION:</label>
            <asp:DropDownList ID="Tour_Name" runat="server" class="form-control" OnSelectedIndexChanged="Tour_Name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="Tour_Price">PRICE:</label>
            <asp:TextBox ID="Tour_Price" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Tour_People_Number">NO OF PEOPLE:</label>
<asp:TextBox ID="Tour_People_Number" runat="server" AutoPostBack="True"  class="form-control" OnTextChanged="CalculateTotal"  />
        </div>

        <div class="form-group">
            <label for="Tour_Price_Total">TOTAL:</label>
            <asp:TextBox ID="Tour_Price_Total" runat="server" class="form-control" ReadOnly="true" ></asp:TextBox>
        </div>

        <div class="form-group">
    <label for="SelectGuideCheckbox">Select Guide:</label>
    <asp:CheckBox ID="SelectGuideCheckbox" runat="server" AutoPostBack="true" OnCheckedChanged="SelectGuideCheckbox_CheckedChanged" />
</div>


        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="GuideName">GUIDE NAME:</label>
                <asp:DropDownList ID="GuideName" runat="server" class="form-control" OnSelectedIndexChanged="GuideName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="GuideId">GUIDE ID:</label>
                    <asp:TextBox ID="GuideId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                </div>
        </div>

        <div class="form-group">
            <asp:Button ID="Book_btn" runat="server" Text="BOOK" CssClass="btn btn-primary btn-block" OnClick="Book_btn_Click" />
            <br />
            <asp:Button ID="BACK" runat="server" Text="Back" CssClass="btn btn-primary " OnClick="bk_Click" />
        </div>
    </form>
</body>
</html>
