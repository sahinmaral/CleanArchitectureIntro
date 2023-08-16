﻿namespace CleanArchitectureIntro.WebAPI.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
