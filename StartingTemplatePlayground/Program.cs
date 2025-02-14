using Services;
using Services.Interfaces;

namespace StartingTemplatePlayground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IContentGenerator, LoremIpsumService>();
            builder.Services.AddTransient<IRandomFactProvider, RandomFactProvider>();
            // builder.Services.AddSingleton<IRandomFactProvider, RandomFactProvider>();
            // builder.Services.AddScoped<IRandomFactProvider, RandomFactProvider>();

            builder.Services.AddTransient<TransientRandomFactGenerator>();
            builder.Services.AddScoped<ScopedRandomFactGenerator>();
            builder.Services.AddSingleton<SingletonRandomFactGenerator>();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
