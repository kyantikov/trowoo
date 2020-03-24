using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using System.Net.Http;

using Okta.AspNetCore;
using Trowoo.Services;
using Trowoo.Services.MarketData;


namespace Trowoo
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
            // Add this so that server allows requests coming from a client application which is running on port that
            // is different than the server.
            services.AddCors(options =>
            {
                // The CORS policy is open for testing purposes. In a production application, you should restrict it to known origins.
                options.AddPolicy(
                    "AllowAll",
                    builder => builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            })
            .AddOktaWebApi(new OktaWebApiOptions()
            {
                OktaDomain = Configuration.GetValue<string>("Okta:OktaDomain"),
                AuthorizationServerId = Configuration.GetValue<string>("Okta:AuthorizationServerId"),
                Audience = Configuration.GetValue<string>("Okta:Audience")
            });
            // services.AddAuthorization();
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<TrowooDbContext>();
            services.AddScoped<SecurityService>();
            services.AddScoped<PortfolioService>();
            services.AddScoped<PositionService>();
            services.AddScoped<TrailingStopService>();
            services.AddScoped<LowPriceService>();
            services.AddScoped<HighPriceService>();
            services.AddScoped<MarketDataService>();
            services.AddSingleton<AlphaVantageMarketDataProvider>();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            // app.UseAuthorization();
            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
