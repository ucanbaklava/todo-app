using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoApp.Domain;

namespace ToDoApp.API.Middlewares
{
    /// <summary>
    /// A global error handling middleware. This middleware needs to be registered in Startup.cs Configure section. Should be registered before other middlewares.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Serilog.ILogger _logger = Log.ForContext<ExceptionMiddleware>();
        //private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.Error($"{exception.Message} {exception.Data}");

            context.Response.ContentType = "application/json";

            ErrorDetails details = new ErrorDetails()
            {
                StatusCode = exception is ArgumentNullException ? StatusCodes.Status404NotFound : StatusCodes.Status500InternalServerError,
                Message = exception.Message
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(details));
        }
    }
}
