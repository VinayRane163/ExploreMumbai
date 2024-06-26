﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="ExploreMumbai.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
            animation :images 40s infinite;
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center center;
            background-attachment: fixed;
        }

           @keyframes images{
        0%{
           background-image:url("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg");
          }
       25%{
           background-image:url("https://indianparyatak.com/wp-content/uploads/2022/09/juhu-beach-mumbai-indian-tourism-entry-fee-timings-holidays-reviews-header-1.jpg");
       }
       50%{
           background-image:url("https://www.holidify.com/images/cmsuploads/compressed/shutterstock_694433434_20191213110339_20191213110412.png");
       }
       75%{
            background-image:url("https://media-cdn.tripadvisor.com/media/photo-s/16/73/99/cd/photo2jpg.jpg");
       }
       100%{
           background-image:url("https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/63/04/de/temple-big-view.jpg?w=1200&h=1200&s=1");
       }
   }
     
        .registration-container {
            background-color : lavender;  
            max-width: 500px;
            margin: auto;
            margin-top: 10px;
            border: 1px solid #ddd;
            padding: 20px;
            border-radius: 10px;
            backdrop-filter: blur(5px);
        }

        .form-title {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }
        label{
            background-color:lightblue;
        }
       
    </style>
        <script type="text/javascript">
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
<body>
    <form id="form1" runat="server" class="container registration-container">
        <h1 class="form-title" style="background-color: lightblue; color: black;">Registration Form</h1>

        <div class="form-group">
            <label for="txt_Name">Name:</label>
            <asp:TextBox ID="txt_Name" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Name" ErrorMessage="Name Required !!" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txt_Email">Email:</label>
            <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Email" ErrorMessage="Enter Email Address!!" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Email" ErrorMessage="Please enter a valid email address!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label for="txt_Password">Password:</label>
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

        <div class="form-group">
            <label for="txt_mobile">Mobile No.:</label>
            <asp:TextBox ID="txt_mobile" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_mobile" ErrorMessage="Please Enter your Mobile Number" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
               <label for="txt_confirmMobile">Re-enter Mobile No. :</label>
               <asp:TextBox ID="txt_confirmMobile" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_confirmMobile" ErrorMessage="Re-enter password" CssClass="text-danger"></asp:RequiredFieldValidator>
               <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Number Doesn't Match !" ControlToValidate="txt_confirmMobile" ControlToCompare="txt_mobile" CssClass="text-danger"></asp:CompareValidator>
        </div>

        <div class="form-group text-center">
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-success" style="background-color: lightblue; color: white;" />
                <br />
            <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx" CssClass="btn btn-outline-secondary btn-sm" Text="Login" style="background-color: forestgreen; color: black;" Height="36px" Width="88px"></asp:HyperLink>

        </div>

    </form>
</body>
</html>
