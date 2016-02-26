using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Safmeds.Web.Startup))]
namespace Safmeds.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
