using System;
using System.Configuration;
using System.Data.SqlClient;
using GameVerse.Models;

namespace GameVerse
{
    public partial class Wishlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (Request.Form["removeGame"] != null)
            {
                RemoveGameFromWishlist(Convert.ToInt32(Request.Form["removeGame"]));
            }

            LoadWishlist();
        }

        private void LoadWishlist()
        {
            int userId = Convert.ToInt32(Session["userID"]);
            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT G.GameID, G.Title, G.ImageUrl, G.Description
                    FROM Wishlist W
                    INNER JOIN Games G ON W.GameID = G.GameID
                    WHERE W.UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    litWishlist.Text = "<div class='alert alert-info'>You have not added any games to your wishlist yet.</div>";
                    return;
                }

                string html = "<div class='row'>";
                while (reader.Read())
                {
                    html += $@"
                        <div class='col-md-4 mb-4'>
                            <div class='card text-white h-100'>
                                <img src='{reader["ImageUrl"]}' class='card-img-top' />
                                <div class='card-body bg-dark'>
                                    <h5 class='card-title'>{reader["Title"]}</h5>
                                    <p class='card-text'>{reader["Description"]}</p>
                                    <form method='post'>
                                        <input type='hidden' name='removeGame' value='{reader["GameID"]}' />
                                        <button type='submit' class='btn btn-danger btn-sm me-2'>Remove</button>
                                    </form>
                                </div>
                            </div>
                        </div>";
                }
                html += "</div>";
                litWishlist.Text = html;
            }
        }

        private void RemoveGameFromWishlist(int gameId)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Wishlist WHERE UserID = @UserID AND GameID = @GameID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@GameID", gameId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
