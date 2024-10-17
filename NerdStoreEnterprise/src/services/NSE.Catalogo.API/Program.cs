using NSE.Catalogo.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder
    .AddApiConfiguration()
    .AddSwaggerConfiguration()
    .RegisterServices();

var app = builder.Build();

app
    .UseSwaggerConfiguration()
    .UseApiConfiguration();

app.Run();
