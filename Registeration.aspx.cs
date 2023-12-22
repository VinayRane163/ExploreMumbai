using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsEmailAlreadyExists(txt_Email.Text))
            {
                // Email already exists, show an error message
                string script = "alert('Email address is already in use. Please choose a different one.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);
            }
            else
            {
                // Email is unique, proceed with registration
                SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO UserInfo (User_Name, User_id, User_password, User_mobile) VALUES (@User_Name, @User_id, @User_password, @User_mobile)", conn);
                cmd.Parameters.AddWithValue("@User_id", txt_Email.Text);
                cmd.Parameters.AddWithValue("@User_password", txt_Password.Text);
                cmd.Parameters.AddWithValue("@User_Name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@User_mobile", txt_mobile.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cleartext();
                
                // pop up if registeration succesful
                string successScript = "alert('Registration successful. You can now log in.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
            void cleartext()
                {
                txt_Email.Text= "";
                txt_Password.Text = "";
                txt_Name.Text = "";
                txt_mobile.Text = "";
            }
        }

        private bool IsEmailAlreadyExists(string email)
        {
            // Check if the email already exists in the database
            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM UserInfo WHERE User_id = @User_id", conn);
            cmd.Parameters.AddWithValue("@User_id", email);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

    }
}