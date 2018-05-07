using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using WCFServiceLayer;

namespace Site1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("User", new WebServiceHostFactory(), typeof(UserProfileWCFService)));
            RouteTable.Routes.Add(new ServiceRoute("LoggedUser", new WebServiceHostFactory(), typeof(LoggedInUserDetailsWCFService)));
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //var context = HttpContext.Current;
            //var response = context.Response;

            //// enable CORS
            //response.AddHeader("Access-Control-Allow-Origin", "*");

            //if (context.Request.HttpMethod == "OPTIONS")
            //{
            //    response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //    response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //    response.End();
            //}
        }
    }
}