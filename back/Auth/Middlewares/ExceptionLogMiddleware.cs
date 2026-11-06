using Auth.Logger;

namespace Auth.Middlewares
{
    public class ExceptionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ExLogger _logger;

        public ExceptionLogMiddleware(RequestDelegate next, ExLogger logger)
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
            catch (Exception ex) { await _logger.Log(ex.ToString()); }
        }
    }

    public static class Extension
    {
        public static void UseExceptionLogger(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionLogMiddleware>();
        }
    }
}
