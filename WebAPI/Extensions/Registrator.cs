using WebAPI.Middleware;

namespace WebAPI.Extensions;

public static class Registrator
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}