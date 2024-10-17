using NSE.WebAPI.Core.Identidade;

namespace NSE.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthConfiguration();

            app.MapControllers();

            return app;
        }
    }
}
