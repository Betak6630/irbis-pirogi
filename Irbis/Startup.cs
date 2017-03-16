using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Irbis.Startup))]
namespace Irbis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
