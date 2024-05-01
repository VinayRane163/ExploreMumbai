<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_guide.aspx.cs" Inherits="ExploreMumbai.edit_guide" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Tours</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        .container {
            margin-top:10px;
            width:1000px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .hehe {
            text-align: end;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
      
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <div class="row" >
            <div class="col-md-5" align="center">
                <div class="form-group">
                    <label for="TourId">Enter Guide ID:</label>
                    <asp:TextBox ID="TourId" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="form-group">
                    <label for="GuideEducation">Guide Education:</label>
                    <asp:TextBox ID="GuideEducation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="GuideBirthDate">Guide Birth Date:</label>
                    <asp:TextBox ID="GuideBirthDate" runat="server" CssClass="form-control" Width="380px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="GuideContact">Guide Contact:</label>
                    <asp:TextBox ID="GuideContact" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" CssClass="btn btn-info btn-block" />
                </div>
                
                <div class="form-group hehe">
                    <asp:Button ID="btnBack" runat="server" OnClick="BtnBack_Click" Text="Back" CssClass="btn btn-primary" />
                </div>
            </div>


            <div class="col-md-6 " align="left">
                            <!-- ... (existing HTML) ... -->

            <div class="col-md-6">
                <div class="form-group">
                    <label for="FirstName">First Name:</label>
                    <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" Width="380px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="LastName">Last Name:</label>
                    <asp:TextBox ID="LastName" runat="server" CssClass="form-control" Width="380px"></asp:TextBox>
                </div>
               
                <div class="form-group">
                    <label for="GuideDescription">Guide Description:</label>
                    <asp:TextBox ID="GuideDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" Width="380px"></asp:TextBox>
                </div>
            </div>
                <br />
            <div class="form-group">
                <asp:Button ID="btnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" CssClass="btn btn-info btn-block" />
            </div>
            <div class="form-group">
                <asp:Button ID="add" runat="server" OnClick="BtnAdd_Click" Text="Add Guide" CssClass="btn btn-info btn-block" />
            </div>

                </div>
            <!-- ... (existing HTML) ... -->

        </div>

        <div class="row">
            <div class="col-md-12">
                <table>
                    <tr>
                        <th>ID</th>
                        <th>First name</th>
                        <th>Last  Name</th>
                        <th>Education</th>
                        <th>Birth date</th>
                        <th>Contact</th>
                         <th>Description</th>
    
                    </tr>
                    <asp:Repeater ID="rptGuides" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("GuideID") %></td>                                
                                <td><%# Eval("Guide_FirstName") %></td>
                                <td><%# Eval("Guide_LastName") %></td>
                                <td><%# Eval("Guide_Education") %></td>
                                <td><%# Eval("Guide_Age") %></td>
                                <td><%# Eval("Guide_Contact") %></td>
                                <td><%# Eval("Guide_Description") %></td>
                              
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
