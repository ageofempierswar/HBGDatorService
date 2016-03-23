using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HBGDatorServiceMVC.Startup))]
namespace HBGDatorServiceMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
