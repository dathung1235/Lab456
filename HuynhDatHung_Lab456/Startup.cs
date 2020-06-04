using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HuynhDatHung_Lab456.Startup))]
namespace HuynhDatHung_Lab456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
