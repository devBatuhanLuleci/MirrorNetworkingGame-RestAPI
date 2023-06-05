using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Enable buffering so the request body can be read multiple times
        context.Request.EnableBuffering();

        // Read the request body
        using (StreamReader reader = new StreamReader(context.Request.Body, leaveOpen: true))
        {
            string requestBody = await reader.ReadToEndAsync();

            // Log the request body
            _logger.LogInformation($"Request Body: {requestBody}");

            // Reset the request body stream position to allow it to be read again
            context.Request.Body.Position = 0;
        }

        await _next(context);
    }
}
