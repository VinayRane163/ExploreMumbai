<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guide_Info.aspx.cs" Inherits="ExploreMumbai.Guide_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guide Information</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
            padding: 20px;
        }

        .guide-container {
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 15px;
            background-color: palegoldenrod;
        }

        .guide-image {
            max-width: 100%;
            height: auto;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center mb-4">Guide Information</h2>
            <div class="row">
                <asp:Repeater ID="rptGuides" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <div class="guide-container">
                                <div class="text-center mb-3">
                                    <asp:Image ID="imgGuide" runat="server" CssClass="guide-image" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Guide_Image")) %>' />
                                </div>
                                <div class="text-center">
                                    ID:  <%# Eval("GuideId") %><br />
                                    Name: <%# Eval("Guide_FirstName") %>&nbsp;<%# Eval("Guide_LastName") %><br />Education: <%# Eval("Guide_Education") %><br />
                                    Age: <%# Eval("Guide_Age") %><br />
                                    Contact: <%# Eval("Guide_Contact") %><br />
                                    Description: <%# Eval("Guide_Description") %>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
            </div>

        </div>
    </form>
</body>
</html>
