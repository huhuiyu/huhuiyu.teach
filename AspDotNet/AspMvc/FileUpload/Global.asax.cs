using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using FileUpload;
using System.IO;

namespace WebMvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public const string UploadPath = "/upfiles/";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DirectoryInfo file = new DirectoryInfo(
                Server.MapPath(UploadPath));
            if (!file.Exists)
            {
                file.Create();
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = Context.Request.FilePath;
            if ("/".Equals(path))
            {
                Context.RewritePath("/Default/");
            }
        }

    }
}