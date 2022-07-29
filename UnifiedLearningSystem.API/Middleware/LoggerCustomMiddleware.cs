namespace UnifiedLearningSystem.API.Middleware
{
    public class LoggerCustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggerCustomMiddleware> logger;

        public LoggerCustomMiddleware(RequestDelegate next, ILogger<LoggerCustomMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                logger.LogInformation($"Action: {context.Request.Method} Path: {context.Request.Path}");
                await next(context);
            }
            catch (Exception e)
            {
                logger.LogError($"Action: {context.Request.Method} Path: {context.Request.Path} Error: {e.Message}");
            }

        }
    }
}
