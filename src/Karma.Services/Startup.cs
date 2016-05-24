using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Karma.Services.Startup))]
namespace Karma.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
