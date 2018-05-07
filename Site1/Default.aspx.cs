using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationModule;

namespace Site1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string getCookie = ManageCookie.Cookies_Get("Username");
                if (!string.IsNullOrWhiteSpace(getCookie))
                {
                    bool b = Autheticate.IsUserLoggedIn(getCookie);
                    if (!b)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}