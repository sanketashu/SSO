using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationModule;

namespace Site1
{
    public partial class Site1Master : System.Web.UI.MasterPage
    {
        static bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag && !Page.IsPostBack)
            {
                string getCookie = ManageCookie.Cookies_Get("Username");
                if (!string.IsNullOrWhiteSpace(getCookie))
                {
                    bool b = Autheticate.IsUserLoggedIn(getCookie);
                    if (!b)
                    {
                        flag = true;
                        Response.Redirect("Login.aspx");
                        
                    }
                }
                //else
                    //Response.Redirect("Login.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            string getCookie = ManageCookie.Cookies_Get("Username");
            if (!string.IsNullOrWhiteSpace(getCookie))
            {
                bool b = Autheticate.LogoutUser(getCookie);
                if (b)
                {
                    ManageCookie.Cookies_Set("Username", "", DateTime.Now.AddDays(-1));
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}