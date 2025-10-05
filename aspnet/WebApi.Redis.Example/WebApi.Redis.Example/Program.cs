using System.Text.Json;
using System.Text.Json.Serialization;
using WebApi.Redis.Example.Converters;
using WebApi.Redis.Example.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Add config files

builder.Configuration.AddJsonFile("appsettings.json");

#endregion

#region Add services to the container.

builder.Services.AddRedis(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers()
    .AddJsonOptions(config =>
    {
        config.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
        config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        config.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverterFactory());
        config.JsonSerializerOptions.Converters.Add(new BigIntJsonConverterFactory());
    });

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapControllers();

#endregion

await app.RunAsync();