using System;
using System.Configuration;
using System.Data.SqlClient;
using GameVerse.Models;

namespace GameVerse
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (Request.Form["removeGame"] != null)
            {
                RemoveFromCart(Convert.ToInt32(Request.Form["removeGame"]));
            }

            LoadCart();
        }

        private void LoadCart()
        {
            int userId = Convert.ToInt32(Session["userID"]);
            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT G.GameID, G.Title, G.ImageUrl, G.Description, G.Price
                    FROM Cart C
                    INNER JOIN Games G ON C.GameID = G.GameID
                    WHERE C.UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    litCart.Text = "<div class='alert alert-info'>Your cart is currently empty.</div>";
                    pnlCheckout.Visible = false;
                    return;
                }

                string html = "<div class='row'>";
                int count = 0;

                while (reader.Read())
                {
                    count++;
                    html += $@"
                        <div class='col-md-4 mb-4'>
                            <div class='card text-white h-100'>
                                <img src='{reader["ImageUrl"]}' class='card-img-top' />
                                <div class='card-body bg-dark'>
                                    <h5 class='card-title'>{reader["Title"]}</h5>
                                    <p class='card-text'>{reader["Description"]}</p>
                                    <p class='text-success fw-bold'>Price: ${reader["Price"]}</p>
                                    <form method='post'>
                                        <input type='hidden' name='removeGame' value='{reader["GameID"]}' />
                                        <button type='submit' class='btn btn-danger btn-sm'>Remove</button>
                                    </form>
                                </div>
                            </div>
                        </div>";
                }

                html += "</div>";
                litCart.Text = html;
                lblTotal.Text = count.ToString();
                pnlCheckout.Visible = true;
            }
        }

        private void RemoveFromCart(int gameId)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Cart WHERE UserID = @UserID AND GameID = @GameID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@GameID", gameId);
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            string connStr = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // Move items from Cart to Orders
                string insertQuery = @"
                    INSERT INTO Orders (UserID, GameID)
                    SELECT UserID, GameID FROM Cart WHERE UserID = @UserID";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@UserID", userId);
                insertCmd.ExecuteNonQuery();

                // Clear the cart
                SqlCommand clearCmd = new SqlCommand("DELETE FROM Cart WHERE UserID = @UserID", conn);
                clearCmd.Parameters.AddWithValue("@UserID", userId);
                clearCmd.ExecuteNonQuery();
            }

            // Reload updated cart
            LoadCart();
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Thank you for your purchase!');", true);
        }
    }
}
