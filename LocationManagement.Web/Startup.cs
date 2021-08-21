using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(LocationManagement.Web.Web.Startup))]

namespace LocationManagement.Web.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           app.UseCors(CorsOptions.AllowAll);
           

        }
    }
}
