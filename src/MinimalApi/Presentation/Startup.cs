using Application;
using Infrastructure;
using Presentation.Extensions;

namespace Presentation;

public sealed class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure();
    }

    public void Configure(WebApplication app)
    {
        app.UseHttpLogging();
        app.UseHttpsRedirection();
        app.MapEndpoints();
        app.UseSwaggerDoc();
    }
}