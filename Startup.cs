using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DesireDelivery.Startup))]
namespace DesireDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
