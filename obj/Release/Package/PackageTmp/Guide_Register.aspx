﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guide_Register.aspx.cs" Inherits="ExploreMumbai.Guide_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guide Registration</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <script type="text/javascript">
        function showImage(input) {
            var fileInput = document.getElementById('<%= imageUpload.ClientID %>');
            var imgPreview = document.getElementById('<%= Image1.ClientID %>');
            var fileLabel = document.getElementById('fileLabel');

            if (fileInput.files && fileInput.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    imgPreview.src = e.target.result;
                };
                reader.readAsDataURL(fileInput.files[0]);

                // Display chosen file name
                fileLabel.innerText = fileInput.files[0].name;
            }
        }
    </script>
    <style>
        body {
            background-color: #f8f9fa;
        }

        .login-container {
            max-width: 600px;
            margin: auto;
            margin-top: 50px;
        }

        .card-header {
            background-color: red;
            color: black;
            text-align: center;
            font-weight: bold;
        }

        .card {
            border: 1px solid rgba(0, 0, 0, .125);
            border-radius: .25rem;
            box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, .15);
        }

        .btn-login {
        background-color: red;
        color: white;
        width: 100%;
        margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container login-container">
        <div class="card">
            <div class="card-header">
                Guide Registration
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="imageUpload">Select Image:</label>
                    <div class="custom-file">
                        <asp:FileUpload ID="imageUpload" runat="server" CssClass="custom-file-input" onchange="showImage(this);" />
                        <label class="custom-file-label" for="imageUpload" id="fileLabel">Choose file</label>
                    </div>
                    <img id="Image1" runat="server" class="mt-2 img-thumbnail" style="max-width: 150px; max-height: 150px;" src="image" />
                </div>
                    <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Guide_FirstName">First Name:</label>
                        <asp:TextBox ID="Guide_FirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="Guide_LastName">Last Name:</label>
                        <asp:TextBox ID="Guide_LastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                  </div>
                    <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="Guide_Education">Guide Education:</label>
                        <asp:TextBox ID="Guide_Education" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
               
                    <div class="form-group col-md-6">
                        <label for="Guide_Age">Guide Age:</label>
                        <asp:TextBox ID="Guide_Age" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                         </div>
                            <div class="form-row">
                                 <div class="form-group col-md-6">
                                <label for="Guide_Contact">Guide Contact:</label>
                                   <asp:TextBox ID="Guide_Contact" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="invalid Number" ControlToValidate="Guide_Contact" ValidationExpression="^[7-9][0-9]{9}$"></asp:RegularExpressionValidator>
                            </div>
                    <div class="form-group col-md-6">
                        <label for="Guide_Description">Guide Description:</label>
                        <asp:TextBox ID="Guide_Description" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="center   form-group  col-md-6">
                    <asp:Button ID="btnLogin" runat="server" OnClick="BtnSubmit_Click" Text="Submit" CssClass="btn btn-login" Height="51px" />
                    <asp:Button ID="back" runat="server" OnClick="BtnBack_Click" Text="back" CssClass="btn btn-login" Height="51px" />

                </div>
              </div>
           </div>
            
    </form>
</body>
</html>