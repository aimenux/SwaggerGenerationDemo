using Asp.Versioning;

namespace Presentation.Extensions;

public static class VersioningExtensions
{
    private const string ApiVersionHeaderName = "x-api-version";

    public static void AddVersioning(this WebApplicationBuilder builder)
    {
        var defaultVersion = new ApiVersion(1.0);
        builder.Services
            .AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = defaultVersion;
                options.ApiVersionReader = GetApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = defaultVersion;
                options.ApiVersionParameterSource = GetApiVersionReader();
            });
    }

    private static IApiVersionReader GetApiVersionReader()
    {
        return ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new QueryStringApiVersionReader(ApiVersionHeaderName),
            new HeaderApiVersionReader(ApiVersionHeaderName),
            new MediaTypeApiVersionReader(ApiVersionHeaderName));
    }
}