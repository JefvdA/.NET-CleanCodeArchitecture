using System.ComponentModel.DataAnnotations;
using WebAPI.ResponseInfo;
using System.Text.Json;

namespace WebAPI.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = new ErrorResponseInfo();
            response.Message = ex.Message;
            switch (ex)
            {
                case ValidationException:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case KeyNotFoundException _:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    break;
            }
            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
