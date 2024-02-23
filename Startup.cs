using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CJHillPhotography.Startup))]
namespace CJHillPhotography
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
