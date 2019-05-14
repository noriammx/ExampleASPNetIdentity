using AspNetWithIdentity.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetWithIdentity.Startup))]
namespace AspNetWithIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            IdentityInit.InitializeIdentityForEF();
        }
    }
}
