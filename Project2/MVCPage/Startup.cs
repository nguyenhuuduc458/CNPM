using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Services;
using MVCPage.Interfaces;
using MVCPage.Services;
using ApplicationCore.Mapping;
using AutoMapper;

namespace MVCPage {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllersWithViews ();
            // connect database
            services.AddDbContext<QuanLyPhongMach> (options =>
                options.UseSqlite (Configuration.GetConnectionString ("ConnectDB")));
            services.AddAutoMapper(typeof(MappingProfile));

             // dependency injection thuoc
             services.AddScoped<IThuocRepository, ThuocRepository>();
             services.AddScoped<IUnitOfWork, UnitOfWork> ();
             services.AddScoped<IThuocService,ThuocService>();
             services.AddScoped<IThuocServiceView,ThuocServiceView>();

            // dependency injection nhanvien
            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<INhanVienService, NhanVienService> ();
            services.AddScoped<INhanVienServiceView, NhanVienServiceView>();

            // dependency injection BenhNhan
            services.AddScoped<IBenhNhanRepository, BenhNhanRepository>();
            services.AddScoped<IBenhNhanService, BenhNhanService>();
            services.AddScoped<IBenhNhanServiceView, BenhNhanServiceView>();

            // dependency injection PhieuKham
            services.AddScoped<IPhieuKhamRepository, PhieuKhamRepository>();
            services.AddScoped<IPhieuKhamService, PhieuKhamService>();
            services.AddScoped<IPhieuKhamServiceView, PhieuKhamServiceView>();

            // dependency injection Benh
            services.AddScoped<IBenhRepository, BenhRepository>();
            services.AddScoped<IBenhService, BenhService>();
            services.AddScoped<IBenhServiceView, BenhServiceView>();

            // dependency injection don thuoc
            services.AddScoped<IDonThuocRepository, DonThuocRepository>();
            services.AddScoped<IDonThuocService, DonThuocService>();
            services.AddScoped<IDonThuocServiceView, DonThuocServiceView>();
            services.AddScoped<IChiTietDonThuocRepository, ChiTietDonThuocRepository>();

            // dependency injection bao cao
            services.AddScoped<IBaoCaoService, BaoCaoService>();
            services.AddScoped<IBaoCaoServiceView, BaoCaoServiceView>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            
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