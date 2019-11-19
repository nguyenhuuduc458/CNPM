using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCPage.Services;

namespace MVCPage {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllersWithViews ();
            services.AddDbContext<QuanLyPhongMach> (options =>
                options.UseSqlite (Configuration.GetConnectionString ("ConnectDB")));

            services.AddScoped<INhanVienRepository, NhanVienRepository> ();
            services.AddScoped<IUnitOfWork, UnitOfWork> ();
            services.AddScoped<INhanVienService, NhanVienService> ();

            services.AddScoped<IBenhNhanService, BenhNhanService> ();

            services.AddScoped<IBenhRepository, BenhRepository>();

            services.AddScoped<IPhieuKhamService, PhieuKhamService>();

            services.AddScoped<IDonThuocRepository, DonThuocRepository>();
            services.AddScoped<IDonThuocService, DonThuocService>();
            
            services.AddScoped<IBenhService, BenhService>();

            services.AddScoped<IThuocService, ThuocService>();
            services.AddScoped<IThuocRepository, ThuocRepository>();

            services.AddScoped<IChiTietDonThuocRepository, ChiTietDonThuocRepository>();
            services.AddSession ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseSession();
            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
           
        }
    }
}