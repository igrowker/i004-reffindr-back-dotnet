using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Reffindr.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error ocurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            // Determinar el código de estado HTTP según el tipo de excepción
            switch (exception)
            {
                case KeyNotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                case ValidationException _:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Internal server error. Please retry later.";
                    break;
            }

            // Configura la respuesta HTTP
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                error = message
            };

            // Escribe la respuesta en formato JSON
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
