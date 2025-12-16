using System;

namespace GameVerse
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prevent access if not logged in
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            // Optional: redirect admin to AdminPanel
            if (Session["role"] != null && Session["role"].ToString() == "admin")
            {
                Response.Redirect("AdminPanel.aspx");
            }
        }
    }
}
