using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lib.AspNetCore.ServerSentEvents;
using Demo.AspNetCore.ServerSentEvents.Services;
using System.IO;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Demo.AspNetCore.ServerSentEvents
{
    public class Startup
    {
        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/event-stream" });
            });

            services.AddServerSentEvents();
            services.AddSingleton<IHostedService, HeartbeatService>();

            services.AddServerSentEvents<INotificationsServerSentEventsService, NotificationsServerSentEventsService>();
            services.AddNotificationsService(Configuration);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var host = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseHttpSys(options =>
            {
                options.UrlPrefixes.Add("http://localhost:63861");
                options.UrlPrefixes.Add("https://localhost:44365");
                options.Authentication.Schemes = AuthenticationSchemes.None;
                options.Authentication.AllowAnonymous = true;
            })
            .Build();

            host.Run();   
        }
        #endregion
    }
}
