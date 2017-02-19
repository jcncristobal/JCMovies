using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JCMovies.Startup))]
namespace JCMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
