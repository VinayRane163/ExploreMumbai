<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thankyou.aspx.cs" Inherits="ExploreMumbai.thankyou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @keyframes typing {
            from {
                width: 0;
            }
            to {
                width: 100%;
            }
        }

        .typewriter {
            overflow: hidden;
            white-space: nowrap;
            margin: 0 auto;
            animation: typing 2s steps(40, end);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="typewriter">
           <center> <p style="font-size: 100px; font-weight: bold; text-align: center;">Thank you for booking the tour!</p></center>
        </div>
    </form>
</body>
</html>
