using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductsApp.Startup))]
namespace ProductsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
