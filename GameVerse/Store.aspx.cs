using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using GameVerse.Models;


namespace GameVerse
{
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (Session["role"]?.ToString() == "admin")
                Response.Redirect("AdminPanel.aspx");

            if (!IsPostBack)
                LoadGames();
        }

        private void LoadGames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;
            List<Game> games = new List<Game>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Games ORDER BY GameID DESC", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    games.Add(new Game
                    {
                        GameID = Convert.ToInt32(reader["GameID"]),
                        Title = reader["Title"].ToString(),
                        ImageUrl = reader["ImageUrl"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }

            rptGames.DataSource = games;
            rptGames.DataBind();
        }

        protected void rptGames_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int gameId = Convert.ToInt32(e.CommandArgument);
            string connectionString = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Games WHERE GameID = @GameID", conn);
                cmd.Parameters.AddWithValue("@GameID", gameId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) return;

                Game selectedGame = new Game
                {
                    GameID = gameId,
                    Title = reader["Title"].ToString(),
                    ImageUrl = reader["ImageUrl"].ToString(),
                    Description = reader["Description"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"])
                };

                string key = e.CommandName == "AddToWishlist" ? "wishlist" : "cart";
                List<Game> list = Session[key] as List<Game> ?? new List<Game>();

                if (!list.Exists(g => g.GameID == gameId))
                {
                    list.Add(selectedGame);
                    Session[key] = list;
                }
            }

            LoadGames();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;
            List<Game> games = new List<Game>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Games WHERE Title LIKE @Keyword", conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Game
                    {
                        GameID = Convert.ToInt32(reader["GameID"]),
                        Title = reader["Title"].ToString(),
                        ImageUrl = reader["ImageUrl"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }

            rptGames.DataSource = games;
            rptGames.DataBind();
        }


    }
}
