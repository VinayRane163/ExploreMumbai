<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_tours.aspx.cs" Inherits="ExploreMumbai.edit_tours" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Tours</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        .container {
            margin-top:10px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .hehe {
            text-align: center;
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
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="TourId">Enter Tour ID:</label>
                    <asp:TextBox ID="TourId" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" CssClass="btn btn-info btn-block" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" CssClass="btn btn-info btn-block" />
                </div>
                <div class="form-group">
                    <asp:Button ID="add" runat="server" OnClick="BtnAdd_Click" Text="Add" CssClass="btn btn-info btn-block" />
                </div>
               
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="Tour_Name">Tour Name:</label>
                    <asp:TextBox ID="Tour_Name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Tour_Price">Tour Price:</label>
                    <asp:TextBox ID="Tour_Price" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Tour_Description">Tour Description:</label>
                    <asp:TextBox ID="Tour_Description" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
                <div runat="server" id="TourDetails" class="mt-3"></div>
            </div>
        </div>
         <div class="form-group hehe">
     <asp:Button ID="btnBack" runat="server" OnClick="BtnBack_Click" Text="Back" CssClass="btn btn-primary" />
 </div>
        <div class="row">
            <div class="col-md-12">
                <table>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Description</th>
                    </tr>
                    <asp:Repeater ID="rptGuides" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Tour_Id") %></td>
                                <td><%# Eval("Tour_Name") %></td>
                                <td><%# Eval("Tour_Price") %></td>
                                <td><%# Eval("Tour_Description") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
