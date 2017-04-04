using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConnectionLayer.Startup))]
namespace ConnectionLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
