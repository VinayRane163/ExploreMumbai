<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Panel.aspx.cs" Inherits="ExploreMumbai.User_Panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <style>
        body {
            background-color: #f8f9fa;
        }

        .uf-container {
            background-color: cornflowerblue;
            max-width: 600px;
            margin: auto;
            margin-top: 50px;
            padding: 20px;
            text-align: center;
            border: 3px solid rgba(0, 0, 0, 1);
        }

        .all-container {
            background-color: cornsilk;
            max-width: 600px;
            margin: auto;
            margin-top: 50px;
            padding: 20px;
            text-align: center;
            border: 3px solid rgba(0, 0, 0, 1);
        }

        .card-header {
            background-color: cornflowerblue;
            color: black;
            text-align: center;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .btn-login {
            background-color: green;
            color: white;
            width: 100px;
            margin-top: 20px;
        }

        .link-container {
            text-align: center;
            margin-top: 15px;
        }
        .auto-style1 {
            background-color: yellow;
            color: black;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container all-container">

        <div class="container uf-container">
            <div class="card-header">
                Your Information
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
            <asp:Button ID="cng_INfo" runat="server" OnClick="CNG_INFO_Click" CssClass="auto-style1" Text="Change your data" Width="187px" />

            <br />
            <asp:Button ID="Btn_Logout" runat="server" OnClick="BtnLogout_Click" CssClass="btn-login" Text="Logout" />
            <br />
            <asp:Button ID="Back" runat="server" OnClick="BtnBack_Click" CssClass="btn-login" Text="Back" />
            </div>
        </div>
    </form>
</body>
</html>
