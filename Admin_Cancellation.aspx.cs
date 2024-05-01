using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Admin_Cancellation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_id"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            else
            {
                if (!IsPostBack)
                {
                    BindBookingData();
                    BindCancellationRequest();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string deleteId = txtDeleteId.Text.Trim();

            if (!string.IsNullOrEmpty(deleteId))
            {
                // Delete data from booking table
                DeleteBookingData(deleteId);

                // Delete data from cancelation_request table
                DeleteCancellationRequestData(deleteId);

                string errorScript = "alert('revoked the booking');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidDateScript", errorScript, true);

                // Rebind data after deletion
                BindBookingData();
                BindCancellationRequest();


            }
        }

        protected void req_Click(object sender, EventArgs e)
        {
            string deleteId = txtDeleteId.Text.Trim();

            if (!string.IsNullOrEmpty(deleteId))
            {
                // Delete data from cancelation_request table
                DeleteCancellationRequestData(deleteId);

                string errorScript = "alert('canceled revoking data);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidDateScript", errorScript, true);

                // Rebind data after deletion
                BindBookingData();
                BindCancellationRequest();


            }
        }
        protected void bACK_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_panel.aspx");
        }

        private void BindBookingData()
        {
            // Use your actual connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT BookingID, Tour_People_Number, User_id,travel_date FROM booking WHERE BookingID IN (SELECT BookingID FROM cancelaton_request)", conn))
                {
                    conn.Open();
                    rptBooking.DataSource = cmd.ExecuteReader();
                    rptBooking.DataBind();
                }
            }
        }

        private void BindCancellationRequest()
        {
            // Use your actual connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT BookingID, Reason FROM cancelaton_request", conn))
                {
                    conn.Open();
                    rptCancellationRequest.DataSource = cmd.ExecuteReader();
                    rptCancellationRequest.DataBind();
                }
            }
        }

        private void DeleteBookingData(string bookingId)
        {
            // Use your actual connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM booking WHERE BookingID = @BookingID", conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DeleteCancellationRequestData(string bookingId)
        {
            // Use your actual connection string
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM cancelaton_request WHERE BookingID = @BookingID", conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
