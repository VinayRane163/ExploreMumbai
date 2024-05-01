using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ExploreMumbai
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["TourName"]))
                {
                    // Get the TourName from the query string
                    string selectedTourName = Server.UrlDecode(Request.QueryString["TourName"]);

                    // Add the TourName to the DropDownList
                    Tour_Name.Items.Add(new ListItem(selectedTourName, selectedTourName));
                    Tour_Name.SelectedValue = selectedTourName; 
                }

                if (!string.IsNullOrEmpty(Request.QueryString["GuideId"]) && !string.IsNullOrEmpty(Request.QueryString["GuideName"]))
                {

                    // Get the GuideId and GuideName from the query string
                    string selectedGuideId = Server.UrlDecode(Request.QueryString["GuideId"]);
                    string selectedGuideName = Server.UrlDecode(Request.QueryString["GuideName"]);

                    // Add the GuideName to the DropDownList
                    GuideName.Items.Add(new ListItem(selectedGuideName, selectedGuideId));
                    GuideName.SelectedValue = selectedGuideId;
                    SelectGuideCheckbox.Checked = true;

                }


                if (Session["session_id"] == null)
                {

                    ///Response.Redirect("Login.aspx");

                    string successScript = "if (confirm('Need to Login')) { window.location.href = 'login.aspx'; } else { setTimeout(function(){ window.location.href = 'login.aspx'; }, 000); };";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
                }

                else
                {
                    string userid = Session["User_id"].ToString();
                    SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from UserInfo where User_id=@User_id ", conn);
                    cmd.Parameters.AddWithValue("@User_id", userid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User_id.Text = reader["User_id"].ToString();
                        User_Name.Text = reader["User_Name"].ToString();
                        User_mobile.Text = reader["User_mobile"].ToString();

                        User_id.ReadOnly = true;
                        User_Name.ReadOnly = true;
                        User_mobile.ReadOnly = true;
                        travel_date.ReadOnly = true;
                    }
                    if (SelectGuideCheckbox.Checked)
                    {
                        // If the checkbox is checked, show the guide-related controls
                        Label2.Visible = true;
                        GuideName.Visible = true;
                        GuideId.Visible = false;
                        Label1.Visible = false;
                    }
                    else
                    {
                        // If the checkbox is not checked, hide the guide-related controls
                        Label2.Visible = false;
                        GuideName.Visible = false;
                        GuideId.Visible = false;
                        Label1.Visible = false;
                    }

                }
                Tours();
                Guides();

            }


        }

        private void Tours()
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
            {
                conn.Open();
                string query = "SELECT Tour_Name, Tour_Price FROM ToursInfo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader1 = cmd.ExecuteReader())
                    {
                        Tour_Name.DataSource = reader1;
                        Tour_Name.DataTextField = "Tour_Name";
                        Tour_Name.DataBind();
                    }
                }
            }
            string selectedTour = Tour_Name.Text;

            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd1 = new SqlCommand("select Tour_Price from ToursInfo WHERE Tour_Name=@Tour_Name", connection);

            cmd1.Parameters.AddWithValue("@Tour_Name", selectedTour);

            connection.Open();
            SqlDataReader reader = cmd1.ExecuteReader();

            if (reader.Read())
            {
                Tour_Price.Text = reader["Tour_Price"].ToString();
                Tour_Price.ReadOnly = true;
            }

            connection.Close();
        }

        private void Guides()
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
            {
                conn.Open();
                string query = "SELECT GuideId, CONCAT(Guide_FirstName, ' ', Guide_LastName) AS GuideName FROM GuideInfo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        GuideName.DataSource = reader;
                        GuideName.DataTextField = "GuideName";
                        GuideName.DataValueField = "GuideId";
                        GuideName.DataBind();
                    }
                }
            }

            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand lol = new SqlCommand("select * from GuideInfo WHERE GuideId=@GuideId ", connection);
            lol.Parameters.AddWithValue("@GuideId", GuideId.Text);
            connection.Open();
            SqlDataReader read = lol.ExecuteReader();

            if (read.Read())
            {


                GuideId.Text = read["GuideId"].ToString();
                GuideId.ReadOnly = true;
            }
        }



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;

            // Check if the selected date is before the current date
            if (selectedDate < DateTime.Today)
            {
                string errorScript = "alert('select current date or next after current date');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "GuideBookingErrorScript", errorScript, true);
                return;
            }
            else
            {
                travel_date.Text = Calendar1.SelectedDate.ToShortDateString();
                travel_date.ReadOnly = true;
            }


        }


        protected void Tour_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTour = Tour_Name.Text;

            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("select Tour_Price from ToursInfo WHERE Tour_Name=@Tour_Name", connection);
            cmd.Parameters.AddWithValue("@Tour_Name", selectedTour);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Tour_Price.Text = reader["Tour_Price"].ToString();
                Tour_Price.ReadOnly = true;
            }
            connection.Close();

        }

        protected void GuideName_SelectedIndexChanged(object sender, EventArgs e)
        {


            GuideId.Text = GuideName.SelectedValue;
            GuideId.ReadOnly = true;

            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM booking WHERE GuideId = @GuideId AND travel_date = @SelectedDate AND GuideId <> 0", connection);
            command.Parameters.AddWithValue("@GuideId", GuideId.Text);

            if (DateTime.TryParse(travel_date.Text, out DateTime selectedDate))
            {
                command.Parameters.AddWithValue("@SelectedDate", selectedDate);
            }
            else
            {
                string errorScript = "alert('Invalid date format. Please enter a valid date.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidDateScript", errorScript, true);
                return;
            }




            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {

                string errorScript = "alert('The selected guide is already booked on the specified date. Please choose a different date or guide.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "GuideBookingErrorScript", errorScript, true);
            }


        }
        /* calclate toal*/

        protected void CalculateTotal(object sender, EventArgs e)
        {
            if (int.TryParse(Tour_People_Number.Text, out int numberOfPeople))
            {
                // Check if Tour_Price is a valid decimal
                if (decimal.TryParse(Tour_Price.Text, out decimal tourPrice))
                {

                    decimal tourPriceTotal = tourPrice * numberOfPeople;


                    Tour_Price_Total.Text = tourPriceTotal.ToString("F2");
                }

            }

        }

        /* sumbit code*/


        protected void Book_btn_Click(object sender, EventArgs e)
        {

            string selectedGuideName = GuideName.SelectedItem.Text;
            string selectedTourName = Tour_Name.SelectedItem.Text;



            if (string.IsNullOrEmpty(User_id.Text) ||
            string.IsNullOrEmpty(User_Name.Text) ||
            string.IsNullOrEmpty(User_mobile.Text) ||
            string.IsNullOrEmpty(User_Country.Text) ||
            string.IsNullOrEmpty(User_Address.Text) ||
            string.IsNullOrEmpty(travel_date.Text) ||
            string.IsNullOrEmpty(Tour_Name.Text) ||
            string.IsNullOrEmpty(Tour_Price.Text) ||
            string.IsNullOrEmpty(Tour_People_Number.Text) ||
            string.IsNullOrEmpty(Tour_Price_Total.Text)
            )
            {
                string errorScript = "alert('Please fill/select in all the required fields.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationErrorScript", errorScript, true);
                return;
            }


            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM booking WHERE GuideId = @GuideId AND travel_date = @SelectedDate AND GuideId <> 0", connection);
            command.Parameters.AddWithValue("@GuideId", GuideId.Text);

            if (DateTime.TryParse(travel_date.Text, out DateTime selectedDate))
            {
                command.Parameters.AddWithValue("@SelectedDate", selectedDate);
            }
            else
            {
                string errorScript = "alert('Invalid date format. Please enter a valid date.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidDateScript", errorScript, true);
                return;
            }




            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {

                string errorScript = "alert('The selected guide is already booked on the specified date. Please choose a different date or guide.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "GuideBookingErrorScript", errorScript, true);
            }


            else
            {
                /*using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO booking (User_id, User_Name, User_mobile, User_Country, User_Address, travel_date, Tour_Name, Tour_Price, Tour_People_Number, Tour_Price_Total, GuideName, GuideId) VALUES (@User_id, @User_Name, @User_mobile, @User_Country, @User_Address, @travel_date, @Tour_Name, @Tour_Price, @Tour_People_Number, @Tour_Price_Total, @GuideName, @GuideId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@User_id", User_id.Text);
                        cmd.Parameters.AddWithValue("@User_Name", User_Name.Text);
                        cmd.Parameters.AddWithValue("@User_mobile", User_mobile.Text);
                        cmd.Parameters.AddWithValue("@User_Country", User_Country.Text);
                        cmd.Parameters.AddWithValue("@User_Address", User_Address.Text);
                        cmd.Parameters.AddWithValue("@travel_date", DateTime.Parse(travel_date.Text));
                        cmd.Parameters.AddWithValue("@Tour_Name", selectedTourName);
                        cmd.Parameters.AddWithValue("@Tour_Price", Convert.ToDecimal(Tour_Price.Text));

                        cmd.Parameters.AddWithValue("@Tour_People_Number", Convert.ToInt32(Tour_People_Number.Text));
                        cmd.Parameters.AddWithValue("@Tour_Price_Total", Convert.ToDecimal(Tour_Price_Total.Text));
                        cmd.Parameters.AddWithValue("@GuideName", selectedGuideName);
                        cmd.Parameters.AddWithValue("@GuideId", GuideId.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                string successScript = "alert('You have successfully booked your tour .');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);


                string email = User_id.Text.Trim();
                string User_Name0 = User_Name.Text.Trim();
                string User_mobile0 = User_mobile.Text.Trim();
                string User_Country0 = User_Country.Text.Trim();
                string travel_date0 = travel_date.Text.Trim();
                string Tour_Price0 = Tour_Price.Text.Trim();
                string Tour_People_Number0 = Tour_People_Number.Text.Trim();
                string GuideId0 = GuideId.Text.Trim();
                string Tour_Price_Total0 = Tour_Price_Total.Text.Trim();

                /* selectedGuideName   selectedTourName*/



                // SendResetEmail(email, User_Name0, User_mobile0, User_Country0, travel_date0, Tour_Price0, Tour_People_Number0, GuideId0, Tour_Price_Total0, selectedGuideName, selectedTourName);


                string email = User_id.Text.Trim();
                string User_Name0 = User_Name.Text.Trim();
                string User_mobile0 = User_mobile.Text.Trim();
                string User_Country0 = User_Country.Text.Trim();
                string travel_date0 = travel_date.Text.Trim();
                string Tour_Price0 = Tour_Price.Text.Trim();
                string Tour_People_Number0 = Tour_People_Number.Text.Trim();
                string GuideId0 = GuideId.Text.Trim();
                string Tour_Price_Total0 = Tour_Price_Total.Text.Trim();
                string guide = GuideName.SelectedItem.Text.Trim();
                string add = User_Address.Text.Trim();

                Session["payment"] = Session.SessionID;


                // Redirect to Payment.aspx with query parameters
                Response.Redirect($"Payment.aspx?email={email}&User_Name={User_Name0}&User_mobile={User_mobile0}&User_Country={User_Country0}&travel_date={travel_date0}&Tour_Price={Tour_Price0}&Tour_People_Number={Tour_People_Number0}&GuideId={GuideId0}&Tour_Price_Total={Tour_Price_Total0}&TourName={selectedTourName}&guide={guide}&add={add}");



                cleartext();




            }

            void cleartext()
            {
                User_Country.Text = "";
                User_Address.Text = "";
                travel_date.Text = "";
                Tour_People_Number.Text = "";
                Tour_Price_Total.Text = "";
            }
        }

        protected void Bk_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void SelectGuideCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectGuideCheckbox.Checked)
            {
                // If the checkbox check show the guide data
                Label2.Visible = true;
                GuideName.Visible = true;
                GuideId.Visible = false;
                Label1.Visible = false;
            }
            else
            {
                // If the checkbox not check hide the guide data
                Label2.Visible = false;
                GuideName.Visible = false;
                GuideId.Visible = false;
                Label1.Visible = false;
            }
        }



        private void SendResetEmail(string email,
            string User_Name0,
            string User_mobile0,
            string User_Country0,
            string travel_date0,
            string Tour_Price0,
            string Tour_People_Number0,
            string GuideId0,
            string Tour_Price_Total0,
            string selectedGuideName,
            string selectedTourName)
        {

            // Gmail SMTP configuration
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "exploremumbai69@gmail.com";
            string smtpPassword = "svrc qelk zbvx nxle";

            // Email content
            string subject = "Booking  - Explore Mumbai";
            string body = $@"
                            <html>
                                <body style='font-family: Arial, sans-serif;'>
                                    <p>Dear {User_Name0},</p>
                                    <p>Thank you for booking with Explore Mumbai! Here is your booking receipt:</p>
                                    <table style='border: 1px solid #dddddd; border-collapse: collapse; width: 100%; margin-top: 20px;'>
                                        <tr>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Tour:</strong></td>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'>{selectedTourName}</td>
                                        </tr>
                                        <tr>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Travel Date:</strong></td>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'>{travel_date0}   (mm-dd-yyyy)</td>
                                        </tr>
                                        <tr>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Guide:</strong></td>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'>{selectedGuideName}</td>
                                        </tr>
                                                <tr>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Guide ID:</strong></td>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'>{GuideId0}</td>
                                        </tr>                                                                            
                                        <tr>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Tour Price:</strong></td>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'>₹{Tour_Price0} </td>
                                        </tr>
                                        <tr>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Number of People:</strong></td>
                                            <td style='border: 1px solid #dddddd; padding: 8px;'>{Tour_People_Number0}</td>
                                        </tr>                                          
                                     </table>

                                    <p style='margin-top: 20px;'><strong>Total Amount:</strong>  {Tour_Price_Total0} rupees only /- </p>

                                    <p style='margin-top: 20px;'>Thank you for choosing Explore Mumbai! We look forward to serving you.</p>
                                    <p>Sincerely,<br>ExploreMumbai</p>
                                </body>
                            </html>
                            ";


            using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    smtpClient.Send(mailMessage);
                }



            }
        }

    }

}
