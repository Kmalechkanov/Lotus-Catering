﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(LotusCatering.Web.Areas.Identity.IdentityHostingStartup))]

namespace LotusCatering.Web.Areas.Identity
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
