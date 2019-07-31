using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace InfoWinDev.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Conta/Login";
            });
            services.AddMvc();
            //services.AddSingleton(); //instância única
            services.AddScoped<Data.InfoWinDevDataContext>(); //escopo por requisição.
            //services.AddTransient();  // toda vez que é necessário ele sobe uma nova instância.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Data.InfoWinDevDataContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                Data.DbInitializer.Init(ctx);

            }

            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Recurso não encontrado.");
            });
        }
    }
}
