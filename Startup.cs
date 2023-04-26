using CarShop.Data;
using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using CarShop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop
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


            services.AddRazorPages();
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OdersRepository>();
            services.AddTransient<ICreateCar, CreateCarRepository>();

            services.AddControllersWithViews();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCarts.getCart(sp)); //дл€ создани€ разных корзин разным пользовател€м
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();




            app.UseEndpoints(endpoints =>
            {
                

                endpoints.MapAreaControllerRoute(
                 name: "Admin", areaName: "Admin",
                    pattern: "Admin/{controller=Actors}/{action=Index}/{id?}");



                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                   name: "first",
                   pattern: "{controller=ShopCartController}/{action=ShopCart/Index}/{id?}");

                endpoints.MapControllerRoute(
                 name: "twice",
                 pattern: "{controller=CreateCarController}/{action=CreateCar/Checkout}/{id?}");

            });
           
          


        }
    }
}
