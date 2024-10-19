﻿using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<AppSettings>(builder.Configuration);
        }

        public static void UseMvcConfiguration(this WebApplication app)
        {
            //if (!app.Environment.IsDevelopment())
            //{
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Catalogo}/{action=Index}/{id?}");
        }
    }
}
