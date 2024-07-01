namespace Emi.TechnicalTest.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Registrar detalles de la solicitud
            _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");

            // Llamar al siguiente middleware en el pipeline
            await _next(context);

            // Registrar detalles de la respuesta
            _logger.LogInformation("Finished handling request.");
        }
    }
}
