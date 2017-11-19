using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Definitiva.Startup))]
namespace Definitiva
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
