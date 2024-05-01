<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="ExploreMumbai.Reviews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reviews</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .guide-container {
            background-color: paleturquoise;
            max-width: 1000px;
            margin: auto;
            margin-top: 50px;
            padding: 20px;
            text-align: center;
            border: 3px solid rgba(0, 0, 0, 1);
        }

        .review-box {
            background-color: mediumpurple;
            margin-bottom: 10px;
            padding: 10px;
            border: 1px solid #dee2e6;
            border-radius: 5px;
        }

        .review-container {
            margin-top: 20px;
            margin-bottom: 20px;
            padding: 10px;
        }

        .username-column {
            background-color: lightblue;
            max-width: auto; 
            font-size: 14px; 
        }

        .review-column {
            background-color: lightgreen;
            max-width: auto; 
            font-size: 16px; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container guide-container">
            <div>
                <asp:Label Text="Add Review :" runat="server" />
                <asp:TextBox ID="txt_Review" runat="server"  Width="281px" />
                &nbsp;
                <asp:Button Text="ADD" runat="server"  CssClass="btn-primary" OnClick="Add_Review" />
                &nbsp;&nbsp;
                <asp:Button Text="Update" runat="server"  CssClass="btn-primary" OnClick="Update_Review" ID="Button1" />
                &nbsp;&nbsp;
                <asp:Button Text="Home" runat="server" CssClass="btn-primary" OnClick="back" />

            </div>
            <br />

            <asp:Repeater ID="rptGuides" runat="server">
                <ItemTemplate>
                    <div class="review-box">
                        <div class="text-center">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-4 username-column">
                                         <%# Eval("username") %>
                                    </div>
                                    <div class="col-md-8 review-column">
                                        <%# Eval("review") %>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
