using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mandatory1.Startup))]
namespace Mandatory1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
