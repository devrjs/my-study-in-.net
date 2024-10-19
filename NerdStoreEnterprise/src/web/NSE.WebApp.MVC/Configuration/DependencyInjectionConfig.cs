using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            //builder.Services
            //    .AddHttpClient<ICatalogoService, CatalogoService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            builder.Services
                .AddHttpClient("Refit", options =>
                {
                    options.BaseAddress = new Uri(builder.Configuration.GetSection("CatalogoUrl").Value);
                })
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUser, AspNetUser>();
        }
    }
}
