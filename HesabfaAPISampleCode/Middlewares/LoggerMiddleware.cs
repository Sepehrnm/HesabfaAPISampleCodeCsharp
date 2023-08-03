namespace HesabfaAPISampleCode.Middlewares
{
    public static class LoggerMiddleware
    {
        public  static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {

                //await context.Response.WriteAsync("Map Test 2");

                await next.Invoke();
            });
        }
    }
}
