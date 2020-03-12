using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AnisMasterpieces.Web.Areas.Identity.IdentityHostingStartup))]

namespace AnisMasterpieces.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
