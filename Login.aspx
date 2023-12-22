<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExploreMumbai.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
             background-image: url('https://indianparyatak.com/wp-content/uploads/2022/09/juhu-beach-mumbai-indian-tourism-entry-fee-timings-holidays-reviews-header-1.jpg');
             background-repeat: no-repeat;
             background-size: auto;
             background-position: center center;
             background-attachment: fixed;
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
            background-color: #28a745;
            color: white;
            text-align: center;
            font-weight: bold;
        }

        .btn-login {
              background-color : forestgreen;
              display: block;
              text-align: center;
              margin-top: 15px;
              color: black;
              text-decoration: none;
              padding: 10px;
              border: 1px solid black;
              border-radius: 5px;
              cursor: pointer;
              width : 100%;
        }

         .register-link {
      background-color : cornflowerblue;
        display: block;
         text-align: center;
        margin-top: 15px;
        color: white;
        text-decoration: none;
        padding: 10px;
        border: 1px solid black;
        border-radius: 5px;
        cursor: pointer;
        width : 100%;
         }


        .Admin-link {
            background-color : red;
            display: block;
            text-align: center;
            margin-top: 15px;
            color: black;
            text-decoration: none;
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            cursor: pointer;
            width : 100%;
        }

        .Forget-link {
            background-color : yellow ;
            display: block;
            text-align: center;
            margin-top: 15px;
            color: black;
            text-decoration: none;
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            cursor: pointer;
            width : 100%;
        }

        
    </style>
        <script type="text/javascript">
            function showFlashMessage(message) {
                var flashMessage = document.getElementById('flashMessage');
                flashMessage.innerHTML = message;
                flashMessage.style.display = 'block';
                setTimeout(function () {
                    flashMessage.style.display = 'none';
                }, 2000);
            }
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
                    User Login
                </div>
                <div class="card-body">
                   <div class="form-group">
                      <label for="TxtUsername">User ID (Email):</label>
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
                  
                    
                    
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="btn btn-login" Height="51px" />
                   
                     
                   
                 <asp:HyperLink ID="registerLink" runat="server" NavigateUrl="Registeration.aspx" CssClass="register-link">Register</asp:HyperLink>
                    
                    <asp:HyperLink ID="AdminLink" runat="server" NavigateUrl="AdminLogin.aspx" CssClass="Admin-link">Admin</asp:HyperLink>
                         
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ForgetPassword.aspx" CssClass="Forget-link ">Forget Password</asp:HyperLink>
        
                </div>
            </div>
        </div>
       <div id="flashMessage" style="display: none; background-color: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; padding: 10px; margin-top: 20px; border-radius: 5px;"></div>

        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>

    </form>
</body>
</html>
