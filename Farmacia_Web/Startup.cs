using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Farmacia_Web.Startup))]
namespace Farmacia_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
