using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;

namespace GameVerse
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = "user"; // default role

            string connectionString = ConfigurationManager.ConnectionStrings["GameVerseConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if user already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", conn);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int userExists = (int)checkCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "Email already registered. Please login.";
                    return;
                }

                // Insert new user
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Users (Email, Password, Role) VALUES (@Email, @Password, @Role)", conn);
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Password", password);
                insertCmd.Parameters.AddWithValue("@Role", role);

                int rowsInserted = insertCmd.ExecuteNonQuery();
                if (rowsInserted > 0)
                {
                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Registration successful! You can now login.";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "Something went wrong. Try again.";
                }
            }
        }

    }
}
