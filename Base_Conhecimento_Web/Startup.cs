using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Base_Conhecimento_Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Base_Conhecimento_Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Like",
                    "Consulta/like/{solucao}/",
                    new { controller = "Consulta", action = "Like", solucao = 0, curtida = false });
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    "Like",
                    "Solucao/like/{solucao}",
                    new { controller = "Home", action = "Like", solucao = 0 });
                endpoints.MapRazorPages();


                endpoints.MapControllerRoute(
                    "Delete",
                    "/Alterar/DeleteArquivoSolucao/{nome}",
                    new { controller = "Alterar", action = "DeleteArquivoSolucao", nome = "a" });
                endpoints.MapRazorPages();


                endpoints.MapControllerRoute(
                    "Delete",
                    "/Alterar/Delete/{nome}",
                    new { controller = "Alterar", action = "Delete", nome = "a" });
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    "Alterar",
                    "/Alterar/Alterar/{id}",
                    new { controller = "Alterar", action = "Alterar", id = " "});
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
