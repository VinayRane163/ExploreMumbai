<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tours.aspx.cs" Inherits="ExploreMumbai.Tours" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Explore Mumbai Tours</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: lightblue;
            padding-top: 60px;
        }

        .container {
            width:1600px;
            background-color: lavender;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            padding: 20px;
        }

        h2 {
            color: #007bff;
        }

        .guide-container {
            background-color: lightblue;
            margin-bottom: 20px;
            border: 1px solid #e9ecef;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease-in-out;
        }

        .guide-container:hover {
            transform: scale(1.05);
        }

        .guide-image-container {
            position: relative;
            overflow: hidden;
            border-radius: 10px 10px 0 0;
        }

        .guide-image {
            width: 100%;
            height: 300px;
            object-fit: cover;
        }

        .guide-info {
            padding: 20px;
            text-align: start;
        }

        .btn-login {
            background-color: #007bff;
            color: #ffffff;
            width: 150px;
            margin-top: 20px;
            padding: 10px 15px;
            text-decoration: none;
            text-align: center;
            display: inline-block;
            border-radius: 5px;
            transition: background-color 0.3s ease-in-out;
        }

        .btn-login:hover {
            background-color: black;
             color: white;               
        }

        .euu{
            color:black;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top">
            <a class="navbar-brand" href="Home.aspx">Explore Mumbai Tours</a>
        </nav>
        <div class="container">
            <h2 class="text-center euu  mb-4">Discover Unique Tours</h2>
            <div class="row">
                <asp:Repeater ID="rptGuides" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <div class="guide-container">
                                <div class="guide-image-container">
                                    <asp:Image ID="imgGuide" runat="server" CssClass="guide-image" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Tour_Image")) %>' />
                                </div>
                                <div class="guide-info">
                                    <h4><%# Eval("Tour_Name") %></h4>
                                    <!--<p>ID: <%--<%# Eval("Tour_Id") %>--%></p>-->
                                    <p>Price: <%# Eval("Tour_Price") %> RS/- per person</p>
								    <p>Description :<asp:TextBox Text='<%# Eval("Tour_Description") %>' runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Rows="5" /></p>

<center><asp:HyperLink ID="Booking" runat="server" NavigateUrl='<%# "Book.aspx?TourName=" + Server.UrlEncode(Eval("Tour_Name").ToString()) %>' CssClass="btn-login">BOOK NOW</asp:HyperLink></center>
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
