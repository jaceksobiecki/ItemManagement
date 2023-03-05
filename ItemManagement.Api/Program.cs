using System.Text.Json.Serialization;
using ItemManagement.Api.Middleware;
using ItemManagement.Application.Mappings;
using ItemManagement.Infrastructure.DependencyContainer;
using ItemManagement.Infrastructure.Extensions.EfCore;
using ItemManagement.Infrastructure.Extensions.MediatR;
using ItemManagement.Infrastructure.Extensions.OData;
using ItemManagement.Infrastructure.Extensions.Swagger;
using Microsoft.AspNetCore.OData;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services
        .AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true)
        .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
        .AddOData(option => option.AddRouteComponents("odata", EdmConfigurer.GetEdmModel()).Select().Filter().Count().OrderBy().Expand().SkipToken().SetMaxTop(50));

    builder.Logging.ClearProviders();
    builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
    builder.Logging.AddConsole();
    builder.Host.UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = false });

    builder.Services
        .AddCors()
        .AddAutoMapper(typeof(AutoMapperProfiles))
        .AddEfCore(builder.Configuration)
        .AddEndpointsApiExplorer()
        .AddSwagger()
        .AddMediatR()
        .AddApplication();

    builder.Services.AddHealthChecks();
}

var app = builder.Build();

// Configure the HTTP request pipeline.

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors()
        .UseMiddleware<ErrorHandlerMiddleware>()
        .UseHttpsRedirection()
        .UseAuthorization();

    app.MapControllers();

    app.MapHealthChecks("/health");

    app.Run();
}