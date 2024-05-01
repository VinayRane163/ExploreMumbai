using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Lifetime;


namespace ExploreMumbai
{
    public partial class Booking_display_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin_id"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");

                }
                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * from booking ORDER BY BookingID DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }
            }
            if (!IsPostBack)
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
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Panel.aspx");

        }





        protected void BtnSearch_Click(object sender, EventArgs e)
        {/*
             if (string.IsNullOrEmpty(Search_date.Text) && (string.IsNullOrEmpty(Search_ID.Text)))
            {
                string user_id = bookingId.Text.Trim();



                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM booking WHERE BookingID = @BookingID  ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", user_id);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }
            }
            */
            if (string.IsNullOrEmpty(Search_ID.Text))
            {
                string Search = Search_date.Text.Trim();



                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM booking WHERE travel_date = CONVERT(date, @travel_date, 103)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@travel_date", Search);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }
            }

            


            else if (string.IsNullOrEmpty(Search_date.Text))
            {
                string user_id = Search_ID.Text.Trim();



                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM booking WHERE User_id = @User_id  ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@User_id", user_id);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }
            }


            else
            {

                string user_id = Search_ID.Text.Trim();
                string Search = Search_date.Text.Trim();



                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM booking WHERE User_id = @User_id and  travel_date = CONVERT(date, @travel_date, 103)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@User_id", user_id);
                        command.Parameters.AddWithValue("@travel_date", Search);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }
            }


        }

        protected void BtnReload_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);

        }

        protected void Tour_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Search = Search_date.Text.Trim();

            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM booking WHERE Tour_Name = @User_id";

                if (!string.IsNullOrEmpty(Search))
                {
                    query += " AND travel_date = CONVERT(date, @travel_date, 103)";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_id", Tour_Name.SelectedValue);
                    command.Parameters.AddWithValue("@travel_date", Search);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        rptGuides.DataSource = reader;
                        rptGuides.DataBind();
                    }
                }
            }
        }
    }
}