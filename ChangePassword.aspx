<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ExploreMumbai.ChangePassword" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
  <title>Change Password</title>
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
          background-color: mediumpurple;
          color: white;
          text-align: center;
          font-weight: bold;
      }

      .btn-login {
          background-color: mediumpurple;
          color: white;
          width: 100%;
          margin-top: 20px;
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

          function togglePasswordVisibility() {
              var passwordTextBox = document.getElementById('<%= txt_Password.ClientID%>');
                var btnShowPassword = document.getElementById('btnShowPassword');

                if (passwordTextBox.type === 'password') {
                    passwordTextBox.type = 'text';
                    btnShowPassword.innerHTML = '<img src="https://w7.pngwing.com/pngs/27/357/png-transparent-eye-eyeball-hide-interface-secret-revamp-icon.png" alt="Hide Password" style="width: 20px; height: 20px;">';
                } else {
                    passwordTextBox.type = 'password';
                    btnShowPassword.innerHTML = '<img src="https://static.thenounproject.com/png/2540381-200.png" alt="Show Password" style="width: 20px; height: 20px;">';
                }
          }

          function toggleConfirmPasswordVisibility() {
              var passwordTextBox = document.getElementById('<%= txt_Confirmpassword.ClientID%>');
                var btnShowPassword = document.getElementById('btnShowConfirmPassword');

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
<body >
       <form id="form1" runat="server">
        <div class="container login-container">
            <div class="card">
                <div class="card-header">
                  Change Password
                </div>
                <div class="card-body">
                   <div class="form-group">
                      &nbsp; Change
                       <label for="txt_Password">
                       Password:</label>
                       <div class="input-group">
                           <asp:TextBox ID="txt_Password" runat="server" CssClass="form-control" Width="85%" TextMode="Password"></asp:TextBox>
                           <div class="input-group-append">
                               <button type="button" class="btn btn-light" id="btnShowPassword" onclick="togglePasswordVisibility()">
                                   <img src="https://static.thenounproject.com/png/2540381-200.png" alt="Show Password" style="width: 20px; height: 20px;" />
                               </button>
                           </div>
                       </div>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Password" ErrorMessage="Enter Password!!" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

        <div class="form-group">
            <label for="txt_Confirmpassword">Re-enter Password:</label>
             <div class="input-group">
            <asp:TextBox ID="txt_Confirmpassword" runat="server"  CssClass="form-control" Width="85%" TextMode="Password"></asp:TextBox>
                            <div class="input-group-append">
                                <button type="button" class="btn btn-light" id="btnShowConfirmPassword" onclick="toggleConfirmPasswordVisibility()">
                                    <img src="https://static.thenounproject.com/png/2540381-200.png" alt="Show Password" style="width: 20px; height: 20px;" />
                                </button>
                            </div>
                        </div>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Re-enter password" CssClass="text-danger" ControlToValidate="txt_Confirmpassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Doesn't Match !" ControlToValidate="txt_Confirmpassword" ControlToCompare="txt_Password" CssClass="text-danger"></asp:CompareValidator>
        </div>




                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Submit" CssClass="btn btn-login" Height="51px" />
             
                </div>
            </div>
        </div>
  
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="User_Panel.aspx" >Back</asp:HyperLink>

  
        <div id="flashMessage" style="display: none; background-color: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; padding: 10px; margin-top: 20px; border-radius: 5px;"></div>


    </form>
</body>
</html>

