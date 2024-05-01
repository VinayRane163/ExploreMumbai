<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Review.aspx.cs" Inherits="ExploreMumbai.Admin_Review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reviews</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            
            background-color: black;
            margin: 0;
        }

        .container-main {
            display: flex;
            justify-content: space-between;
            max-width: 2000px;
            margin: auto;
            padding: 20px;
        }

        .guide-container {
            background-color: lavender  ;
            width: 48%;
            padding: 20px;
            border: 1px solid #dee2e6;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .add-review-container {
            background-color: lightblue;
            padding: 10px;
            border-radius: 5px;
        }

        .btn-primary {
            background-color: #007bff;
            border: 1px solid #007bff;
        }

        .btn-primary:hover {
            background-color: #0056b3;
            border: 1px solid #0056b3;
        }

        .guide-details {
            margin-top: 15px;
        }
        .review-box{
            background-color: #ffffff;
            margin-bottom: 20px;
            padding: 20px;
            border: 1px solid #dee2e6;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .guide-image {
            max-width: 100%;
            height: 320px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

                <div class="container-main">



                 <!-- Second container on the right side -->
         <div class="guide-container">
             <asp:Repeater ID="Repeater1" runat="server">
                 <ItemTemplate>
                     <div class="text-center mb-3">
                         <asp:Image ID="imgGuide" runat="server" CssClass="guide-image" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Guide_Image")) %>' />
                     </div>
                     <div class="guide-details">
                         <p>ID: <%# Eval("GuideId") %></p>
                         <p>Name: <%# Eval("Guide_FirstName") %> <%# Eval("Guide_LastName") %></p>
                         <p>Education: <%# Eval("Guide_Education") %></p>
                         <p>Age: <%# Eval("Guide_Age") %></p>
                         <p>Contact: <%# Eval("Guide_Contact") %></p>
                         <p>Description :  <asp:TextBox Text='<%# Eval("Guide_Description") %>' runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Rows="2" /></p>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>
         </div>

                                     <!-- Second container on the right side -->

            <div class="guide-container">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="GuideName">GUIDE NAME:</label>
                            <asp:DropDownList ID="GuideName" runat="server" class="form-control" OnSelectedIndexChanged="GuideName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="add-review-container">
                    <asp:Label Text="Delete Review :" runat="server" />
                    <asp:TextBox ID="txt_Review" runat="server" CssClass="form-control"  />
                    <br />
                    <asp:Button Text="Delete" runat="server" CssClass="btn btn-primary" OnClick="Delete_Review" />
                    <asp:Button Text="Refresh" runat="server" CssClass="btn btn-primary" OnClick="reload"  />
                    <asp:Button Text="Home" runat="server" CssClass="btn btn-primary" OnClick="back" />
                </div>

                <asp:Repeater ID="rptGuides" runat="server">
                    <ItemTemplate>
                        <div class="review-box ">
                            <div class="username-column">
                                <%# Eval("UserId") %>
                            </div>
                            <div class="review-column">
                                <asp:TextBox Text='<%# Eval("review") %>' runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Rows="2" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

           
        </div>
    </form>
</body>
</html>
