using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademeicInformationSystemProject.Startup))]
namespace AcademeicInformationSystemProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
