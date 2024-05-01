<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Panel.aspx.cs" Inherits="ExploreMumbai.User_Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UserDashboard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <style>
        body {
            background-color: #f8f9fa;
            animation: images 40s infinite;
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center center;
            background-attachment: fixed;
            font-family: 'Arial', sans-serif;
        }

        @keyframes images {
            0% {
                background-image: url("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg");
            }

            25% {
                background-image: url("https://indianparyatak.com/wp-content/uploads/2022/09/juhu-beach-mumbai-indian-tourism-entry-fee-timings-holidays-reviews-header-1.jpg");
            }

            50% {
                background-image: url("https://www.holidify.com/images/cmsuploads/compressed/shutterstock_694433434_20191213110339_20191213110412.png");
            }

            75% {
                background-image: url("https://media-cdn.tripadvisor.com/media/photo-s/16/73/99/cd/photo2jpg.jpg");
            }

            100% {
                background-image: url("https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/63/04/de/temple-big-view.jpg?w=1200&h=1200&s=1");
            }
        }

         .all-container {
            background-color: lavender;
            max-width: 600px;
            margin: auto;
            margin-top: 50px;
            padding: 20px;
            text-align: center;
            border: 3px solid rgba(0, 0, 0, 1);
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(5px);            

        }
         .uf-container{
            background-color: lightblue;
            max-width: 600px;
            margin: auto;
            margin-top: 50px;
            padding: 20px;
            text-align: center;
            border: 3px solid rgba(0, 0, 0, 1);
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(5px);            

         }

        .card-header {
            background-color: #6C757D;
            color: white;
            text-align: center;
            font-weight: bold;
            margin-bottom: 20px;
            border: 3px solid rgba(0, 0, 0, 1);
            padding: 10px;
            border-radius: 5px;
        }

        .btn-login, .auto-style1 {
            background-color: lavender;
            color: black;
            border: 3px solid rgba(0, 0, 0, 1);
            width: 150px;
            margin-top: 20px;
            padding: 10px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-login:hover, .auto-style1:hover {
            background-color: #218838;
                        border: 3px solid rgba(0, 0, 0, 1);

        }

        .link-container {
            background-color:lightblue;
            text-align: center;
            border: 3px solid rgba(0, 0, 0, 1);

            margin-top: 15px;
            margin-bottom:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container all-container">
            <div class="container uf-container">
                <div class="card-header">
                            User Info           
                </div>
                <asp:Repeater ID="rptGuides" runat="server">
                    <ItemTemplate>
                        <div class="text-center">
                            User Name: <%# Eval("User_Name") %><br />
                            User ID: <%# Eval("User_id") %><br />
                            User Password: <%# Eval("User_password") %><br />
                            Contact: <%# Eval("User_mobile") %><br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="link-container">
                <asp:Button ID="CNG_Password" runat="server" OnClick="CNG_Password_Click" CssClass="auto-style1" Text="Change Password" Width="187px" />
                <br />
                <asp:Button ID="CNG_INFO" runat="server" OnClick="CNG_INFO_Click" CssClass="auto-style1" Text="Change Your Data" Width="187px" />
                <br />
                <asp:Button ID="BtnLogout" runat="server" OnClick="BtnLogout_Click" CssClass="btn-login" Text="Logout" />
                <br />
                <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" CssClass="btn-login" Text="Back" />
            </div>
        </div>
    </form>
</body>
</html>
