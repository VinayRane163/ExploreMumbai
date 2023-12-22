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
            try
            {
                string email = txtEmail.Text.Trim();

                // Check if the email exists in the database
                string user_id;
                string newPassword;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT User_id FROM  UserInfo WHERE User_id = @User_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@User_id", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user_id = reader["User_id"].ToString();
                                newPassword = GenerateRandomPassword();

                                LogMessage($"Generated password: {newPassword}");

                                // Update the user's password in the database with the new temporary password
                                UpdatePassword(user_id, newPassword);

                                // Send a password reset link to the user's email
                                SendResetEmail(email, user_id, newPassword);

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


        private string GenerateRandomPassword()
        {
            // Generate a random password (you may use a more secure method)
            return Guid.NewGuid().ToString().Substring(0, 8);
        }


        private void UpdatePassword(string user_id, string newPassword)
        {
            try
            {
                // Hash the new password before updating in the database
                string hashedPassword = HashPassword(newPassword);

                // Log the generated and hashed password
                LogMessage($"Generated password: {newPassword}");
                LogMessage($"Hashed password before update: {hashedPassword}");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE UserInfo SET User_password=@User_password WHERE User_id=@User_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@User_password", newPassword);
                        cmd.Parameters.AddWithValue("@User_id", user_id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            LogMessage($"No rows updated for user {user_id}. Check if the user exists in the database.");
                        }
                    }
                }

                // Log the successful update
                LogMessage($"Password updated successfully for user {user_id}");
            }
            catch (Exception ex)
            {
                // Log the exception
                LogException(ex);
                throw; // Re-throw the exception to propagate it to the caller
            }
        }


        private void LogMessage(string message)
        {

        }

        private void LogException(Exception ex)
        {

        }



        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Modify the SendResetEmail method
        private void SendResetEmail(string email, string username, string newPassword)
        {
            try
            {
                // Gmail SMTP configuration
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "exploremumbai69@gmail.com";
                string smtpPassword = "svrc qelk zbvx nxle";

                // Email content
                string subject = "Password Reset - Explore Mumbai";
                string body = $"Dear {username},\n\nYour password has been reset to: {newPassword}\n\nPlease change your password after logging in.\n\nSincerely,\nExploreMumbai";

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