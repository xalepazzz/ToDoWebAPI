using back.Logger;

namespace back.Middlewares
{
    public class ExceptionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ExceptionLogger _logger;

        public ExceptionLogMiddleware(ExceptionLogger logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(ex.Message);
            }
        }

    }

    public static class ExcrptionLogMiddlewareExtensions
    {
        public static void UseLogger(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionLogMiddleware>();
        }
    }
}
