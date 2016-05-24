using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Karma.MobileApp.Startup))]

namespace Karma.MobileApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}