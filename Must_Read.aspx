<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Must_Read.aspx.cs" Inherits="ExploreMumbai.Must_Read" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Must Read - Mumbai Tourism</title>
    <!-- Add Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {

            background-color: lightblue; /* Light gray background */
            color: #495057; /* Dark gray text */
            font-family: 'Arial', sans-serif;
        }

        /* Header Styling */
        .header {
            background-color: lavender; /* Blue header */
            color: black; /* White text */
            padding: 1px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* subtle shadow */
        }

        /* Mumbai Map Section */
        .map-section {
            margin-top: 20px;
        }

        /* Emergency Contact Section */
        .emergency-contact-section {
            margin-top: 30px;
            background-color: #dc3545; /* Red background */
            color: #ffffff; /* White text */
            padding: 15px;
            border-radius: 5px;
        }

        .emergency-contact-section a {
            color: #ffffff; /* White links */
        }

        /* Must-Read Information Section */
        .additional-info-section {
            margin-top: 30px;
            background-color: lavender; /* White background */
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* subtle shadow */
        }

        .highlight {
            color: #007bff; /* Blue highlight color */
            font-weight: bold;
        }

        /* Add your custom styles here */
    </style>
</head>
<body>
    <div class="container">
        <div class="header">
            <h1 class="mt-4 mb-4">Welcome to Mumbai!</h1>
        </div>

        <!-- Mumbai Map Section -->
        <div class="map-section">
            <!-- Embed an interactive map of Mumbai using your preferred mapping service -->
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d24135.264045808234!2d72.82103617135742!3d18.94084834426889!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be7c6303d7c1e8b%3A0x7d6ca06fa4ef08e7!2sMumbai%2C%20Maharashtra!5e0!3m2!1sen!2sin!4v1626749443779!5m2!1sen!2sin" height="450" style="border:0;" allowfullscreen="" loading="lazy" class="w-100"></iframe>
        </div>

        <!-- Emergency Contact Information -->
        <div class="emergency-contact-section">
            <h2>Emergency Contact Information</h2>
            <ul class="list-unstyled">
                <li><strong>Police:</strong><a href="tel:100">100</a></li>
                <li><strong>Ambulance:</strong> <a href="tel:102">102</a></li>
                <li><strong>Fire Department:</strong> <a href="tel:101">101</a></li>
                <!-- Add more emergency contacts as needed -->
            </ul>
        </div>

        <!-- Additional Must-Read Information -->
        <div class="additional-info-section">
           <h1>Must Read - Mumbai Tourism</h1>

        <h2>Attractions:</h2>
        <p>
            Explore popular tourist attractions such as the <span class="highlight">Gateway of India</span>, 
            <span class="highlight">Chhatrapati Shivaji Maharaj Terminus</span>, <span class="highlight">Marine Drive</span>, 
            <span class="highlight">Elephanta Caves</span>, and <span class="highlight">Siddhivinayak Temple</span>.
        </p>
        <p>
            Discover cultural and historical sites like the <span class="highlight">Chhatrapati Shivaji Maharaj Vastu Sangrahalaya</span> 
            (formerly Prince of Wales Museum) and the <span class="highlight">Jehangir Art Gallery</span>.
        </p>

        <h2>Local Cuisine:</h2>
        <p>
            Indulge in the diverse and delicious local cuisine. Savor street food delights such as <span class="highlight">vada pav</span>, 
            <span class="highlight">pav bhaji</span>, and <span class="highlight">bhel puri</span>. Additionally, relish authentic Maharashtrian cuisine 
            at local restaurants.
        </p>

        <!-- Add more sections as needed -->

        <h2>Transportation:</h2>
        <p>
            Explore the city using the efficient suburban railway system, BEST buses, and the iconic black-and-yellow taxis. 
            Emphasize the convenience of app-based ridesharing services.
        </p>

        <h2>Language:</h2>
        <p>
            While Marathi is the official language, English and Hindi are widely spoken, making it relatively easy for foreigners to communicate.
        </p>

        <h2>Safety Tips:</h2>
        <p>
            Prioritize safety with these tips: Familiarize yourself with local emergency numbers including <span class="highlight">Police 100</span>, 
            <span class="highlight">Ambulance 102</span>, and <span class="highlight">Fire Department 101</span>. Know the location of the nearest embassy or consulate.
        </p>

        <h2>Cultural Etiquette:</h2>
        <p>
            Respect local customs and cultural norms. It's customary to remove shoes before entering someone's home and to dress modestly when visiting religious sites.
        </p>

        <h2>Weather:</h2>
        <p>
            Mumbai's climate varies. Pack accordingly based on the time of year. Be aware of the monsoon season and its potential impact on travel plans.
        </p>

        <h2>Currency and Banking:</h2>
        <p>
            Use the local currency (Indian Rupee) and find ATMs for convenience. Carry some cash for small transactions, but credit/debit cards are widely accepted.
        </p>

        <h2>Festivals and Events:</h2>
        <p>
            Check for major festivals and events during your visit to experience local culture and celebrations.
        </p>

        <h2>Shopping:</h2>
        <p>
            Explore popular shopping destinations such as Colaba Causeway and Linking Road. Find traditional Indian clothing, handicrafts, and souvenirs.
        </p>

        <h2>Health and Medical Facilities:</h2>
        <p>
            Stay informed about local medical facilities, emergency services, and health precautions for a safe and enjoyable trip.
        </p>
        </div>

        <!-- Add Bootstrap JS and Popper.js -->
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
        </div>
    </div>

    <!-- Add Bootstrap JS and Popper.js -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>

