using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wood.Startup))]
namespace Wood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
