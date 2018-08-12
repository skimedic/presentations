using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(simpleCalc.Web.Startup))]
namespace simpleCalc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
