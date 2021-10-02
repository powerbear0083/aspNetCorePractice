using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MockSchoolManagement.DataRepositories;
using MockSchoolManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MockSchoolManagement.CustomerMiddlewares;

namespace MockSchoolManagement
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // 設定密碼驗證複雜程度
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });
            
            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<AppDbContext>();
            // 使用 SQL DB ，通過 IConfiguration 去存去，自訂義名稱 MockStudentDBConnection
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(
                    _configuration.GetConnectionString("MockStudentDBConnection")
                )
            );
            services.AddControllersWithViews(a=> a.EnableEndpointRouting = false);

            // IStudentRepository 介面實作在 MockStudentRepository
            // services.AddSingleton<IStudentRepository, MockStudentRepository>();
            // IStudentRepository 介面實作在 SQLStudentRepository
            services.AddScoped<IStudentRepository, SQLStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                // 為了讓開發模式看到 error page 故這樣使用
                // app.UseStatusCodePagesWithRedirects("~/Error/{0}");
                // 推薦使用
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            
            app.UseStaticFiles();
            // 增加驗證
            app.UseAuthentication();
            app.UseRouting();
            // dotnet 開發團隊建議使用
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc();
            
            // 預設 Route 寫法
            //app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            

            //app.UseAuthorization();

            
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        await context.Response.WriteAsync(processName);
            //    });
            //});
        }
    }
}
