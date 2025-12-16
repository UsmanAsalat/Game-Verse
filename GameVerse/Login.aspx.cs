using System.Configuration;
using System.Data.SqlClient;
using System;

namespace GameVerse
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, Role FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string role = reader["Role"].ToString();
                    string userId = reader["UserID"].ToString();

                    Session["user"] = email;
                    Session["userID"] = userId;
                    Session["role"] = role;

                    if (role == "admin")
                        Response.Redirect("AdminPanel.aspx");
                    else
                        Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                    lblMessage.CssClass = "text-danger d-block text-center mb-3";
                }
            }
        }

    }
}
