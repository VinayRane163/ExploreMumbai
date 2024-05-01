<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="ExploreMumbai.Reviews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reviews</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            background-image:url("https://ehq-production-canada.imgix.net/e2df5cb5e66ebb621f9dd070d227a1b3f2e2a8cf/original/1678895377/7318375f2c93ae5ded9dab7e5d2e4764_HYS_Site_ImagecardSample.jpg?auto=compress%2Cformat&w=1080");
            background-size: cover  ;
            background-repeat:no-repeat;
            background-attachment:fixed;
            background-position:center center;
            background-color: #f8f9fa;
        }

        .guide-container {
            background-color: #ffffff;
            max-width: 900px;
            margin: auto;
            margin-top: 50px;
            padding: 20px;
            text-align: left;
            border: 1px solid #dee2e6;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .review-box {
            background-color: #ffffff;
            margin-bottom: 20px;
            padding: 20px;
            border: 1px solid #dee2e6;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .username-column {
            font-size: 21px;
            font-weight: bold;
            color: #007bff;            
        }

        .review-column {
           
            font-size: 16px;
            color: black;
        }

        .add-review-container {
            margin-top: 20px;
            margin-bottom: 20px;
            padding: 10px;
            background-color: #f1f1f1;
            border-radius: 5px;
        }

        .btn-primary {
            background-color: #007bff;
            border: 1px solid #007bff;
        }

        .btn-primary:hover {
            background-color: #0056b3;
            border: 1px solid #0056b3;
        }
    </style>
</head>
<body>
    <center>
        <h1>Reviews</h1>
    </center>
    <form id="form1" runat="server">
        <div class="container guide-container">
            <div class="add-review-container">
                <asp:Label Text="Add Review :" runat="server" />
                <asp:TextBox ID="txt_Review" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1" />
                <br />
                <asp:Button Text="ADD" runat="server" CssClass="btn btn-primary" OnClick="Add_Review" />
                <asp:Button Text="Update" runat="server" CssClass="btn btn-primary" OnClick="Update_Review" />
                <asp:Button Text="Home" runat="server" CssClass="btn btn-primary" OnClick="back" />
            </div>

            <asp:Repeater ID="rptGuides" runat="server">
                <ItemTemplate>
                    <div class="review-box">
                        <div class="username-column">
                             <%# Eval("username") %>
                        </div>
                        <div class="review-column">
                            <asp:TextBox Text='<%# Eval("review") %>' runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Rows="2" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
