<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ExploreMumbai.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .login-container {
            max-width: 600px;
            margin: auto;
            margin-top: 50px;
        }

        .card {
            border: 1px solid rgba(0, 0, 0, .125);
            border-radius: .25rem;
            box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, .15);
        }

        .card-header {
            background-color: lightblue;
            color: black;
            text-align: center;
            font-weight: bold;
        }

        .btn-login {
            background-color: lightblue;
            color: black;
            width: 100%;              
            border-color: black;
            border-radius: .25rem;
            box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, .15);
                    }
        .User-link {
          background-color : lightblue;
            display: block;
            text-align: center;
            margin-top: 20px;
            color: black;
            text-decoration: none;
            padding: 5px;
            border: 1px solid black;
            border-radius: 5px;
            cursor: pointer;
            width : 15%;
        }
        .User-link:hover{
            color:black;
            text-decoration:none;
        }
    </style>
        <script type="text/javascript">
           
            // for button to see and unsee password

            function togglePasswordVisibility() {
                var passwordTextBox = document.getElementById('<%= TxtPassword.ClientID %>');
                var btnShowPassword = document.getElementById('btnShowPassword');

                if (passwordTextBox.type === 'password') {
                    passwordTextBox.type = 'text';
                    btnShowPassword.innerHTML = '<img src="https://w7.pngwing.com/pngs/27/357/png-transparent-eye-eyeball-hide-interface-secret-revamp-icon.png" alt="Hide Password" style="width: 20px; height: 20px;">';
                } else {
                    passwordTextBox.type = 'password';
                    btnShowPassword.innerHTML = '<img src="https://static.thenounproject.com/png/2540381-200.png" alt="Show Password" style="width: 20px; height: 20px;">';
                }
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container login-container">
            <div class="card">
                <div class="card-header">
                    Admin Login
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="TxtUsername">Admin ID:</label>
                        <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" Width="100%" BorderColor="#CCCCFF"></asp:TextBox>
                    </div>
                   <div class="form-group">
                       <label for="TxtPassword">Password:</label>
                       <div class="input-group">
                           <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" Width="85%" TextMode="Password"></asp:TextBox>

                           <div class="input-group-append">
                               <button type="button" class="btn btn-light" id="btnShowPassword" onclick="togglePasswordVisibility()">
                                   <img src="https://static.thenounproject.com/png/2540381-200.png" alt="Show Password" style="width: 20px; height: 20px;" />
                               </button>
                           </div>

                       </div>
                   </div>

                    
                    
                    <asp:Button ID="BtnLogin" runat="server" OnClick="Button1_Click" Text="Login" CssClass="btn btn-login" />

                    <br />
                   
                    <center>
                    <asp:HyperLink ID="UserLink" runat="server" NavigateUrl="Login.aspx" CssClass="User-link">back  </asp:HyperLink>
                     </center>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
