using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HBGDatorService.Startup))]
namespace HBGDatorService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
