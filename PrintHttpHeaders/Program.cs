var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    // request headers
    await context.Response.WriteAsync("REQUEST HEADERS:\n");
    foreach (var requestHeader in context.Request.Headers)
    {
        await context.Response.WriteAsync($"{requestHeader.Key} = {requestHeader.Value}\n");
    }
    await context.Response.WriteAsync($"RemoteIpAddress = {context.Connection.RemoteIpAddress}");

    // response headers
    await context.Response.WriteAsync("\n\nRESPONSE HEADERS:\n");
    foreach (var responseHeader in context.Response.Headers)
    {
        await context.Response.WriteAsync($"{responseHeader.Key} = {responseHeader.Value}\n");
    }
});
            
app.Run();