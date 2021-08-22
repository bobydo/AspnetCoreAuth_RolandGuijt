using ConfArch.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ConfArch.Web.Areas.Identity.IdentityHostingStartup))]
namespace ConfArch.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ConfArchWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration
                            .GetConnectionString("ConfArchWebContextConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ConfArchWebContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                    ApplicationUserClaimsPrincipalFactory>();
                services.AddTransient<IEmailSender, EmailSender>();

                services.AddAuthentication()
                    .AddGoogle(o =>
                    {
                        o.ClientId = "686977813024-1pabqkfoar3btu6tsh7puhu3pogcivi0.apps.googleusercontent.com";
                        o.ClientSecret = context.Configuration["Google:ClientSecret"];
                    });
            });
        }
    }
}