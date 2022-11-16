
using _2022_2C_I__HistoriasClinicas_.Data;
using Microsoft.EntityFrameworkCore;

namespace _2022_2C_I__HistoriasClinicas_
{
    public static class Startup
    {
        public static WebApplication IniciarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);

            var app = builder.Build();
            Configure(app);

            return app;
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<HistoriasClinicasContext>();
        }
        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}


