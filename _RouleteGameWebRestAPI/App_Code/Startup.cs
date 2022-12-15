using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_RouleteGameWebRestAPI.Startup))]
namespace _RouleteGameWebRestAPI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
