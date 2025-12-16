using System;
using System.Web.UI;

namespace GameVerse
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateNavLinks();
            }
        }

        private void UpdateNavLinks()
        {
            string role = Session["role"] as string;
            bool loggedIn = Session["user"] != null;

            // Clear default links
            navLinks.Controls.Clear();

            if (!loggedIn)
            {
                // Show only Home, Login, Register
                AddNavItem("Home", "Default.aspx");
                AddNavItem("Login", "Login.aspx");
                AddNavItem("Register", "Register.aspx");
            }
            else if (role == "admin")
            {
                AddNavItem("Admin Panel", "AdminPanel.aspx");
                AddNavItem("Logout", "Logout.aspx");
            }
            else
            {
                // Normal User
                AddNavItem("Home", "Default.aspx");
                AddNavItem("Store", "Store.aspx");
                AddNavItem("Cart", "Cart.aspx");
                AddNavItem("Wishlist", "Wishlist.aspx");
                AddNavItem("Logout", "Logout.aspx");
            }
        }

        private void AddNavItem(string text, string url)
        {
            var li = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
            li.Attributes["class"] = "nav-item";

            var a = new System.Web.UI.HtmlControls.HtmlAnchor
            {
                InnerText = text,
                HRef = url
            };
            a.Attributes["class"] = "nav-link";

            li.Controls.Add(a);
            navLinks.Controls.Add(li);
        }

    }
}
