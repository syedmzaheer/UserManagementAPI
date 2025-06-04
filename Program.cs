var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();      // First
app.UseMiddleware<TokenAuthenticationMiddleware>(); // Second
app.UseMiddleware<LoggingMiddleware>();             // Last

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
