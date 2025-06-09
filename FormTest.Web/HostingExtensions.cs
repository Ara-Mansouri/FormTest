
using FormTest.Core.Application.Contracts;
using FormTest.Core.Application.Services;
using FormTest.Core.Domain.Interfaces;
using FormTest.Infrastructure.Data;
using FormTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public static class HostingExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.AddControllersWithViews()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization();

        builder.Services.AddSession();


        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
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
        var supportedCultures = new[] { new System.Globalization.CultureInfo("fa"), new System.Globalization.CultureInfo("en") };
        app.UseRequestLocalization(new Microsoft.AspNetCore.Localization.RequestLocalizationOptions
        {
            DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("fa"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });
        app.UseSession();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Register}/{id?}");


        return app;
    }
}
