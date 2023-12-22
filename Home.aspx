<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExploreMumbai.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Mumbai Tourism</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style> 
        .header{
            background-image:url('https://indianparyatak.com/wp-content/uploads/2022/09/juhu-beach-mumbai-indian-tourism-entry-fee-timings-holidays-reviews-header-1.jpg');
            background-repeat:no-repeat;
             background-size: cover;
             background-position: center center;
             background-attachment: fixed;
            font-style : italic;
            text-indent:20px;
     
        }
        .color{
            color: black;
        }
        
        footer{
            background-color: antiquewhite;
        }

        .button{
            background-image:url('https://e7.pngegg.com/pngimages/609/720/png-clipart-cranberry-yellow-button-gradient-rounded-blank-background-color-web-design.png');
            background-repeat:no-repeat;
             background-size: auto;
             background-position: center center;
             color:black
        }

        
    </style>
</head>
<body>
    <header class="header color text-center py-3">
        <h1 class="header display-4">Explore Mumbai</h1>
        <nav>
            <ul class="nav text-center" >
                <li class="nav-item"><a class="nav-link color"  href="#home" >Home</a></li>
                <li class="nav-item"><a class="nav-link color" href="Tours.aspx">Tours</a></li>
                <li class="nav-item"><a class="nav-link color" href="Guide_Info.aspx">Guide</a></li>
                <li class="nav-item"><a class="nav-link color" href="Book.aspx">Book Now</a></li>
                <li class="nav-item"><a class="nav-link color" href="Reviews.aspx">Reviews</a></li>
                <li class="nav-item"><a class="nav-link color" href="Must_Read.aspx">Must Read</a></li>
                <li class="nav-item"><a class="nav-link color" href="#contact">Contact</a></li>
                <li class="nav-item"><a class="nav-link color" href="User_Panel.aspx">User Panel</a></li>

            </ul>
        </nav>
    </header>

    <section id="home" class="container my-5">
        <h2 class="mb-4">Welcome to Mumbai</h2>
        <p class="lead">Explore the vibrant city of Mumbai and its rich culture, history, and attractions.</p>
    </section>

    <section id="tours" class="container my-5">
        <h2 class="mb-4">Popular Tours</h2>

        <a href="tours.html" class="btn button mb-4 ">View All Tours</a>

        <div class="card mb-3">
            <img src="https://planetofhotels.com/guide/sites/default/files/styles/paragraph__hero_banner__hb_image__1880bp/public/hero_banner/Gateway-to-India_0.jpg" />
            <div class="card-body">
                <h3 class="card-title">Gateway of India Tour</h3>
                <p class="card-text">Discover the iconic Gateway of India and its historical significance.</p>
            </div>
        </div>

        <div class="card mb-3">
            <img src="https://upload.wikimedia.org/wikipedia/commons/4/4f/Mumbai_03-2016_77_sunset_at_Marine_Drive.jpg" />
            <div class="card-body">
                <h3 class="card-title">Marine Drive Sunset Cruise</h3>
                <p class="card-text">Experience the breathtaking views of the sunset along Marine Drive.</p>
            </div>
        </div>
    </section>


    <section id="booking" class="container my-5">
        <a href="Book.aspx" class="btn button mb-4 ">BOOK YOUR TOUR HERE</a>

    </section>
    
    <footer>
    <section class=" color text-center py-3 bottom">
        <section id="contact">
            <h2>Contact Us</h2>
            <p>For inquiries and more information, contact us at <a href="mailto:exploremumbai69@gmail.com" class="color">exploremumbai69@gmail.com</a></p>
        </section>
    </section>
        </footer>



    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</body>
</html>