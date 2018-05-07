using System;
using System.Web.UI;
using AuthenticationModule;

namespace Site2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string name = txtName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                bool isRegister = Autheticate.RegisterUser(name, username, password);
                if (isRegister)
                    lblMessage.Text = "Registered Successfully!!";
                else
                    lblMessage.Text = "Unable to Register. Please try again!!";
            }
        }
    }
}