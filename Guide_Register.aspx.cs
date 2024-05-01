using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Guide_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_id"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Guide_FirstName.Text) ||
            string.IsNullOrEmpty(Guide_LastName.Text) ||
            string.IsNullOrEmpty(Guide_Education.Text) ||
            string.IsNullOrEmpty(Guide_Age.Text) ||
            string.IsNullOrEmpty(Guide_Contact.Text) ||
            string.IsNullOrEmpty(Guide_Description.Text))
            {
                string successScript = "alert('fill all fields');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
                return;
            }

            // Check if a file is selected
            if (imageUpload.HasFile)
            {
                // Get the file name and extension
                string fileName = Path.GetFileName(imageUpload.FileName);

                byte[] fileData = imageUpload.FileBytes;

                SaveToDatabase(fileName, fileData);


            }
            else
            {
                string successScript = "alert('select an image');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }


        }
        private bool ContactAlreadyUse(string contact)
        {
            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GuideInfo WHERE Guide_Contact = @Guide_Contact", conn);
            cmd.Parameters.AddWithValue("@Guide_Contact", contact);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }


        private void SaveToDatabase(string fileName, byte[] fileData)
        {
            // Connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
            if (ContactAlreadyUse(Guide_Contact.Text))
            {
                // Email already exists, show an error message
                string script = "alert('contact already in use,please enter different one');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);
                ClearTextboxes();

                void ClearTextboxes()
                {
                    Guide_Contact.Text = "";
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // SQL query to insert data into the database
                    string query = "INSERT INTO GuideInfo (Guide_FirstName, Guide_LastName, Guide_Education, Guide_Age,Guide_Contact, Guide_Description, Guide_Image) " +
                                   "VALUES (@FirstName, @LastName, @Education, @Age,@Guide_Contact, @Description, @Image)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set parameter values from form controls
                        cmd.Parameters.AddWithValue("@FirstName", Guide_FirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", Guide_LastName.Text);
                        cmd.Parameters.AddWithValue("@Education", Guide_Education.Text);
                        cmd.Parameters.AddWithValue("@Age", Guide_Age.Text);
                        cmd.Parameters.AddWithValue("@Description", Guide_Description.Text);
                        cmd.Parameters.AddWithValue("@Guide_Contact", Guide_Contact.Text);

                        // Use SqlDbType.VarBinary for binary data
                        cmd.Parameters.Add("@Image", System.Data.SqlDbType.VarBinary).Value = fileData;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        

                        string successScript = "alert('Succesfully registered');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
                        ClearTextboxes();

                    }
                    void ClearTextboxes()
                    {
                        // Clear textboxes after successful submission
                        Guide_FirstName.Text = "";
                        Guide_LastName.Text = "";
                        Guide_Education.Text = "";
                        Guide_Age.Text = "";
                        Guide_Description.Text = "";
                        Guide_Contact.Text = "";
                    }
                }

            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Panel.aspx");
        }
    }
}