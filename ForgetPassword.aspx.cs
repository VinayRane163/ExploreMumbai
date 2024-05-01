using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ExploreMumbai
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnForgotPassword_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                string script = "alert('please enter User Id (email) 🙂 ');";
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);
            }
            else
            {


                try
                {
                    string email = txtEmail.Text.Trim();

                    // Check if the email exists in the database
                    string user_id;
                    string Password;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("SELECT User_id, User_password FROM UserInfo WHERE User_id = @User_id", conn))
                        {
                            cmd.Parameters.AddWithValue("@User_id", email);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    user_id = reader["User_id"].ToString();
                                    Password = reader["User_password"].ToString();

                                    // Send a password reset link to the user's email using the existing password
                                    SendResetEmail(email, user_id, Password);

                                    string script = "alert('Password reset successful. Check your email for further instructions.');";
                                    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);
                                    clear();

                                    void clear()
                                    {
                                        txtEmail.Text = "";
                                    }
                                }
                                else
                                {
                                    string script = "alert('User with the provided email does not exist');";
                                    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }

        }


        private void LogMessage(string message)
        {

        }

        private void LogException(Exception ex)
        {

        }





        private void SendResetEmail(string email, string username, string Password)
        {
            try
            {
                // Gmail SMTP configuration
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "exploremumbai69@gmail.com";
                string smtpPassword = "svrc qelk zbvx nxle";

                // Email content
                string subject = "Password Recover - Explore Mumbai";
                string body = $"Dear {username},\n\nYour password is : {Password}\n\nPlease change your password after logging in.\n\nSincerely,\nExploreMumbai";

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

                        smtpClient.Send(mailMessage);
                    }


                    // Log success message after sending the email
                    LogMessage($"Password reset email sent successfully to {email}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                LogException(ex);
                lblMessage.Text = "An error occurred while sending the password reset email. Please try again later.";
            }
        }

    }
}