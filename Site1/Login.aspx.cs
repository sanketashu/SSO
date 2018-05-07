using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationModule;
using System.Configuration;
namespace Site1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string
                    username = txtUsername.Text.Trim(),
                    password = txtPassword.Text.Trim();
                int
                    siteId = Convert.ToInt32(ConfigurationManager.AppSettings["SiteId"]);

                bool isLogin = Autheticate.AuthenticateUser(username, password, siteId);
                if (isLogin)
                    Response.Redirect("Default.aspx");
                else
                    lblMessage.Text = "Incorrect Id or Password";
            }

        }
    }
}