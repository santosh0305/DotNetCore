using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace DotNetCoreSampleApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Igreet,Greetings>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration,
            ILoggerFactory loggerFactory,Igreet greetings, ILogger<Startup> loggerStartup)
        {
            var logger = loggerFactory.CreateLogger("Looger");
            logger.LogInformation("App started !!");

            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }


            //Custom Middleware
            //app.Use(next =>
            //{
            //    return context =>
            //    {
            //        loggerStartup.LogInformation("Request Incoming");
            //        return context.Response.WriteAsync("Hit !!");
            //    };
            //});

            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        loggerStartup.LogInformation("Request Incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit !!");
            //            loggerStartup.LogInformation("Request Handle");
            //        }
            //        else
            //        {
            //            await next(context);
            //            loggerStartup.LogInformation("Response flow going out of pipeline");
            //        }
            //    };
            //});

            //app.UseWelcomePage(new WelcomePageOptions{
            //    Path="/wp"
            //});

            // To make index.html as default file, for all requests below has to be used
            //app.UseDefaultFiles();

            // This is used to access static files (files stored in wwwroot folder : in this case its index.html file
            app.UseStaticFiles();

            // Install default file and static file middleware
            //app.UseFileServer();

            //app.Run(async (context) =>
            //{
            //    //throw new Exception("error!");

            //    //logger.LogInformation("configuration[greeting] "+ configuration["greeting"]);
            //    //string greet = configuration["greeting"];

            //    string greet = greetings.GreetingOfTheDay();
            //    //await context.Response.WriteAsync("Hello World! and "+ greet);

            //    await context.Response.WriteAsync($"{greet}" + env.EnvironmentName);

            //});


            // Working with MVC
            // Add MVC based services
            //app.UseMvcWithDefaultRoute();

            // Configuring/Adding Conventional routing in MVC
            app.UseMvc(configureRoutes);
            app.Use(next =>
            {
                return context =>
                {
                    context.Response.ContentType = "text/plain";
                    return context.Response.WriteAsync("Not Found");
                };
            });
        }

        // Configuring/Adding Conventional routing in MVC
        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            // Home/index/4 
            // ? means optional param

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            //throw new NotImplementedException();
        }
    }
}