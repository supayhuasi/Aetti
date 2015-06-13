using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AETTI.Startup))]
namespace AETTI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
