using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["session_id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    string userid = Session["User_id"].ToString();
                    SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from UserInfo where User_id=@User_id ", conn);
                    cmd.Parameters.AddWithValue("@User_id", userid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User_id.Text = reader["User_id"].ToString();
                        User_Name.Text = reader["User_Name"].ToString();
                        User_mobile.Text = reader["User_mobile"].ToString();

                        User_id.ReadOnly = true;
                        User_Name.ReadOnly = true;
                        User_mobile.ReadOnly = true;
                        travel_date.ReadOnly = true;
                    }
                }
                Tours();
                Guides();
            }
        }

        private void Tours()
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
            {
                conn.Open();
                string query = "SELECT Tour_Name, Tour_Price FROM ToursInfo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Tour_Name.DataSource = reader;
                        Tour_Name.DataTextField = "Tour_Name";
                        Tour_Name.DataValueField = "Tour_Price";
                        Tour_Name.DataBind();
                    }
                }
            }

            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand lol = new SqlCommand("select * from ToursInfo", connection);
            lol.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);
            connection.Open();
            SqlDataReader read = lol.ExecuteReader();

            if (read.Read())
            {
                Tour_Price.Text = read["Tour_Price"].ToString();
                Tour_Price.ReadOnly = true;
            }
        }

        private void Guides()
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
            {
                conn.Open();
                string query = "SELECT GuideId, CONCAT(Guide_FirstName, ' ', Guide_LastName) AS GuideName FROM GuideInfo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        GuideName.DataSource = reader;
                        GuideName.DataTextField = "GuideName";
                        GuideName.DataValueField = "GuideId";

                        GuideName.DataBind();
                    }
                }
            }

            SqlConnection connection = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand lol = new SqlCommand("select * from GuideInfo WHERE GuideId=@GuideId ", connection);
            lol.Parameters.AddWithValue("@GuideId", GuideId.Text);
            connection.Open();
            SqlDataReader read = lol.ExecuteReader();

            if (read.Read())
            {
               

                GuideId.Text = read["GuideId"].ToString();
                GuideId.ReadOnly = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            travel_date.Text = Calendar1.SelectedDate.ToShortDateString();
            travel_date.ReadOnly = true;
        }

        protected void Tour_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tour_Price.Text = Tour_Name.Text;
            GuideId.ReadOnly = true;
        }

        protected void GuideName_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            GuideId.Text = GuideName.SelectedValue;
            GuideId.ReadOnly = true;
        }

        protected void CalculateTotal(object sender, EventArgs e)
        {
            if (int.TryParse(Tour_People_Number.Text, out int numberOfPeople))
            {
                // Check if Tour_Price is a valid decimal
                if (decimal.TryParse(Tour_Price.Text, out decimal tourPrice))
                {
                    // Calculate Tour_Price_Total
                    decimal tourPriceTotal = tourPrice * numberOfPeople;

                    // Display the calculated total
                    Tour_Price_Total.Text = tourPriceTotal.ToString("F2");
                }
             
            }
            
        }





        protected void Book_btn_Click(object sender, EventArgs e)
        {
            return;
        }
        protected void bk_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }


    }

}
