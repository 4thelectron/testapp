using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstIslandBankCorporation.Startup))]
namespace FirstIslandBankCorporation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
