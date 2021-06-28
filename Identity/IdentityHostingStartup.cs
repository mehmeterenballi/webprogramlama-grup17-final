using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeritabaniProjesi.Data;
using VeritabaniProjesi.Models;

[assembly: HostingStartup(typeof(VeritabaniProjesi.Areas.Identity.IdentityHostingStartup))]
namespace VeritabaniProjesi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                ODBConnector.AddDbContextToOracleDb<UserDataContext>(services);

                services.AddDefaultIdentity<MyUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UserDataContext>();
            });
        }
    }
}