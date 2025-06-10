using FormTest.Core.Application.Contracts;
using FormTest.Core.Application.Services;
using FormTest.Core.Domain.Interfaces;
using FormTest.Infrastructure.Data;
using FormTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using FormTest.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;

public static class HostingExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var defaultCulture = new CultureInfo("fa");
        CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
        CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

        builder.Services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources"; // این مسیر باید با نام پوشه در پروژه Localization یکی باشه
        });
        builder.Services.AddControllersWithViews()
               .AddViewLocalization()
               .AddDataAnnotationsLocalization();

        builder.Services.AddSession();

        builder.Services.AddScoped<ILocalizationService, LocalizationService>();

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

        //var supportedCultures = new[] { new CultureInfo("fa"), new CultureInfo("en") };
        //var options = new RequestLocalizationOptions
        //{
        //    DefaultRequestCulture = new RequestCulture("fa"),
        //    SupportedCultures = supportedCultures,
        //    SupportedUICultures = supportedCultures
        //};
        //options.RequestCultureProviders = new[] { new CookieRequestCultureProvider() };
        //app.UseRequestLocalization(options);
        var supportedCultures = new[] { "en", "fa" };

        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture("fa")
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        app.UseSession();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Register}/{id?}");


        return app;
    }
}
