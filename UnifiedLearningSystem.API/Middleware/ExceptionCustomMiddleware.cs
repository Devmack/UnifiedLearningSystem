using System.Text.Json;
using UnifiedLearningSystem.API.Utils;

namespace UnifiedLearningSystem.API.Middleware
{
    public class ExceptionCustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionCustomMiddleware> logger;

        public ExceptionCustomMiddleware(RequestDelegate next, ILogger<ExceptionCustomMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await ProcessExceptionAsync(context, e);
            }
        }

        private async Task ProcessExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var error = new CustomErrorResponse();

            switch(e)
            {
                case (ApplicationException ex):
                    if (ex.Message.Contains("User"))
                    {
                        error.MessageValue = "Invalid user or password";
                    }
                    break;
            }

            logger.LogError(e.Message);
            var result = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(result);
        }
    }
}
