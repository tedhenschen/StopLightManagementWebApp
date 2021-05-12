using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StopLightManagementAPI.Areas.Identity.Data;
using StopLightManagementAPI.Data;

[assembly: HostingStartup(typeof(StopLightManagementAPI.Areas.Identity.IdentityHostingStartup))]
namespace StopLightManagementAPI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StopLightManagementAPIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StopLightDB")));

                services.AddDefaultIdentity<StopLightManagementAPIUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<StopLightManagementAPIContext>();
            });
        }
    }
}