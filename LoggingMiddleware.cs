public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Incoming request: {Method} {Path}", context.Request.Method, context.Request.Path);

        var originalBody = context.Response.Body;
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        await _next(context);

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = new StreamReader(context.Response.Body).ReadToEnd();
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        _logger.LogInformation("Response status code: {StatusCode}", context.Response.StatusCode);

        await memoryStream.CopyToAsync(originalBody);
        context.Response.Body = originalBody;
    }
}
