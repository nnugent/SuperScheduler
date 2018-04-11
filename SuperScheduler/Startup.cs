using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperScheduler.Startup))]
namespace SuperScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
