using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Delas.Site.Startup))]
namespace Delas.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
