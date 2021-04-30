using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private string clientId;
        //private string authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant); 
        private string postLogoutRedirectUri;
        private static string aadInstance;
        private static string tenant;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSession();
            services.AddTransient<IUserService, UserService>();
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("https://reqres.in/");
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddOpenIdConnect(options =>
                {
                    options.Authority = "https://login.microsoftonline.com/c6923302-9f09-468c-8bb1-2eb672fdfcc1";
                    options.ClientId = "57e0c022-6115-4cc9-b352-7b19f1f19f09";
                    options.ResponseType = OpenIdConnectResponseType.IdToken;
                    options.CallbackPath = "/signin-oidc";
                    options.SignedOutRedirectUri = "https://localhost:44384/signout-oidc";
                    options.TokenValidationParameters.NameClaimType = "name";
                }).AddCookie();
            
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
                    "default-src 'self';" +
                    "script-src 'self'; " +
                    "style-src 'self'; " +
                    "img-src 'self'");

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
