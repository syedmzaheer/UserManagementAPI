public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token) || token != "valid-token") // replace with actual logic
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Unauthorized" }));
            return;
        }

        await _next(context);
    }
}
