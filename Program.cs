using BuberBreakfast.Context;
using BuberBreakfast.Contracts.Repository;
using BuberBreakfast.Contracts.Service;
using BuberBreakfast.Implementations.Repository;
using BuberBreakfast.Implementations.Service;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("ApplicationContext")));
            builder.Services.AddScoped<IBreakFastRepository, BreakFastRepository>();
            builder.Services.AddScoped<IBreakFastService,BreaskFastService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=BreakFast}/{action=Index}/{id?}");

            app.Run();
        }
    }
}