<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="ExploreMumbai.ForgetPassword" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <style>
        body {
            background-color: #f8f9fa;
        }
        
        .login-container {
            max-width: 800px;
            margin: auto;
            margin-top: 100px;
        }

        .card {
            border: 1px solid #ddd;
            border-radius: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .card-header {
            background-color: yellow;
            color: black;
            text-align: center;
            font-weight: bold;
            border-bottom: 1px solid #ddd;
            padding: 10px;
        }

        .card-body {
            padding: 30px;
            border-top: 1px solid #ddd;
        }

        .form-control {
            margin-bottom: 15px;
        }

        .btn-login {
            background-color: yellow;
            color: black;
            border-radius: 20px;
        }

        .btn-back {
            background-color: green;
            color: white;
            border-radius: 20px
        }

        
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container login-container">
            <h1 class="text-center mb-4">FORGET PASSWORD</h1>

            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            User Login
                        </div>
                        <div class="card-body">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" Width="100%"></asp:TextBox>

                            <asp:Button ID="Forgot_Button" runat="server" Text="Forgot Password" CssClass="btn btn-login btn-block" OnClick="BtnForgotPassword_Click" />

                            <a href="Login.aspx" class="btn btn-back btn-block">Back to Login</a>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
        </div>
    </form>
</body>
</html>
