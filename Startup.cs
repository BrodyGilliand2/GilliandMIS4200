using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GilliandMIS4200.Startup))]
namespace GilliandMIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
