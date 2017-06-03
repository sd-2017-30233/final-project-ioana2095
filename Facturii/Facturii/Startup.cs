using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facturii.Startup))]
namespace Facturii
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.MapSignalR();
            ConfigureAuth(app);
        }

    }
}
