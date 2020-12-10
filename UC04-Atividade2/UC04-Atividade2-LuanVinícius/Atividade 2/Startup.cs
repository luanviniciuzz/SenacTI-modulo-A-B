using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Atividade_2
{
    public class Startup
{
public Startup(IConfiguration configuration)
{
Configuration = configuration;
}
public IConfiguration Configuration { get; }
public void ConfigureServices(IServiceCollection services)
{
services.AddControllersWithViews();
services.Configure<CookiePolicyOptions>(options =>
{
options.CheckConsentNeeded = context => false;
options.MinimumSameSitePolicy = SameSiteMode.None;

// MvcOptions.EnableEndpointRouting = false;

});
services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
services.AddMvc(options => options.EnableEndpointRouting = false);
services.AddMemoryCache();
services.AddSession();
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
if (env.IsDevelopment())
{
app.UseDeveloperExceptionPage();
}
else
{
app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseSession();
app.UseMvc(routes =>
        {
            routes.MapRoute(name: "default",
              template: "{controller=Home}/{action=Index}/{id?}");
        });
}
}
}
