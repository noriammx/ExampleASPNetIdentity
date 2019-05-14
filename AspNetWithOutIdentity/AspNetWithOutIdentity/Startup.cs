using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetWithOutIdentity.Startup))]
namespace AspNetWithOutIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
