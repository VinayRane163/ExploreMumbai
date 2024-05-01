using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI;
using System.Drawing.Drawing2D;

namespace ExploreMumbai
{
    public partial class View_Application : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_id"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!IsPostBack)
            {
                // Load data into GridView
                BindGridView();
            }
        }

        private void BindGridView()
        {
            // Connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to select data from the database
                string query = "SELECT TOP 1 Application_ID, Name, Email, Contact FROM Applicaton ORDER BY Application_ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    // Execute the query and bind the data to the GridView
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();

                    conn.Close();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewCV")
            {
                // Get the Application_ID from the command argument
                int applicationID = Convert.ToInt32(e.CommandArgument);

                // Get the CV data for the specified Application_ID
                byte[] cvData = GetCVData(applicationID);

                // Display the PDF on the page
                DisplayPDF(cvData);
            }
        }

        private byte[] GetCVData(int applicationID)
        {
            // Connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to get the CV data for a specific Application_ID
                string query = "SELECT CV FROM Applicaton WHERE Application_ID = @Application_ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Application_ID", applicationID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    return result as byte[];
                }
            }
        }

        private void DisplayPDF(byte[] pdfData)
        {
            // Display the PDF on the page using an iframe
            pdfViewer.Src = $"data:application/pdf;base64,{Convert.ToBase64String(pdfData)}";
            pdfViewerContainer.Visible = true;
        }

        protected void bACK_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_panel.aspx");
        }






        protected void del(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
            try 
            { 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to select data from the database
                string deleteQuery = "DELETE FROM Applicaton WHERE Application_ID = (SELECT TOP 1 Application_ID FROM Applicaton ORDER BY Application_ID ASC);";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();



                    conn.Close();
                }
            }
            BindGridView();
        }
            catch 
            {
                string script = "alert(no more applications');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidUserScript", script, true);
        }

    }

        protected void nxt(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // SQL query to select data from the database
                    string selectQuery = "SELECT TOP 1 Email, Name FROM Applicaton ORDER BY Application_ID ASC;";
                    string deleteQuery = "DELETE FROM Applicaton WHERE Application_ID = (SELECT TOP 1 Application_ID FROM Applicaton ORDER BY Application_ID ASC);";

                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                    {
                        conn.Open();

                        // Execute the select query to retrieve values
                        SqlDataReader reader = selectCmd.ExecuteReader();

                        string email = "";
                        string name = "";

                        if (reader.Read())
                        {
                            email = reader["Email"].ToString();
                            name = reader["Name"].ToString();
                        }

                        conn.Close();
                        SendResetEmail(email, name);


                    }

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();



                        conn.Close();
                    }

                    BindGridView();
                }
            }
            catch 
            {
                string script = "alert(no more applications');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidUserScript", script, true);
            }

        }


        private void SendResetEmail(string email,string name)
        {

            // Gmail SMTP configuration
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "exploremumbai69@gmail.com";
            string smtpPassword = "svrc qelk zbvx nxle";

            // Email content
            string subject = "Hiring  - Explore Mumbai";
            string body = $@"
                    <html>
                        <body style='font-family: Arial, sans-serif;'>
                            <p>Dear {name},</p>
                            <p>Your application with Explore Mumbai has been approved!</p>
                            <p>You are invited to join us for a walk-in interview at your convenience. Please feel free to visit our office at any time during our working hours(10 a.m to 4 p.m).</p>
                            <p>We look forward to meeting you and discussing your potential role with Explore Mumbai.</p>
                            <p>Best regards,<br>Explore Mumbai Team</p>
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
