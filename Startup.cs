using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using RazorWebApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebAPp
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

            //services.AddAuthorization(options =>
            //{
            //    By default, all incoming requests will be authorized according to the default policy
            //    options.FallbackPolicy = options.DefaultPolicy;
            //});
            services.AddRazorPages()
                .AddMvcOptions(options => { })
                .AddMicrosoftIdentityUI();
            services.AddSession();
            services.AddTransient<IUserService, UserService>();
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("https://reqres.in/");
            });
            
            

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add(
                    "Content-Security-Policy",
                    "script-src 'self'; ");

                await next();
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }


    }
}
