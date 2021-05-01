using Microsoft.AspNetCore.Builder;
using Upstart13.BeerApp.Infrastructure.Middlewares;

namespace Upstart13.BeerApp.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}