using Microsoft.AspNetCore.Builder;

namespace SoftwareHospital.ExceptionHandling.DependencyInjection;

public static class ApplicationBuilderExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
