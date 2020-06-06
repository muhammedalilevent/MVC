using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1_Razor_Html.Startup))]
namespace _1_Razor_Html
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
