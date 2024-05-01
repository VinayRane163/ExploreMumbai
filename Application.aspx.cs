using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Application : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add any necessary initialization logic
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(Email.Text) ||
                string.IsNullOrEmpty(Contact.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidationScript", "alert('Fill all fields');", true);
                return;
            }

            // Check if a file is selected
            if (imageUpload.HasFile && imageUpload.PostedFile.ContentType == "application/pdf")
            {
                // Read the PDF file into a byte array
                byte[] fileData = imageUpload.FileBytes;

                // Save the file path to the database
                SaveToDatabase(fileData);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidationScript", "alert('Select a PDF file');", true);
            }
        }

        private void SaveToDatabase(byte[] fileData)
        {
            // Connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to insert data into the database
                string query = "INSERT INTO Applicaton (Name, Email, CV, Contact) " +
                               "VALUES (@Name, @Email, @CV, @Contact)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Set parameter values from form controls
                    cmd.Parameters.AddWithValue("@Name", Name.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Contact", Contact.Text);

                    // Use SqlDbType.VarBinary for binary data
                    cmd.Parameters.Add("@CV", System.Data.SqlDbType.VarBinary, -1).Value = fileData;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", "alert('Successfully applied');", true);
                    ClearTextboxes();
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        private void ClearTextboxes()
        {
            // Clear textboxes after successful submission
            Name.Text = "";
            Email.Text = "";
            Contact.Text = "";
        }
    }
}
