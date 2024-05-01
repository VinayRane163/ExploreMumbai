<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="ExploreMumbai.Application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guide Registration</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <script type="text/javascript">
        function showFile(input) {
            var fileInput = document.getElementById('<%= imageUpload.ClientID %>');
            var fileLabel = document.getElementById('fileLabel');

            if (fileInput.files && fileInput.files[0]) {
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
            background-color: cadetblue;
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
            background-color: cadetblue;
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
                Application form
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="imageUpload">Select PDF File:</label>
                    <div class="custom-file">
                        <asp:FileUpload ID="imageUpload" runat="server" CssClass="custom-file-input" accept=".pdf" onchange="showFile(this);" />
                        <label class="custom-file-label" for="imageUpload" id="fileLabel">Choose file</label>
                    </div>
                </div>
                <div class="center form-group col-md-6">
                    Name:
                    <asp:TextBox ID="Name" runat="server"></asp:TextBox><br />
                    E-mail:
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="-- Enter avalid email address!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                    Contact : 
                    <asp:TextBox ID="Contact" runat="server"></asp:TextBox>

                    <!-- Retain the existing login button -->
                    <asp:Button ID="btnLogin" runat="server" OnClick="BtnSubmit_Click" Text="Submit" CssClass="btn btn-login" Height="51px" />
                    <asp:Button ID="back" runat="server" OnClick="BtnBack_Click" Text="Back" CssClass="btn btn-login" Height="51px" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
