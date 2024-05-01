<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeUserInfo.aspx.cs" Inherits="ExploreMumbai.ChangeUserInfo" %>

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
          background-color: lavender;
          color: black;
          text-align: center;
          font-weight: bold;
      }

      .btn-login {
          background-color: lavender;
          color: black;
          width: 100%;
          margin-top: 20px;
      }  
      .btn{
          color:black;
          background-color:lavender;
      }
      
  </style>
      
</head>
<body >
       <form id="form1" runat="server">
        <div class="container login-container">
            <div class="card">
                <div class="card-header">
                  Change user ifo
                </div>
                <div class="card-body">
                   <div class="form-group">
                   <label for="txt_UserName">UserName :</label>
                       <div class="input-group">
                           <asp:TextBox ID="txt_UserName" runat="server" CssClass="form-control" Width="85%" ></asp:TextBox>
                          </div>
                       </div>

                    <div class="form-group">
                        <label for="txt_phonenumber ">Mobile Number:</label>
                         <div class="input-group">
                             <asp:TextBox ID="txt_phonenumber" runat="server"  CssClass="form-control" Width="85%" placeholder="enter with contry code"></asp:TextBox>
                          </div>
                     </div>

                    
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Submit" CssClass="btn btn-login" Height="51px" />
                    <br />
                    <br />
                        <center>          
                            <asp:HyperLink ID="HyperLink2" CssClass="btn" runat="server" NavigateUrl="User_Panel.aspx" >Back</asp:HyperLink>
                    </center> 
                                              
                    </div>
                </div>
            </div>
        

  



    </form>
</body>
</html>
