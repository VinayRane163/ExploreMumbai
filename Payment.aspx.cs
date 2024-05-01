using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            if (Session["payment"] == null)
            {
                Response.Redirect("book.aspx");

            }
            if (!IsPostBack)
            {
                string email = Request.QueryString["email"];
                string User_Name0 = Request.QueryString["User_Name"];
                string User_mobile0 = Request.QueryString["User_mobile"];
                string User_Country0 = Request.QueryString["User_Country"];
                string travel_date0 = Request.QueryString["travel_date"];
                string Tour_Price0 = Request.QueryString["Tour_Price"];
                string Tour_People_Number0 = Request.QueryString["Tour_People_Number"];
                string GuideId0 = Request.QueryString["GuideId"];
                string Tour_Price_Total0 = Request.QueryString["Tour_Price_Total"];
                string TourName = Request.QueryString["TourName"];
                string guide = Request.QueryString["guide"];


                // Populate your controls with these values
                username.Text = User_Name0;
                mobile.Text = User_mobile0;
                address.Text = User_Country0;
                travel_date.Text = travel_date0;
                tour_price.Text = Tour_Price0;
                tour_n_people.Text = Tour_People_Number0;
                GuideId.Text = GuideId0;
                total_Price.Text = Tour_Price_Total0;
                tourname.Text = TourName;
                Guidename.Text = guide;
                UserID.Text = email;

                // Set the visibility of the controls to false on the initial page load
                username.Visible = false;
                UserID.Visible = false;
                mobile.Visible = false;
                address.Visible = false;
                travel_date.Visible = false;
                Guidename.Visible = false;
                GuideId.Visible = false;
                tour_price.Visible = false;
                tour_n_people.Visible = false;

                tour_people.Visible = false;
                label_price.Visible = false;
                label_nameo.Visible = false;
                label_textbox_label.Visible = false;
                label_textbox_label_mobile.Visible = false;
                label_address.Visible = false;
                label_travel_date.Visible = false;
                label_textbox_label_guidename.Visible = false;
                label_textbox_label_guideid.Visible = false;



            }
        }


        protected void btnMakePayment_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            string User_Name0 = Request.QueryString["User_Name"];
            string User_mobile0 = Request.QueryString["User_mobile"];
            string User_Country0 = Request.QueryString["User_Country"];
            string travel_date0 = Request.QueryString["travel_date"];
            string Tour_Price0 = Request.QueryString["Tour_Price"];
            string Tour_People_Number0 = Request.QueryString["Tour_People_Number"];
            string GuideId0 = Request.QueryString["GuideId"];
            string Tour_Price_Total0 = Request.QueryString["Tour_Price_Total"];
            string TourName = Request.QueryString["TourName"];
            string guide = Request.QueryString["guide"];
            string add = Request.QueryString["add"];

            SqlConnection conn1 = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd1 = new SqlCommand("select * from cred where Card_Number=@Card_Number and CVV_CVV2=@CVV_CVV2 and Expiry_Date=@Expiry_Date", conn1);
            cmd1.Parameters.AddWithValue("@Card_Number", cardNumber.Text);
            cmd1.Parameters.AddWithValue("@CVV_CVV2", cvv.Text);
            cmd1.Parameters.AddWithValue("@Expiry_Date", expiryDate.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds,"cred");

            if (ds.Tables["cred"].Rows.Count == 0)
            {
                string script = "alert('invalid details');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidUserScript", script, true);
            }
            else 
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO booking (User_id, User_Name, User_mobile, User_Country, User_Address, travel_date, Tour_Name, Tour_Price, Tour_People_Number, Tour_Price_Total, GuideName, GuideId) VALUES (@User_id, @User_Name, @User_mobile, @User_Country, @User_Address, @travel_date, @Tour_Name, @Tour_Price, @Tour_People_Number, @Tour_Price_Total, @GuideName, @GuideId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@User_id", UserID.Text);
                        cmd.Parameters.AddWithValue("@User_Name", username.Text);
                        cmd.Parameters.AddWithValue("@User_mobile", mobile.Text);
                        cmd.Parameters.AddWithValue("@User_Country", address.Text);
                        cmd.Parameters.AddWithValue("@User_Address", add);
                        cmd.Parameters.AddWithValue("@travel_date", DateTime.Parse(travel_date.Text));
                        cmd.Parameters.AddWithValue("@Tour_Name", TourName);
                        cmd.Parameters.AddWithValue("@Tour_Price", Convert.ToDecimal(Tour_Price0));

                        cmd.Parameters.AddWithValue("@Tour_People_Number", Convert.ToInt32(Tour_People_Number0));
                        cmd.Parameters.AddWithValue("@Tour_Price_Total", Convert.ToDecimal(Tour_Price_Total0));
                        cmd.Parameters.AddWithValue("@GuideName", guide);
                        cmd.Parameters.AddWithValue("@GuideId", GuideId.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }



                SendResetEmail(email, User_Name0, travel_date0, Tour_Price0, Tour_People_Number0, GuideId0, Tour_Price_Total0, guide, TourName);



                string successScript = "if (confirm('You have successfully booked your tour')) { window.location.href = 'thankyou.aspx'; } else { setTimeout(function(){ window.location.href = 'thankyou.aspx'; }, 3000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);


                Session["payment"] = null;

            }

        }

        private void SendResetEmail(string email,
            string User_Name0,
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

                                    <p style='margin-top: 20px;'><strong>Total Amount:</strong> <b> <u> {Tour_Price_Total0} </u> rupees only /- </b> </p>

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