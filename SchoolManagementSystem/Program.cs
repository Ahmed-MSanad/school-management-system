using Microsoft.EntityFrameworkCore;
using School.Data.Contexts;
using School.Repository.RepoImplementations;
using School.Repository.RepoInterfaces;
using School.Service.ServiceImplementations;
using School.Service.ServiceInterfaces;

namespace SchoolManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<SchoolDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISchoolClassService, SchoolClassService>();

            #endregion

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
