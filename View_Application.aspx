<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Application.aspx.cs" Inherits="ExploreMumbai.View_Application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Applications</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">View Applications</h2>

            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="Application_ID" HeaderText="Application ID" SortExpression="Application_ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Contact" HeaderText="Contact" SortExpression="Contact" />

                            <asp:TemplateField HeaderText="CV">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkViewCV" runat="server" CommandName="ViewCV" CommandArgument='<%# Bind("Application_ID") %>'
                                        CssClass="btn btn-primary btn-sm">View CV</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div class="mt-3">
                        <asp:Button runat="server" Text="Reject" OnClick="del" CssClass="btn btn-danger mr-2" />
                        <asp:Button runat="server" Text="Accept and Next" OnClick="nxt" CssClass="btn btn-info" />
                        <asp:Button runat="server" Text="back" OnClick="bACK_Click" CssClass="btn btn-info" />
                    </div>
                </div>
            </div>

            <div id="pdfViewerContainer" runat="server" class="mt-4" visible="false">
                <iframe id="pdfViewer" runat="server" width="100%" height="600px" class="border-0"></iframe>
            </div>  
        </div>

        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.3/dist/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
