<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tours.aspx.cs" Inherits="ExploreMumbai.Tours" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guide Information</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: blanchedalmond;
            padding: 20px;
        }

        .guide-container {
            background-color: pink;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align:center;
        }

        .guide-image-container {
            background-color: lightcoral;
            padding: 20px;
            text-align: center;
        }

        .guide-image {
        max-width: 100%;
        height: 350px;
        border-radius: 5px;
        }

        .guide-info {
            background-color: transparent;
            padding: 20px;
            text-align: start;
        }

        .btn-login {
            background-color: cornflowerblue;
            color: black;
            width: 150px;
            margin-top: 20px;
            padding: 10px 15px;
            text-decoration: none;
            text-align: center;
            cursor: crosshair;
            display: inline-block;
            border-radius: 5px;
        }

        .btn-login:hover {
            background-color: darkblue;
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center mb-4">Tour Information</h2>
            <div class="row">
            <asp:Repeater ID="rptGuides" runat="server">
                <ItemTemplate>
                        <div class="col-md-6">
                            <div class="guide-container">
                                <div class="guide-image-container">
                                    <asp:Image ID="imgGuide" runat="server" CssClass="guide-image" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Tour_Image")) %>' />
                                </div>
                                <div class="guide-info">
                                    ID:  <%# Eval("Tour_Id") %><br />
                                    Name: <%# Eval("Tour_Name") %><br />
                                    Price: <%# Eval("Tour_Price") %> RS/-<br />
                                    Description: <%# Eval("Tour_Description") %> <br />
                                </div>
                                <div class="guide-booking">
                                    <asp:HyperLink ID="Booking" runat="server" NavigateUrl="Book.aspx" CssClass="btn-login">BOOK</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
          </div>
        </div>
    </form>
</body>
</html>
