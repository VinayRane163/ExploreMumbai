using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Add_tours : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session_id"] == null && Session["Admin_id"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tour_Name.Text) ||
            string.IsNullOrEmpty(Tour_Price.Text) ||
            string.IsNullOrEmpty(Tour_Description.Text))
            {
                string successScript = "alert('fill all fields');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }


            // Check if a file is selected
            if (imageUpload.HasFile)
            {
                // Get the file name and extension
                string fileName = Path.GetFileName(imageUpload.FileName);


                //  Convert the image file to byte array
                byte[] fileData = imageUpload.FileBytes;

                // Save the file path to the database
                SaveToDatabase(fileName, fileData);


            }
            else
            {
                string successScript = "alert('select an image');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }



        }


        private void SaveToDatabase(string fileName, byte[] fileData)
        {
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ToursInfo (Tour_Name, Tour_Price, Tour_Description,  Tour_Image) " +
                               "VALUES (@Tour_Name, @Tour_Price, @Tour_Description, @Image)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);
                    cmd.Parameters.AddWithValue("@Tour_Price", Tour_Price.Text);
                    cmd.Parameters.AddWithValue("@Tour_Description", Tour_Description.Text);

                   

                    // Use SqlDbType.VarBinary for binary data
                    cmd.Parameters.Add("@Image", System.Data.SqlDbType.VarBinary).Value = fileData;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ClearTextboxes();

                    string successScript = "alert('Succesfully registered');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
                }
                void ClearTextboxes()
                {
                    Tour_Name.Text = "";
                    Tour_Price.Text = "";
                    Tour_Description.Text = "";

                }
            }


        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Panel.aspx");
        }
    }
}