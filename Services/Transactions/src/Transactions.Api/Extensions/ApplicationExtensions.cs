using Transactions.Api.Middlewares;

namespace Transactions.Api.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
