using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using GameVerse.Models;


namespace GameVerse
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]?.ToString() != "admin")
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
                ShowGames();
        }

        protected void btnAddGame_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string image = txtImage.Text.Trim();
            string price = txtPrice.Text.Trim();
            string desc = txtDescription.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Games (Title, ImageUrl, Description, Price) VALUES (@Title, @ImageUrl, @Description, @Price)", conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@ImageUrl", image);
                cmd.Parameters.AddWithValue("@Description", desc);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(price));
                cmd.ExecuteNonQuery();
            }

            txtTitle.Text = txtImage.Text = txtPrice.Text = txtDescription.Text = "";
            ShowGames();
        }

        private void ShowGames()
        {
            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Games ORDER BY GameID DESC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                litGames.Text = "";

                while (reader.Read())
                {
                    string title = reader["Title"].ToString();
                    string image = reader["ImageUrl"].ToString();
                    string desc = reader["Description"].ToString();
                    string price = Convert.ToDecimal(reader["Price"]).ToString("C");

                    litGames.Text += $@"
                        <div class='card bg-dark text-white mb-3' style='max-width: 300px; display:inline-block; margin-right: 10px;'>
                            <img src='{image}' class='card-img-top' style='height:200px; object-fit:cover;' />
                            <div class='card-body'>
                                <h5 class='card-title'>{title}</h5>
                                <p class='card-text'>{desc}</p>
                                <span class='text-success'>{price}</span>
                            </div>
                        </div>";
                }
            }
        }
    }
}
