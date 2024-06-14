using BLL.IPersonReposatores;
using BLL.PersonReposatores;
using DAL.AppDbContext;
using DAL.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PL.MappingProfile;
using PL.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL
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
            services.AddControllersWithViews();

            //services.AddScoped<IPersonalReposatores, PersonalReposatores>();
            //services.AddScoped<IFatherReposatories, FatherReposatores>();
            //services.AddScoped<IMotherReposatores, MotherReposatores>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(m=>m.AddProfile(new PersonsProfile()));
            services.AddAutoMapper(m=>m.AddProfile(new FatherProfile()));
            services.AddAutoMapper(M => M.AddProfile(new MotherProfile()));
            services.AddAutoMapper(M => M.AddProfile(new UserProfile()));
            services.AddAutoMapper(M => M.AddProfile(new RoleProfile()));
            services.AddDbContext<AppDbContextClass>(options =>
            {
				options.UseSqlServer("Server=.;Database=project_v13;Trusted_Connection=True;MultipleActiveResultSets=True");
            });
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = true;//[@ # $] Available
				options.Password.RequireDigit = true;//[3456788]
				options.Password.RequireUppercase = true;// At Lest one Char "UpperCase"[AHMED]
														 //options.Password.RequiredLength = 16; // At least 16 numbers 
			}).AddEntityFrameworkStores<AppDbContextClass>()
   .AddDefaultTokenProviders();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		.AddCookie(options =>
		{
			options.LoginPath = "Account/Login";
			options.AccessDeniedPath = "Home/Error";
		});
		}

		private void ConnectionString(SqlServerDbContextOptionsBuilder builder)
		{
			throw new NotImplementedException();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
