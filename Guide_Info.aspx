<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guide_Info.aspx.cs" Inherits="ExploreMumbai.Guide_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Explore Mumbai - Guide Information</title>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
	<style>
		body {
			background-color: lightblue;
			padding-top: 60px;
			font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
		}

		.container{
			 background-color: lavender;
			 box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
			 border-radius: 10px;
			 padding: 20px;
		}

		.guide-container {
			background-color: lightblue;
			 margin-bottom: 20px;
			 border: 1px solid #e9ecef;
			 border-radius: 10px;
			 overflow: hidden;
			 box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
			 transition: transform 0.3s ease-in-out;
		}

		.guide-container:hover {
			transform: scale(1.02);
		}

		.guide-image {
			max-width: 100%;
			height: auto;
			max-height: 300px;
			border-radius: 10px;
			box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
		}

		h2 {
			color: #007bff;
			text-align: center;
			margin-bottom: 30px;
		}

		.guide-details {
			text-align: left;
			margin-left:20px;
			margin-top: 20px;
		}

		.guide-details p {
			margin: 5px 0;
		}
	 
		.euu{color:black;}
		.btn-info{
			color: #ffffff;
			width: 150px;
			margin-top: 20px;
			padding: 10px 15px;
			text-decoration: none;
			text-align: center;
			display: inline-block;
			border-radius: 5px;
			transition: background-color 0.3s ease-in-out;
		}

	.btn-info:hover {
		background-color: black;
		 color: white;               
	}
	</style>
</head>
<body>
	<form id="form1" runat="server">
		<nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top">
			<a class="navbar-brand" href="home.aspx">Explore Mumbai Guides</a>
		</nav>

		<div class="container">
			<div class="row">
				<asp:Repeater ID="rptGuides" runat="server">
					<ItemTemplate>
						<div class="col-md-6">
							<div class="guide-container">
								<div class="text-center mb-3">
									<asp:Image ID="imgGuide" runat="server" CssClass="guide-image" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Guide_Image")) %>' />
								</div>
								<div class="guide-details">
									
									<p>Name: <%# Eval("Guide_FirstName") %> <%# Eval("Guide_LastName") %></p>
									<p>Education: <%# Eval("Guide_Education") %></p>
									<p>Birth date: <%# Eval("Guide_Age") %></p>
									<p>Contact: <%# Eval("Guide_Contact") %></p>
								    <p>Description :<asp:TextBox Text='<%# Eval("Guide_Description") %>' runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Rows="3" /></p>

									<center><a href="GuideReview.aspx" class="btn-info">Reviews</a></center>


								</div>
							</div>
						</div>
					</ItemTemplate>
				</asp:Repeater>
			</div>
		</div>
	</form>
</body>
</html>
