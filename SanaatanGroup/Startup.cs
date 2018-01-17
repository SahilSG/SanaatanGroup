using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SanaatanGroup.Startup))]
namespace SanaatanGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
